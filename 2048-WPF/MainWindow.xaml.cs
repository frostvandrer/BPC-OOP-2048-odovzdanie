using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using _2048_WPF.Model;
using _2048_WPF.View;
using _2048_WPF.ViewModel;
using Microsoft.Win32;

namespace _2048_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            string keyName = "ContinueStatus";
            int value = 0;

            key.CreateSubKey("2048");
            key = key.OpenSubKey("2048", true);

            key.CreateSubKey(keyName);
            key = key.OpenSubKey(keyName, true);

            key.SetValue(keyName, value);

            key.Close();

            // Showing the welcome menu and setting its window properties
            MainFrame.Navigate(new Uri("View/WelcomePage.xaml", UriKind.Relative));

            // TODO: Use styles on game board
        }
    }
}
