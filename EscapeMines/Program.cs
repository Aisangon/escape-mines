using System;

namespace EscapeMines
{
    class Program
    {
        static void Main(string[] args)
        {
            EscapeMinesGame escapeMines = new EscapeMinesGame("GameInstructions.txt");
            escapeMines.StartGame();
        }
    }
}
