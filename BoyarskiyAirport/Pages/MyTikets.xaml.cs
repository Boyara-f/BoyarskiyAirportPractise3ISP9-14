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
    /// Логика взаимодействия для MyTikets.xaml
    /// </summary>
    public partial class MyTikets : Page
    {
        public MyTikets()
        {
            InitializeComponent();
            dataGrid.ItemsSource = ClassHelper.Context.Tickets.ToList().Where(i => i.idPassenger == ClassHelper.currentUserID).ToList();
        }
    }
}
