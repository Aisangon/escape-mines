using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines
{
    class GameBoard
    {
        private int _rows;
        private int _columns;
        public string[,] _board;

        public GameBoard(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
        }

        public string[,] SetBoardSize()
        {
            _board = new string[_rows, _columns];
            return _board;
        }

        public void SetMines(string minesInstructions)
        {
            string mines = minesInstructions;
            string[] minesList = mines.Split();

            foreach (string mine in minesList)
            {
                string[] splitMine = mine.Split(",");
                int sm1 = int.Parse(splitMine[0]);
                int sm2 = int.Parse(splitMine[1]);
                _board[sm1, sm2] = "mine";
            }
        }

        public void SetExit(int x, int y)
        {
            _board[x, y] = "exit";
        }
    }
}
