using _2048_WPF.ViewModel;
using System;
using System.Linq;

namespace _2048_WPF.Model
{
    internal class MatrixOperations
    {
        int counter = 0;

        public static int[] GenerateRandomPosition()
        {
            // Generates random position on the game board for the initial '2' to spawn on
            Random random = new Random();

            int randomRow = random.Next() % 4;
            int randomColumn = random.Next() % 4;

            return new int[2] { randomRow, randomColumn };
        }

        public static GameBoard NewGame(GameBoardViewModel game)
        {
            // Generates the game board with '2' on random position from GenerateRandomPosition()
            int[,] array = game.GameBoard.BoardArray2D;
            int[] randomRC = GenerateRandomPosition();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    array[i, j] = 0;
                }
            }

            array[randomRC[0], randomRC[1]] = 2;

            return new GameBoard(array);
        }

        public static bool NextAvailable(int i, int j, int nextI, int nextJ, int[,] array)
        {
            // Check array boundaries
            if (nextI < 0 || nextJ < 0 || nextI > 3 || nextJ > 3)
            {
                return false;
            }

            // Check if the if the next element in the direction is the same or the next element is not empty
            if (array[i, j] != array[nextI, nextJ] && array[nextI, nextJ] != 0)
            {
                return false;
            }

            return true;
        }

        public static bool AddNextNumber(GameBoardViewModel game)
        {
            int[] randPosition = GenerateRandomPosition();
            int[,] array = game.GameBoard.BoardArray2D;

            if (array[randPosition[0], randPosition[1]] == 0)
            {
                array[randPosition[0], randPosition[1]] = 2;
                return true;
            }

            return false;
        }

        public static bool Compare2DArray(int[,] a, int[,] b)
        {
            bool equal = a.Rank == b.Rank && Enumerable.Range(0, a.Rank).All(dimension =>
                a.GetLength(dimension) == b.GetLength(dimension)) && a.Cast<int>().SequenceEqual(b.Cast<int>());

            return equal;
        }

        public static bool IsGameOver(GameBoardViewModel game)
        {
            int[,] tmpArr = game.GameBoard.BoardArray2D;
            GameBoardViewModel tmp2 = game;

            int[,] array = game.GameBoard.BoardArray2D;
            int counter = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (array[i, j] == 0)
                    {
                        counter++;
                    };
                }
            }

            if (counter == 0)
            {
                tmp2.Direction = GameBoardViewModel.Directon.Up;
                int[,] a = Move(tmp2);

                tmp2.Direction = GameBoardViewModel.Directon.Down;
                int[,] b = Move(tmp2);

                tmp2.Direction = GameBoardViewModel.Directon.Right;
                int[,] c = Move(tmp2);

                tmp2.Direction = GameBoardViewModel.Directon.Left;
                int[,] d = Move(tmp2);

                if (Compare2DArray(a, tmpArr) || Compare2DArray(b, tmpArr) || Compare2DArray(b, tmpArr) || Compare2DArray(b, tmpArr))
                {
                    return true;
                }
            }

            return false;
        }

        public static int[,] Move(GameBoardViewModel game)
        {
            // Counter of moves increases each time a function is called
            game.MovesCount = game.MovesCount + 1;

            int[,] array = game.GameBoard.BoardArray2D;

            // Row and Column Directions
            int[] rowDirection = new int[4] { 1, 0, -1, 0 };

            int[] columnDirection = new int[4] { 0, 1, 0, -1 };

            // Variables for iteration
            int startColumn = 0;
            int startRow = 0;
            int rowStep = 1;
            int columnStep = 1;
            int nextI;
            int nextJ;
            int direction = 0;
            int nextMove;
            int addNew = 0;

            // Change the variables according to direction
            if (game.Direction == GameBoardViewModel.Directon.Right)
            {
                startRow = 3;
                rowStep = -1;
                direction = 1;
            }
            else if (game.Direction == GameBoardViewModel.Directon.Left)
            {
                startColumn = 3;
                columnStep = -1;
                direction = 3;
            }
            else if (game.Direction == GameBoardViewModel.Directon.Up)
            {
                direction = 2;
            }
            else if (game.Direction == GameBoardViewModel.Directon.Down)
            {
                direction = 0;
            }

            do
            {
                nextMove = 0;

                // Iterate over the game board, aggregate and sum the numbers
                for (int i = startRow; i >= 0 && i < 4; i += rowStep)
                {
                    for (int j = startColumn; j >= 0 && j < 4; j += columnStep)
                    {
                        // Find the next number according to direction
                        nextI = i + rowDirection[direction];
                        nextJ = j + columnDirection[direction];

                        if (array[i, j] != 0 && NextAvailable(i, j, nextI, nextJ, array))
                        {
                            int check = array[nextI, nextJ];

                            if (array[nextI, nextJ] == array[i, j])
                            {
                                game.Score = game.Score + array[nextI, nextJ] + array[i, j];
                            }

                            array[nextI, nextJ] += array[i, j];
                            array[i, j] = 0;

                            nextMove = addNew = 1;
                        }
                    }
                }
            } while (nextMove == 1);

            if (addNew == 1)
            {
                bool posFound = false;
                
                while(posFound == false)
                    posFound = AddNextNumber(game);
            }

            return array;
        }

        public static GameBoard RightTransformation(GameBoardViewModel gameBoardViewModel)
        {
            GameBoard gameBoardOnModify = gameBoardViewModel.GameBoard;
            int onPosition;
            bool next = false;

            for (int i = 0; i < gameBoardViewModel.GameBoard.BoardArray2D.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoardViewModel.GameBoard.BoardArray2D.GetLength(1); j++)
                {
                    onPosition = gameBoardOnModify.BoardArray2D[i, j];

                    // Initialize algorithm
                    if (onPosition != 0 && (j + 1) < gameBoardOnModify.BoardArray2D.GetLength(1))
                    {
                        // Check if the [i, 3] position is empty
                        for (int x = gameBoardViewModel.GameBoard.BoardArray2D.GetLength(1) - 1; x > 0; x--)
                        {
                            if (gameBoardOnModify.BoardArray2D[i, x] != 0)
                            {
                                for (int u = gameBoardViewModel.GameBoard.BoardArray2D.GetLength(1) - 1; u > 0; u--)
                                {
                                    if (u - 2 == 0)
                                    {
                                        break;
                                    }

                                    if (gameBoardOnModify.BoardArray2D[i, u - 1] == 0 && gameBoardOnModify.BoardArray2D[i, u - 2] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[i, u - 1] = gameBoardOnModify.BoardArray2D[i, u - 2];
                                        gameBoardOnModify.BoardArray2D[i, u - 2] = 0;

                                    }

                                    if (gameBoardOnModify.BoardArray2D[i, u - 2] == 0 && gameBoardOnModify.BoardArray2D[i, u - 3] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[i, u - 2] = gameBoardOnModify.BoardArray2D[i, u - 3];
                                        gameBoardOnModify.BoardArray2D[i, u - 3] = 0;
                                    }
                                }

                                continue;
                            }

                            if (gameBoardOnModify.BoardArray2D[i, x] == 0)
                            {
                                if (x - 2 < 0)
                                    break;

                                if (gameBoardOnModify.BoardArray2D[i, x - 2] != 0)
                                {
                                    if (gameBoardOnModify.BoardArray2D[i, x - 1] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[i, x] = gameBoardOnModify.BoardArray2D[i, x - 1];
                                        gameBoardOnModify.BoardArray2D[i, x - 1] = gameBoardOnModify.BoardArray2D[i, x - 2];
                                        gameBoardOnModify.BoardArray2D[i, x - 2] = 0;

                                        continue;
                                    }
                                }

                                if (x - 3 < 0)
                                    break;

                                if (gameBoardOnModify.BoardArray2D[i, x - 3] != 0)
                                {
                                    if (gameBoardOnModify.BoardArray2D[i, x - 2] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[i, x] = gameBoardOnModify.BoardArray2D[i, x - 2];
                                        gameBoardOnModify.BoardArray2D[i, x - 1] = gameBoardOnModify.BoardArray2D[i, x - 3];
                                        gameBoardOnModify.BoardArray2D[i, x - 2] = 0;
                                        gameBoardOnModify.BoardArray2D[i, x - 3] = 0;

                                        continue;
                                    }

                                    if (gameBoardOnModify.BoardArray2D[i, x - 1] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[i, x] = gameBoardOnModify.BoardArray2D[i, x - 1];
                                        gameBoardOnModify.BoardArray2D[i, x - 1] = gameBoardOnModify.BoardArray2D[i, x - 3];
                                        gameBoardOnModify.BoardArray2D[i, x - 3] = 0;

                                        continue;
                                    }
                                }

                                if (gameBoardOnModify.BoardArray2D[i, x - 1] != 0)
                                {

                                    gameBoardOnModify.BoardArray2D[i, x] = gameBoardOnModify.BoardArray2D[i, x - 1];
                                    gameBoardOnModify.BoardArray2D[i, x - 1] = 0;

                                    x++;
                                    continue;
                                }

                                gameBoardOnModify.BoardArray2D[i, x] = gameBoardOnModify.BoardArray2D[i, j];
                                gameBoardOnModify.BoardArray2D[i, j] = 0;

                                next = true;
                                break;
                            }
                        }

                        // Chceck if there are two same numbers side by side in the current row and add them together on top right position
                        for (int col = 1; col < 4; col++)
                        {
                            // Check the array bounds
                            if ((j + col) > 3)
                            {
                                break;
                            }

                            if (gameBoardOnModify.BoardArray2D[i, j] == gameBoardOnModify.BoardArray2D[i, j + col])
                            {
                                gameBoardOnModify.BoardArray2D[i, j + col] = gameBoardOnModify.BoardArray2D[i, j] + gameBoardOnModify.BoardArray2D[i, j + col];
                                gameBoardOnModify.BoardArray2D[i, j] = 0;
                            }

                            if (gameBoardOnModify.BoardArray2D[i, j + col] != 0)
                            {
                                break;
                            }
                        }

                        // Check and erase unnecessary spaces between numbers after transformations
                        for (int c = gameBoardViewModel.GameBoard.BoardArray2D.GetLength(1) - 1; c > 0; c--)
                        {
                            if (c + 1 < 0)
                            {
                                break;
                            }

                            if (gameBoardOnModify.BoardArray2D[i, c] == 0)
                            {
                                gameBoardOnModify.BoardArray2D[i, c] = gameBoardOnModify.BoardArray2D[i, c - 1];
                                gameBoardOnModify.BoardArray2D[i, c - 1] = 0;
                            }
                        }

                        if (next)
                        {
                            break;
                        }

                        next = false;
                    }
                }
            }

            return gameBoardOnModify;
        }

        public static GameBoard LeftTransformation(GameBoardViewModel gameBoardViewModel)
        {
            GameBoard gameBoardOnModify = gameBoardViewModel.GameBoard;
            int onPosition;
            bool next = false;

            for (int i = gameBoardViewModel.GameBoard.BoardArray2D.GetLength(0); i > 0; i--)
            {
                for (int j = gameBoardViewModel.GameBoard.BoardArray2D.GetLength(1); j > 0; j--)
                {
                    onPosition = gameBoardOnModify.BoardArray2D[i, j];

                    // Initialize algorithm
                    if (onPosition != 0 && (j + 1) < gameBoardOnModify.BoardArray2D.GetLength(1))
                    {
                        // Check if the [i, 3] position is empty
                        for (int x = gameBoardViewModel.GameBoard.BoardArray2D.GetLength(1) - 1; x > 0; x--)
                        {
                            if (gameBoardOnModify.BoardArray2D[i, x] != 0)
                            {
                                for (int u = gameBoardViewModel.GameBoard.BoardArray2D.GetLength(1) - 1; u > 0; u--)
                                {
                                    if (u - 2 == 0)
                                    {
                                        break;
                                    }

                                    if (gameBoardOnModify.BoardArray2D[i, u - 1] == 0 && gameBoardOnModify.BoardArray2D[i, u - 2] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[i, u - 1] = gameBoardOnModify.BoardArray2D[i, u - 2];
                                        gameBoardOnModify.BoardArray2D[i, u - 2] = 0;

                                    }

                                    if (gameBoardOnModify.BoardArray2D[i, u - 2] == 0 && gameBoardOnModify.BoardArray2D[i, u - 3] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[i, u - 2] = gameBoardOnModify.BoardArray2D[i, u - 3];
                                        gameBoardOnModify.BoardArray2D[i, u - 3] = 0;
                                    }
                                }

                                continue;
                            }

                            if (gameBoardOnModify.BoardArray2D[i, x] == 0)
                            {
                                if (x - 2 < 0)
                                    break;

                                if (gameBoardOnModify.BoardArray2D[i, x - 2] != 0)
                                {
                                    if (gameBoardOnModify.BoardArray2D[i, x - 1] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[i, x] = gameBoardOnModify.BoardArray2D[i, x - 1];
                                        gameBoardOnModify.BoardArray2D[i, x - 1] = gameBoardOnModify.BoardArray2D[i, x - 2];
                                        gameBoardOnModify.BoardArray2D[i, x - 2] = 0;

                                        continue;
                                    }
                                }

                                if (x - 3 < 0)
                                    break;

                                if (gameBoardOnModify.BoardArray2D[i, x - 3] != 0)
                                {
                                    if (gameBoardOnModify.BoardArray2D[i, x - 2] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[i, x] = gameBoardOnModify.BoardArray2D[i, x - 2];
                                        gameBoardOnModify.BoardArray2D[i, x - 1] = gameBoardOnModify.BoardArray2D[i, x - 3];
                                        gameBoardOnModify.BoardArray2D[i, x - 2] = 0;
                                        gameBoardOnModify.BoardArray2D[i, x - 3] = 0;

                                        continue;
                                    }

                                    if (gameBoardOnModify.BoardArray2D[i, x - 1] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[i, x] = gameBoardOnModify.BoardArray2D[i, x - 1];
                                        gameBoardOnModify.BoardArray2D[i, x - 1] = gameBoardOnModify.BoardArray2D[i, x - 3];
                                        gameBoardOnModify.BoardArray2D[i, x - 3] = 0;

                                        continue;
                                    }
                                }

                                if (gameBoardOnModify.BoardArray2D[i, x - 1] != 0)
                                {

                                    gameBoardOnModify.BoardArray2D[i, x] = gameBoardOnModify.BoardArray2D[i, x - 1];
                                    gameBoardOnModify.BoardArray2D[i, x - 1] = 0;

                                    x++;
                                    continue;
                                }

                                gameBoardOnModify.BoardArray2D[i, x] = gameBoardOnModify.BoardArray2D[i, j];
                                gameBoardOnModify.BoardArray2D[i, j] = 0;

                                next = true;
                                break;
                            }
                        }

                        // Chceck if there are two same numbers side by side in the current row and add them together on top right position
                        for (int col = 1; col < 4; col++)
                        {
                            // Check the array bounds
                            if ((j + col) > 3)
                            {
                                break;
                            }

                            if (gameBoardOnModify.BoardArray2D[i, j] == gameBoardOnModify.BoardArray2D[i, j + col])
                            {
                                gameBoardOnModify.BoardArray2D[i, j + col] = gameBoardOnModify.BoardArray2D[i, j] + gameBoardOnModify.BoardArray2D[i, j + col];
                                gameBoardOnModify.BoardArray2D[i, j] = 0;
                            }

                            if (gameBoardOnModify.BoardArray2D[i, j + col] != 0)
                            {
                                break;
                            }
                        }

                        // Check and erase unnecessary spaces between numbers after transformations
                        for (int c = gameBoardViewModel.GameBoard.BoardArray2D.GetLength(1) - 1; c > 0; c--)
                        {
                            if (c + 1 < 0)
                            {
                                break;
                            }

                            if (gameBoardOnModify.BoardArray2D[i, c] == 0)
                            {
                                gameBoardOnModify.BoardArray2D[i, c] = gameBoardOnModify.BoardArray2D[i, c - 1];
                                gameBoardOnModify.BoardArray2D[i, c - 1] = 0;
                            }
                        }

                        if (next)
                        {
                            break;
                        }

                        next = false;
                    }
                }
            }

            return gameBoardOnModify;
        }

        public static GameBoard DownTransformation(GameBoardViewModel gameBoardViewModel)
        {
            GameBoard gameBoardOnModify = gameBoardViewModel.GameBoard;
            int onPosition;
            bool next = false;

            for (int i = 0; i < gameBoardViewModel.GameBoard.BoardArray2D.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoardViewModel.GameBoard.BoardArray2D.GetLength(1); j++)
                {
                    onPosition = gameBoardOnModify.BoardArray2D[j, i];

                    // Initialize algorithm
                    if (onPosition != 0 && (j + 1) < gameBoardOnModify.BoardArray2D.GetLength(1))
                    {
                        // Check if the [i, 3] position is empty
                        for (int x = gameBoardViewModel.GameBoard.BoardArray2D.GetLength(1) - 1; x > 0; x--)
                        {
                            if (gameBoardOnModify.BoardArray2D[x, i] != 0)
                            {
                                for (int u = gameBoardViewModel.GameBoard.BoardArray2D.GetLength(1) - 1; u > 0; u--)
                                {
                                    if (u - 2 == 0)
                                    {
                                        break;
                                    }

                                    if (gameBoardOnModify.BoardArray2D[u - 1, i] == 0 && gameBoardOnModify.BoardArray2D[u - 2, i] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[u - 1, i] = gameBoardOnModify.BoardArray2D[u - 2, i];
                                        gameBoardOnModify.BoardArray2D[u - 2, i] = 0;

                                    }

                                    if (gameBoardOnModify.BoardArray2D[u - 2, i] == 0 && gameBoardOnModify.BoardArray2D[u - 3, i] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[u - 2, i] = gameBoardOnModify.BoardArray2D[u - 3, i];
                                        gameBoardOnModify.BoardArray2D[u - 3, i] = 0;
                                    }
                                }

                                continue;
                            }

                            if (gameBoardOnModify.BoardArray2D[x, i] == 0)
                            {
                                if (x - 2 < 0)
                                    break;

                                if (gameBoardOnModify.BoardArray2D[x - 2, i] != 0)
                                {
                                    if (gameBoardOnModify.BoardArray2D[x - 1, i] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[x, i] = gameBoardOnModify.BoardArray2D[x - 1, i];
                                        gameBoardOnModify.BoardArray2D[x - 1, i] = gameBoardOnModify.BoardArray2D[x - 2, i];
                                        gameBoardOnModify.BoardArray2D[x - 2, i] = 0;

                                        continue;
                                    }
                                }

                                if (x - 3 < 0)
                                    break;

                                if (gameBoardOnModify.BoardArray2D[x - 3, i] != 0)
                                {
                                    if (gameBoardOnModify.BoardArray2D[x - 2, i] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[x, i] = gameBoardOnModify.BoardArray2D[x - 2, i];
                                        gameBoardOnModify.BoardArray2D[x - 1, i] = gameBoardOnModify.BoardArray2D[x - 3, i];
                                        gameBoardOnModify.BoardArray2D[x - 2, i] = 0;
                                        gameBoardOnModify.BoardArray2D[x - 3, i] = 0;

                                        continue;
                                    }

                                    if (gameBoardOnModify.BoardArray2D[x - 1, i] != 0)
                                    {
                                        gameBoardOnModify.BoardArray2D[x, i] = gameBoardOnModify.BoardArray2D[x - 1, i];
                                        gameBoardOnModify.BoardArray2D[x - 1, i] = gameBoardOnModify.BoardArray2D[x - 3, i];
                                        gameBoardOnModify.BoardArray2D[x - 3, i] = 0;

                                        continue;
                                    }

                                }

                                if (gameBoardOnModify.BoardArray2D[x - 1, i] != 0)
                                {

                                    gameBoardOnModify.BoardArray2D[x, i] = gameBoardOnModify.BoardArray2D[x - 1, i];
                                    gameBoardOnModify.BoardArray2D[x - 1, i] = 0;

                                    x++;
                                    continue;

                                }

                                gameBoardOnModify.BoardArray2D[x, i] = gameBoardOnModify.BoardArray2D[j, i];
                                gameBoardOnModify.BoardArray2D[j, i] = 0;

                                next = true;
                                break;
                            }
                        }

                        // Check and erase unnecessary spaces between numbers after transformations
                        for (int c = gameBoardViewModel.GameBoard.BoardArray2D.GetLength(1) - 1; c > 0; c--)
                        {
                            if (c + 1 < 0)
                            {
                                break;
                            }

                            if (gameBoardOnModify.BoardArray2D[c, i] == 0)
                            {
                                gameBoardOnModify.BoardArray2D[c, i] = gameBoardOnModify.BoardArray2D[c - 1, i];
                                gameBoardOnModify.BoardArray2D[c - 1, i] = 0;
                            }
                        }


                        // Chceck if there are two same numbers side by side in the current row and add them together on top right position
                        for (int col = 1; col < 4; col++)
                        {
                            // Check the array bounds
                            if ((j + col) > 3)
                            {
                                break;
                            }

                            /*if (gameBoardOnModify.BoardArray2D[j, i] == 0 && gameBoardOnModify.BoardArray2D[j + col, i] == 0)
                            {
                                break;
                            }*/

                            if (gameBoardOnModify.BoardArray2D[j, i] == gameBoardOnModify.BoardArray2D[j + col, i])
                            {
                                gameBoardOnModify.BoardArray2D[j + col, i] = gameBoardOnModify.BoardArray2D[j, i] + gameBoardOnModify.BoardArray2D[j + col, i];
                                gameBoardOnModify.BoardArray2D[j, i] = 0;
                            }
                        }

                        if (next)
                        {
                            break;
                        }

                        next = false;
                    }
                }
            }

            return gameBoardOnModify;
        }
    }
}
