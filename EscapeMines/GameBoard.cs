using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines
{
    public class GameBoard
    {
        private string[] _gameInstructions;
        public string[,] grids;
        public string boardSize;
        public int rows;
        public int columns;
        public string minesList;
        public string exit;

        public GameBoard() { }

        public GameBoard(string[] gameInstructions)
        {
            _gameInstructions = gameInstructions;

            Initialize();
        }

        private void Initialize()
        {
            try
            {
                if (_gameInstructions.Length > 3)
                {
                    throw new Exception("Game instructions longer than 4 lines.");
                }

                boardSize = _gameInstructions[0];
                SetBoardSize();

                minesList = _gameInstructions[1];
                SetMines();

                exit = _gameInstructions[2];
                SetExit();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public string[,] SetBoardSize()
        {

            string[] splitSize = boardSize.Split();
            columns = int.Parse(splitSize[0]);
            rows = int.Parse(splitSize[1]);

            grids = new string[rows + 1, columns + 1];
            return grids;
        }

        public void SetMines()
        {
            string[] mines = minesList.Split();

            foreach (string mine in mines)
            {
                string[] splitMine = mine.Split(",");
                int sm1 = int.Parse(splitMine[0]);
                int sm2 = int.Parse(splitMine[1]);
                grids[sm1, sm2] = GameObjects.Mine;
            }
        }

        public void SetExit()
        {
            string[] sExit = exit.Split();
            int se1 = int.Parse(sExit[0]);
            int se2 = int.Parse(sExit[1]);
            grids[se1, se2] = GameObjects.Exit;
        }
    }
}
