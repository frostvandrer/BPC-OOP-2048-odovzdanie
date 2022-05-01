using System.Windows;
using _2048_WPF.ViewModel;
using _2048_WPF.Model;

namespace _2048_WPF.Commands
{
    internal class NewGameCommand : CommandBase
    {
        private readonly GameBoardViewModel _gameBoardViewModel;
        private GameBoard _gameBoardOnModify;

        public NewGameCommand(GameBoardViewModel gameBoardViewModel, GameBoard gameBoard)
        {
            _gameBoardViewModel = gameBoardViewModel;
            _gameBoardOnModify = gameBoard;
        }

        public override void Execute(object? parameter)
        {
            _gameBoardViewModel.IsGameActive = Visibility.Visible;
            _gameBoardViewModel.GameBoard = MatrixOperations.NewGame(_gameBoardViewModel);
        }
    }
}
