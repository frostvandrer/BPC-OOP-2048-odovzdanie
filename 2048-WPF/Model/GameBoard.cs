namespace _2048_WPF.Model
{
    internal class GameBoard
    {
        private int[,] _boardArray2D = new int[4,4];
        private string[] _boardArray1D = new string[16];

        public int[,] BoardArray2D
        {
            get
            {
                return _boardArray2D;
            }
            set
            {
                _boardArray2D = value;
            }
        }

        public string[] BoardArray1D
        {
            // Returns a 1D array coverted from 2D array of the gameboard for the easier representation in WPF binding
            get
            {
                int write = 0;
                int onPosition;

                for (int i = 0; i< _boardArray2D.GetLength(0); i++)
                {
                    for (int j = 0; j < _boardArray2D.GetLength(1); j++)
                    {
                         onPosition = _boardArray2D[i, j];

                        // Do not display zero values
                        if (onPosition == 0)
                        {
                            _boardArray1D[write++] = "";
                        }
                        else
                        {
                            _boardArray1D[write++] = onPosition.ToString();
                        }
                    }
                }

                return _boardArray1D;
            }
        }

        public int Score { get; set; }

        public int MovesCount { get; set; }

        public GameBoard(int[,] boardArray2D)
        {
            BoardArray2D = boardArray2D;
        }
    }
}
