using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines
{
    class GameBoard
    {
        private string[] _gameInstructions;
        public string[,] grids;
        private string boardSize;
        private int rows;
        private int columns;
        private string minesList;
        private string exit;

        public GameBoard(string[] gameInstructions)
        {
            _gameInstructions = gameInstructions;

            Initialize();
        }

        public string[,] SetBoardSize()
        {

            string[] splitSize = boardSize.Split();
            rows = int.Parse(splitSize[0]);
            columns = int.Parse(splitSize[1]);

            grids = new string[rows, columns];
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
                grids[sm1, sm2] = "mine";
            }
        }

        public void SetExit()
        {
            string[] sExit = exit.Split();
            int se1 = int.Parse(sExit[0]);
            int se2 = int.Parse(sExit[1]);
            grids[se1, se2] = "exit";
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
    }
}
