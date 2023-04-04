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

namespace BoyarskiyAirport.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserFlightView.xaml
    /// </summary>
    public partial class UserFlightView : Page
    {
        public UserFlightView()
        {
            InitializeComponent();

            var quar =
              from f in Helper.ClassHelper.Context.Flight
              join a in ClassHelper.Context.Aircompany on f.idAircompany equals a.id
              join p in ClassHelper.Context.Plane on f.idPlane equals p.id
              join ap in ClassHelper.Context.AirPort on f.idAirPort equals ap.id
              select new
              {
                  IDFliht = f.id,
                  Aircompany = a.AircompanyName,
                  PlaneNumber = p.PlaneModel,
                  Airport = ap.Name,
                  TimeOfTakeOff = f.DateTimeStartGMT,
                  TimeOfArrive = f.DateTimeArrival,
                  FlyStatus = f.StatusIsFly == true ? "Вылетел" : "Ожидает"
              };

            dataGrid.ItemsSource = quar.ToList();
        }
    }
}
