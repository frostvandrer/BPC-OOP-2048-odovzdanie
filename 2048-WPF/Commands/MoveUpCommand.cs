using _2048_WPF.ViewModel;
using _2048_WPF.Model;

namespace _2048_WPF.Commands
{
    internal class MoveUpCommand : CommandBase
    {
        private readonly GameBoardViewModel _gameBoardViewModel;
        private GameBoard _gameBoardOnModify;

        public MoveUpCommand(GameBoardViewModel gameBoardViewModel, GameBoard gameBoard)
        {
            _gameBoardViewModel = gameBoardViewModel;
            _gameBoardOnModify = gameBoard;
        }

        public override void Execute(object? parameter)
        {
            _gameBoardViewModel.Direction = GameBoardViewModel.Directon.Up;
            _gameBoardOnModify.BoardArray2D = MatrixOperations.Move(_gameBoardViewModel);

            // Update ViewModel
            _gameBoardViewModel.GameBoard = _gameBoardOnModify;
        }
    }
}
