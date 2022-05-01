using System.Windows.Controls;
using _2048_WPF.ViewModel;

namespace _2048_WPF.View
{
    /// <summary>
    /// Interaction logic for GameBoard.xaml
    /// </summary>
    public partial class GameBoard : Page
    {
        public GameBoard()
        {
            InitializeComponent();
            DataContext = new GameBoardViewModel();
        }
    }
}
