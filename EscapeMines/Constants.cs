using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines
{
    public class Direction
    {
        public const string Left = "L";
        public const string Right = "R";
    }

    public class Coordinates
    {
        public const string North = "N";
        public const string South = "S";
        public const string East = "E";
        public const string West = "W";
    }

    public class Action
    {
        public const string Move = "M";
    }

    public class GameObjects
    {
        public const string Turtle = "Turtle";
        public const string Mine = "Mine";
        public const string Exit = "Exit";
    }

}
