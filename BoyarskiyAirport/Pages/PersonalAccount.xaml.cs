using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BoyarskiyAirport.Helper;
namespace BoyarskiyAirport.Pages
{
    /// <summary>
    /// Логика взаимодействия для PersonalAccount.xaml
    /// </summary>
    public partial class PersonalAccount : Page
    {

        public PersonalAccount()
        {
 var AuthUser = ClassHelper.Context.Passengers.ToList().Where(i => i.idUser ==  ClassHelper.currentUserID).FirstOrDefault();
            var User = ClassHelper.Context.User.ToList().Where(i => i.id ==  ClassHelper.currentUserID).FirstOrDefault();
            

            InitializeComponent();
           
            txtname.Text =     AuthUser.FirstName;
            txtlastName.Text = AuthUser.LastName;
            txtPhone.Text =    AuthUser.BirthDate.ToString();
            txtdoc.Text =      AuthUser.DocNumber.ToString();
            txtLogin.Text =    User.UserName;
            txtPassowrd.Text = User.Password;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            bool ok = false;
            var AuthUser = ClassHelper.Context.Passengers.ToList().Where(i => i.idUser == ClassHelper.currentUserID).FirstOrDefault();
            var User = ClassHelper.Context.User.ToList().Where(i => i.id == ClassHelper.currentUserID).FirstOrDefault();
            try
            {
                AuthUser.FirstName = txtname.Text;
                AuthUser.LastName = txtlastName.Text;
                AuthUser.BirthDate = Convert.ToDateTime(txtPhone.Text);
                AuthUser.DocNumber = txtdoc.Text;
                User.UserName = txtLogin.Text;
                User.Password = txtPassowrd.Text;
                ok = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (ok) {
                try
                { 
                    ClassHelper.Context.SaveChanges();
                }
                catch (Exception exception )
                {
                    MessageBox.Show("Вы ввели неверные данные");
                }
        }
        }

        private void DisableChanges_Click(object sender, RoutedEventArgs e)
        {
            
            var AuthUser = ClassHelper.Context.Passengers.ToList().Where(i => i.idUser == ClassHelper.currentUserID).FirstOrDefault();
            var User = ClassHelper.Context.User.ToList().Where(i => i.id == ClassHelper.currentUserID).FirstOrDefault();
            txtname.Text = AuthUser.FirstName;
            txtlastName.Text = AuthUser.LastName;
            txtPhone.Text = AuthUser.BirthDate.ToString();
            txtdoc.Text = AuthUser.DocNumber.ToString();
            txtLogin.Text = User.UserName;
            txtPassowrd.Text = User.Password;
        }
    }
}
