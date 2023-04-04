using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using BoyarskiyAirport.Helper;
using static BoyarskiyAirport.Helper.ClassHelper;
namespace BoyarskiyAirport.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {

            InitializeComponent();
            CapchaStart();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            try {
                var AuthUser = ClassHelper.Context.User.ToList().Where(i => i.UserName == TBlogin.Text && i.Password == PBpassword.Password).FirstOrDefault();
                if ( true) //КАПЧА!!!!!!!!!!!!!   TBcapcha.Text.Equals(Txtcapcha.Text)
                {
                    if (AuthUser != null)
                    {

                        var quty = ClassHelper.Context.User.ToList().Where(i => i.UserName == TBlogin.Text && i.Password == PBpassword.Password && i.isAdmin==true).FirstOrDefault();

                        ClassHelper.currentUserID = AuthUser.id ;

                        if (quty != null)
                        {
                
                            ClassHelper.isAdmin = true;
                            AdminMainWin profile = new AdminMainWin();
                            profile.Show();
                            this.Close();
                        }
                        else
                        {
                            ClassHelper.isAdmin = false;
                            UserMainWindow profileUser = new UserMainWindow();
                            profileUser.Show();
                            this.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Такого аккаунта нет");
                    }
                }
                else { MessageBox.Show("Неверная капча");
                    CapchaStart();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            }



        void CapchaStart()
        {
            String allowchar = " ";

            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";

            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";

            allowchar += "1,2,3,4,5,6,7,8,9,0";

            char[] a = { ',' };

            String[] ar = allowchar.Split(a);

            String pwd = "";

            string temp = " ";

            Random r = new Random();



            for (int i = 0; i < 6; i++)

            {

                temp = ar[(r.Next(0, ar.Length))];



                pwd += temp;

            }
            Txtcapcha.Text = pwd;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

