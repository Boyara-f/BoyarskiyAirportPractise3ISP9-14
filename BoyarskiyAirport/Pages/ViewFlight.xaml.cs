using BoyarskiyAirport.DB;
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
    /// Логика взаимодействия для ViewFlight.xaml
    /// </summary>
    public partial class ViewFlight : Page
    {
        public ViewFlight()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            dataGrid.ItemsSource = ClassHelper.Context.Flight.ToList();


           
        }
    }
}
