using _2048_WPF.Data;
using _2048_WPF.Model;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace _2048_WPF.View
{
    /// <summary>
    /// Interaction logic for Continue.xaml
    /// </summary>
    public partial class Continue : Page
    {
        public Continue()
        {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database(new GameDataClassesDataContext());
            string playerName = UserNameTextbox.Text;

            // Update current player
            db.UpdateCurrentPlayer(playerName);
            
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\2048", true);
            string keyName = "ContinueStatus";
            int value = 1;

            key = key.OpenSubKey(keyName, true);
            key.SetValue(keyName, value);
            key.Close();

            NavigationService.Navigate(new Uri("View/GameBoard.xaml", UriKind.Relative));
        }
    }
}
