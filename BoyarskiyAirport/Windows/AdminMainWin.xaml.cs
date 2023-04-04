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
using System.Windows.Shapes;

namespace BoyarskiyAirport.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminMainWin.xaml
    /// </summary>
    public partial class AdminMainWin : Window
    {
        bool gridStatus = true;

       
        public AdminMainWin()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new Pages.ViewFlight());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.ViewFlight());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Helper.ClassHelper.Context.SaveChanges();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.AircompanyPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.TiketPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.PlanePage());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.PassangerPage());
        }

        private void BtnHide_Click(object sender, RoutedEventArgs e)
        {
            
            if (gridStatus)
            {
                 geid.ColumnDefinitions.RemoveRange(0, geid.ColumnDefinitions.Count-1);
                BtnHide.HorizontalAlignment = HorizontalAlignment.Left;
                gridStatus = false;
                BtnHide.Content = "->";
            }
            else
            {
                geid.ColumnDefinitions.Add(new ColumnDefinition());
                geid.ColumnDefinitions.Add(new ColumnDefinition());
                geid.ColumnDefinitions.Add(new ColumnDefinition());
                gridStatus = true;
                BtnHide.Content = "<-";

            }
        }
    }
}
