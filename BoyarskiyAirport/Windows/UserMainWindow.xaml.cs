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
    /// Логика взаимодействия для UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        bool gridStatus = true;

        public UserMainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new Pages.UserFlightView());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.UserFlightView());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.PersonalAccount());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.TicetChosee());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.MyTikets());
        }

        private void BtnHide_Click(object sender, RoutedEventArgs e)
        {

            if (gridStatus)
            {
                geid.ColumnDefinitions.RemoveRange(0, geid.ColumnDefinitions.Count - 1);
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
