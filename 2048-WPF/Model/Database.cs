using _2048_WPF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2048_WPF.Model
{
    internal class Database
    {
        public GameDataClassesDataContext Dc { get; set; }

        public Database(GameDataClassesDataContext dc)
        {
            Dc = dc;
        }

        public Dictionary<string, string> AllStats()
        {
            Dictionary<string, string> all = new Dictionary<string, string>();

            foreach (Player p in Dc.Players)
            {
                string pSuccess = $"{p.PlayerScore} points in {p.PlayerMoves} moves";
                all.Add(p.PlayerName, pSuccess);
            }

            return all;
        }

        public int LatestID()
        {
            return Dc.Players.Count();
        }

        public void NewUser(string playerName)
        {
            int? id = LatestID();

            Dc.Players.InsertOnSubmit(new Player()
            {
                Id = (int)++id,
                PlayerName = playerName,
                PlayerScore = 0,
                PlayerMoves = 0,
                GameBoard = ""
            });

            Dc.SubmitChanges();
        }

        public bool UserExists(string playerName)
        {
            return Dc.Players.Any(p => p.PlayerName == playerName);
        }

        public void UpdateCurrentPlayer(string playerName)
        {
            if (Dc.GameStatus.Any())
            {
                GameStatus gs = Dc.GameStatus.Where(p => p.CurrentPlayer != null).FirstOrDefault();
                gs.CurrentPlayer = playerName;
            }
            else
            {
                Dc.GameStatus.InsertOnSubmit(new GameStatus()
                {
                    Id = 0,
                    CurrentPlayer = playerName
                });
            }

            Dc.SubmitChanges();
        }

        public string CurrentPlayer()
        {
            string currentPlayer = (from GameStatus in Dc.GameStatus select GameStatus.CurrentPlayer).FirstOrDefault().ToString();

            return currentPlayer;
        }

        int[] GameBoard1D(int[,] arrayIn)
        {
            int[] arrayOut = new int[16];
            int write = 0;

            for (int i = 0; i < arrayIn.GetLength(0); i++)
            {
                for (int j = 0; j < arrayIn.GetLength(1); j++)
                {
                    arrayOut[write++] = arrayIn[i, j];
                }
            }

            return arrayOut;
        }

        public void SaveGameBoard(int[,] array2D, string playerName, int? score, int? movesCount)
        {
            StringBuilder sb = new StringBuilder();
            Player p = Dc.Players.Where(p => p.PlayerName == playerName).FirstOrDefault();

            int[] array = GameBoard1D(array2D);

            foreach (int i in array)
            {
                sb.Append(i.ToString() + "|");
            }

            string gbString = sb.ToString().Remove(sb.ToString().Length - 1);
            MessageBox.Show(gbString);
            p.GameBoard = gbString;
            p.PlayerScore = score;
            p.PlayerMoves = movesCount;

            Dc.SubmitChanges();
        }

        public int[,] LoadGameBoard(string playerName)
        {
            int[,] array = new int[4, 4];

            Player p = Dc.Players.Where(p => p.PlayerName == playerName).FirstOrDefault();
            string gbString = p.GameBoard;
            string[] arr = gbString.Split('|');

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    array[i, j] = Int32.Parse(arr[(j ) + (i * 4)]);
                }
            }

            return array;
        }

        public int?[] LoadScore(string playerName)
        {
            int? [] scoreArr = new int?[2];
            Player p = Dc.Players.Where(p => p.PlayerName == playerName).FirstOrDefault();

            scoreArr[0] = p.PlayerScore;
            scoreArr[1] = p.PlayerMoves;

            return scoreArr;
        }

        public void EnableContinue(string playerName)
        {
            if (UserExists(playerName))
            {
                GameStatus gs = Dc.GameStatus.Where(p => p.CurrentPlayer == playerName).FirstOrDefault();
                gs.ContinueFlag = 1;
            }

            Dc.SubmitChanges();
        }

        public bool CanContinue(string playerName)
        {
            return Dc.GameStatus.Any(p => p.CurrentPlayer == playerName && p.ContinueFlag == 1);
        }
    }
}
