using System.ComponentModel;
using System.Windows.Input;
using _2048_WPF.Model;
using _2048_WPF.Commands;
using System.Windows;
using System;
using _2048_WPF.Data;
using Microsoft.Win32;

namespace _2048_WPF.ViewModel
{
    internal class GameBoardViewModel : INotifyPropertyChanged
    {
        // Fields
        public event PropertyChangedEventHandler? PropertyChanged;
        private Visibility _isGameActive = Visibility.Hidden;
        private int? _movesCount = 0;
        private int? _score = 0;

        public enum Directon
        {
            Right,
            Left,
            Up,
            Down
        }

        private Directon _direction;

        public GameBoard _gameBoard = new GameBoard(new int[4, 4]
        {
            { 0, 0, 0, 0, },
            { 0, 0, 0, 0, },
            { 0, 0, 0, 0, },
            { 0, 0, 0, 0, }
        });

        // Properties
        public GameBoard GameBoard
        {
            get
            {
                return _gameBoard;
            }
            set
            {
                _gameBoard = value;

                // Inform View to reflect the changes on the game board
                OnPropertyChanged(nameof(GameBoard));
            }
        }

        public Directon Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }

        public Visibility IsGameActive
        {
            get
            {
                return _isGameActive;
            }
            set
            {
                _isGameActive = value;
                OnPropertyChanged(nameof(IsGameActive));
            }
        }

        public int? MovesCount
        {
            get
            {
                return _movesCount;
            }
            set
            {
                _movesCount = value;
                OnPropertyChanged(nameof(MovesCount));
            }
        }
        public int? Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public ICommand PlayCommand { get; }
        public ICommand SaveGameCommand { get; }

        // User input handling commands properties
        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; set; }
        public ICommand MoveLeftCommand { get; }
        public ICommand MoveRightCommand { get; }

        public GameBoardViewModel()
        {
            // New game command
            PlayCommand = new DelegateCommand(Play);
            SaveGameCommand = new DelegateCommand(SaveGame);

            // Commands for user keyboard input using delegate
            MoveUpCommand = new DelegateCommand(MoveUp);
            MoveDownCommand = new DelegateCommand(MoveDown);
            MoveLeftCommand = new DelegateCommand(MoveLeft);
            MoveRightCommand = new DelegateCommand(MoveRight);
        }

        private void SaveGame(object obj)
        {
            Database db = new Database(new GameDataClassesDataContext());
            string playerName = db.CurrentPlayer();

            // Debug
            MessageBox.Show($"Saving game for player: {playerName}");

            db.SaveGameBoard(GameBoard.BoardArray2D, playerName, Score, MovesCount);
            db.EnableContinue(playerName);
        }

        private void Play(object obj)
        {
            // TODO create function and find a way to signalize coming from continue page
            Database db = new Database(new GameDataClassesDataContext());
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\2048", true);
            string keyName = "ContinueStatus";

            key = key.OpenSubKey(keyName, true);

            int canContinue = int.Parse(key.GetValue(keyName).ToString());

            string playerName = db.CurrentPlayer();
            int?[] pScore = db.LoadScore(playerName);

            if (canContinue == 1)
            {
                if (db.CanContinue(playerName))
                {
                    GameBoard gb = new GameBoard(db.LoadGameBoard(playerName));
                    IsGameActive = Visibility.Visible;
                    GameBoard = gb;
                    Score = pScore[0];
                    MovesCount = pScore[1];
                    key.SetValue(keyName, 0);
                }
            }
            else
            {
                IsGameActive = Visibility.Visible;
                GameBoard = MatrixOperations.NewGame(this);
                Score = 0;
                MovesCount = 0;
            }
            
            key.Close();
        }

        private void MoveDown(object obj)
        {
            Direction = Directon.Down;
            GameBoard _gameBoardOnModify = GameBoard;

            _gameBoardOnModify.BoardArray2D = MatrixOperations.Move(this);

            // Update ViewModel
            GameBoard = _gameBoardOnModify;
            bool gameOver = MatrixOperations.IsGameOver(this);

            if (gameOver)
            {
                MessageBox.Show("Game Over!");
            }
        }

        private void MoveUp(object obj)
        {
            Direction = Directon.Up;
            GameBoard _gameBoardOnModify = GameBoard;

            _gameBoardOnModify.BoardArray2D = MatrixOperations.Move(this);

            // Update ViewModel
            GameBoard = _gameBoardOnModify;
            bool gameOver = MatrixOperations.IsGameOver(this);

            if (gameOver)
            {
                MessageBox.Show("Game Over!");
            }
        }

        private void MoveLeft(object obj)
        {
            Direction = Directon.Left;
            GameBoard _gameBoardOnModify = GameBoard;

            _gameBoardOnModify.BoardArray2D = MatrixOperations.Move(this);

            // Update ViewModel
            GameBoard = _gameBoardOnModify;
            bool gameOver = MatrixOperations.IsGameOver(this);

            if (gameOver)
            {
                MessageBox.Show("Game Over!");
            }
        }

        private void MoveRight(object obj)
        {
            Direction = Directon.Right;
            GameBoard _gameBoardOnModify = GameBoard;

            _gameBoardOnModify.BoardArray2D = MatrixOperations.Move(this);

            // Update ViewModel
            GameBoard = _gameBoardOnModify;
            bool gameOver = MatrixOperations.IsGameOver(this);

            if (gameOver)
            {
                MessageBox.Show("Game Over!");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
