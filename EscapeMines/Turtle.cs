using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines
{
    class Turtle
    {
        private string _initialPosition;
        public int posX;
        public int posY;
        public string facingPos;

        public Turtle(string initalPoition)
        {
            _initialPosition = initalPoition;

            Initialize();
        }

        private void Initialize()
        {
            try
            {
                SetInitalPosition();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private int[,] SetInitalPosition()
        {
            string[] positions = _initialPosition.Split();
            if(positions.Length > 3)
            {
                Console.WriteLine("Could not set turtle position. Instructions too long.");
                return null;
            }

            posY = int.Parse(positions[0]);
            posX = int.Parse(positions[1]);
            facingPos = positions[2];

            Console.WriteLine($"Turtle initial position x: {posX}, y: {posY}, facing: {facingPos}");

            return new int[posX, posY];
        }

        public int[,] GetCurrentPosition()
        {
            return new int[posX, posY];
        }

        public string Isfacing()
        {
            return facingPos;
        }

        public string Rotate(string direction)
        {
            if(string.IsNullOrEmpty(facingPos))
            {
                return string.Empty;
            }

            if(
                facingPos == Coordinates.East && direction == Direction.Left || 
                facingPos == Coordinates.West && direction == Direction.Right
            )
            {
                facingPos = Coordinates.North;
            }
            else if(
                facingPos == Coordinates.South && direction == Direction.Left || 
                facingPos == Coordinates.North && direction == Direction.Right
            )
            {
                facingPos = Coordinates.East;
            }
            else if(
                facingPos == Coordinates.West && direction == Direction.Left || 
                facingPos == Coordinates.East && direction == Direction.Right
            )
            {
                facingPos = Coordinates.South;
            }
            else if(
                facingPos == Coordinates.North && direction == Direction.Left || 
                facingPos == Coordinates.South && direction == Direction.Right
            )
            {
                facingPos = Coordinates.West;
            }

            Console.WriteLine($"Turtle rotated to the {(direction == Direction.Right ? "right" : "left")}.");

            return facingPos;
        }

        public bool CanMove(int rows, int columns)
        {
            if (posX == 0 && facingPos == Coordinates.North || posX == columns && facingPos == Coordinates.South)
            {
                return false;
            }

            if (posY == 0 && facingPos == Coordinates.West || posY == rows && facingPos == Coordinates.East)
            {
                return false;
            }

            return true;
        }

        public void Move()
        {
            if(facingPos == Coordinates.North && posX >= 1)
            {
                posX -= 1;

                Console.WriteLine("Turtle moved up.");
            }
            else if (facingPos == Coordinates.South && posX >= 0)
            {
                posX += 1;

                Console.WriteLine("Turtle moved down.");
            }
            else if (facingPos == Coordinates.West && posY >= 1)
            {
                posY -= 1;

                Console.WriteLine("Turtle moved left.");
            }
            else if (facingPos == Coordinates.East && posY >= 0)
            {
                posY += 1;

                Console.WriteLine("Turtle moved right.");
            }
        }
    }
}
