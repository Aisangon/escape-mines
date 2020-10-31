using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EscapeMines
{
    class EscapeMinesGame
    {
        private string _fileName;
        private string[] textFile;
        private GameBoard gameBoard;
        private Turtle turtle;
        private const string Left = "L";
        private const string Right = "R";
        private const string Move = "M";

        public EscapeMinesGame(string fileName)
        {
            _fileName = fileName;
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                ReadGameInstructions();
                StartBoard();
                StartPlayer();

                Console.WriteLine("Game initialized.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ReadGameInstructions()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, _fileName);
            textFile = File.ReadAllLines(filePath) ?? null;
        }

        private void StartBoard()
        {
            string[] boardInstructions = new[] { textFile[0], textFile[1], textFile[2] };
            gameBoard = new GameBoard(boardInstructions);
        }

        private void StartPlayer()
        {
            string turtleInstructions = textFile[3];
            turtle = new Turtle(turtleInstructions);

            gameBoard.grids[turtle.posX, turtle.posY] = "turtle";
        }

        public void Start()
        {
            for (int i = 4; i < textFile.Length; i++)
            {
                Console.WriteLine(textFile[i]);
                string[] line = textFile[i].Split();

                foreach (var letter in line)
                {
                    if(letter.Contains(Left) || letter.Contains(Right))
                    {
                        turtle.Rotate(letter);
                    }
                    else if (letter.Contains(Move))
                    {
                        turtle.Move();
                    }

                    Console.WriteLine($"Turtle current position x: {turtle.posX}, y: {turtle.posY}, facing: {turtle.facingPos}");
                }
            }

            if (gameBoard.grids[turtle.posX, turtle.posY] != null)
            {
                if (gameBoard.grids[turtle.posX, turtle.posY].Contains("mine"))
                {
                    Console.WriteLine("Oh! Turtle hit a mine.");
                }
                else if (gameBoard.grids[turtle.posX, turtle.posY].Contains("exit"))
                {
                    Console.WriteLine("Success! Turtle found the exit.");
                }
            }

            Console.WriteLine("Still in danger. Turtle has not hit a mine or found the exit.");
        }
    }
}
