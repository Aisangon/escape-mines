using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines
{
    class Turtle
    {
        private int _startPosx;
        private int _startPosy;
        private string _facingPos;

        public Turtle(int startPosx, int startPosy, string facingPos)
        {
            _startPosx = startPosx;
            _startPosy = startPosy;
            _facingPos = facingPos;
        }

        public int[,] SetPosition()
        {
            return new int[_startPosx, _startPosy];
        }
    }
}
