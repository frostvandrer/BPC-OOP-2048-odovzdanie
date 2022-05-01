using _2048_WPF.Data;
using _2048_WPF.Model;
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

namespace _2048_WPF.View
{
    /// <summary>
    /// Interaction logic for EnterName.xaml
    /// </summary>
    public partial class EnterName : Page
    {
        public EnterName()
        {
            InitializeComponent();
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database(new GameDataClassesDataContext());
            Dictionary<string, int> d = new Dictionary<string, int>();
            string userName = UserNameTextbox.Text;

            // Create user profile
            if (!db.UserExists(userName))
            {
                db.NewUser(userName);
                MessageBox.Show($"Player profile \"{userName}\" created!");
            }

            // Update current player
            db.UpdateCurrentPlayer(userName);

            NavigationService.Navigate(new Uri("View/GameBoard.xaml", UriKind.Relative));
        }
    }
}
