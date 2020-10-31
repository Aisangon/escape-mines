using System;

namespace EscapeMines
{
    class Program
    {
        static void Main(string[] args)
        {
            EscapeMinesGame game = new EscapeMinesGame("GameInstructions.txt");
            game.Start();
        }
    }
}
