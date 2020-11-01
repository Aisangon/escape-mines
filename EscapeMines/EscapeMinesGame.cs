using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EscapeMines
{
    public class EscapeMinesGame
    {
        private string _fileName;
        public string[] textFile;
        public string gameResult;
        private GameBoard gameBoard;
        private Turtle turtle;

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
            textFile = File.ReadAllLines(filePath);
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

            gameBoard.grids[turtle.posX, turtle.posY] = GameObjects.Turtle;
        }

        public void StartGame()
        {
            for (int i = 4; i < textFile.Length; i++)
            {
                Console.WriteLine($"Next intructions: {textFile[i]}");
                string[] line = textFile[i].Split();

                foreach (var letter in line)
                {
                    if(letter.Contains(Direction.Left) || letter.Contains(Direction.Right))
                    {
                        turtle.Rotate(letter);
                    }
                    else if (letter.Contains(Action.Move))
                    {
                        if(!turtle.CanMove(gameBoard.rows, gameBoard.columns))
                        {
                            Console.WriteLine("Turtle hit a wall, can't move any further.");
                            continue;
                        }

                        turtle.Move();
                    }

                    Console.WriteLine($"Turtle current position x: {turtle.posX}, y: {turtle.posY}, facing: {turtle.facingPos}");
                }
            }

            string turtlePosition = gameBoard.grids[turtle.posX, turtle.posY];
            string result = $"Still in {GameObjects.Danger}. Turtle has not hit a mine or found the exit.";

            if (!string.IsNullOrEmpty(turtlePosition))
            {
                if (turtlePosition.Contains(GameObjects.Mine))
                {
                    result = $"Oh! Turtle hit a {GameObjects.Mine}.";
                }
                else if (turtlePosition.Contains(GameObjects.Exit))
                {
                    result = $"Success! Turtle found the {GameObjects.Exit}.";
                }
            }

            Console.WriteLine($"Result: {result}");

            gameResult = result;
        }
    }
}
