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
using _2048_WPF;

namespace _2048_WPF.View
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();


        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/EnterName.xaml", UriKind.Relative));
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/Statistics.xaml", UriKind.Relative));
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/Continue.xaml", UriKind.Relative));
        }
    }
}
