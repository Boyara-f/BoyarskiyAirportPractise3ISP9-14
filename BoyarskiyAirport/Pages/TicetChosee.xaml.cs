using BoyarskiyAirport.Helper;
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
using BoyarskiyAirport.DB;

namespace BoyarskiyAirport.Pages
{
    /// <summary>
    /// Логика взаимодействия для TicetChosee.xaml
    /// </summary>
    public partial class TicetChosee : Page
    {
        public TicetChosee()
        {
            InitializeComponent();

            
            CmbCountres.ItemsSource =  ClassHelper.Context.Country.ToList();
            CmbCountres.DisplayMemberPath = "name";
            CmbCountres.SelectedIndex = 0;


  

    var city = ClassHelper.Context.City.ToList();
            CmbCity.ItemsSource = city.ToList().Where(i => i.idCountry == CmbCountres.SelectedIndex +1);
            CmbCity.DisplayMemberPath = "Name";
            CmbCity.SelectedIndex = 0;



            CmbCopany.ItemsSource = ClassHelper.Context.Aircompany.ToList();
            CmbCopany.DisplayMemberPath = "AircompanyName";
            CmbCopany.SelectedIndex = 0;

             BtnFound_Click(null, null);

            cmbClass.ItemsSource = new List<string>() {"Эконом","Бизнес" };
            cmbClass.SelectedIndex = 0;


        }

        private void CmbCountres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var city = ClassHelper.Context.City.ToList();
            CmbCity.ItemsSource = city.ToList().Where(i => i.idCountry == CmbCountres.SelectedIndex+1);
            CmbCity.DisplayMemberPath = "Name";
            DataGridUpdate();
        }

        void DataGridUpdate()
        {
            try
            {
 var quar =
             from f in Helper.ClassHelper.Context.Flight
             join a in ClassHelper.Context.Aircompany on f.idAircompany equals a.id
             join p in ClassHelper.Context.Plane on f.idPlane equals p.id
             join ap in ClassHelper.Context.AirPort on f.idAirPort equals ap.id
             where  a.id == CmbCopany.SelectedIndex && ap.idCity == CmbCity.SelectedIndex
             
             select new
             {
                 IDFliht = f.id,
                 Aircompany = a.AircompanyName,
                 PlaneNumber = p.PlaneModel,
                 Airport = ap.Name,
                 TimeOfTakeOff = f.DateTimeStartGMT,
                 TimeOfArrive = f.DateTimeArrival,
             };
            dataGrid.ItemsSource = quar.ToList();
            }
            catch (Exception e)
            {

                 MessageBox.Show(e.Message);
                throw;
            }
           
        }

        private void CmbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridUpdate();
        }

        private void CmbCopany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridUpdate();

        }

        private void BtnFound_Click(object sender, RoutedEventArgs e)   { var quar = from f in Helper.ClassHelper.Context.Flight join a in ClassHelper.Context.Aircompany on f.idAircompany equals a.id join p in ClassHelper.Context.Plane on f.idPlane equals p.id join ap in ClassHelper.Context.AirPort on f.idAirPort equals ap.id where  f.StatusIsFly == false select new { IDFliht = f.id, Aircompany = a.AircompanyName, PlaneNumber = p.PlaneModel,  Airport = ap.Name,  TimeOfTakeOff = f.DateTimeStartGMT,TimeOfArrive = f.DateTimeArrival,  }; dataGrid.ItemsSource = quar.ToList(); }
        private void TxtFlyNum_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((ClassHelper.Context.Flight.ToList().Where(q => q.id.ToString() == TxtFlyNum.Text)).FirstOrDefault() !=null)
                {
                    txtAirport.Text = ClassHelper.Context.AirPort.ToList().Where(i => i.id == (ClassHelper.Context.Flight.ToList().Where(q => q.id.ToString() == TxtFlyNum.Text).FirstOrDefault().idAirPort)).FirstOrDefault().Name;
                    txtTimeStart.Text = ClassHelper.Context.Flight.ToList().Where(i => i.id.ToString() == TxtFlyNum.Text).FirstOrDefault().DateTimeStart.ToString();
                }
                else
                {
                    MessageBox.Show("Выбранного рейса не существует");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnTakeTiket_Click(object sender, RoutedEventArgs e)
        {
            Tickets tik = new Tickets();
            tik.idBuyer = 2;
            tik.idFlight = Convert.ToInt32( TxtFlyNum.Text);
            tik.idPassenger = ClassHelper.currentUserID;
            tik.Class = (cmbClass.SelectedIndex+1).ToString();
            MessageBox.Show("билет успешно оформлен!");
            ClassHelper.Context.Tickets.Add(tik);
            ClassHelper.Context.SaveChanges();
        }
    }
}
