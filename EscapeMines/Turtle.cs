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
            SetInitalPosition();
        }

        private int[,] SetInitalPosition()
        {
            string[] positions = _initialPosition.Split();
            if(positions.Length > 3)
            {
                Console.WriteLine("Could not set turtle position. Instructions too long.");
                return new int[0, 0];
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

            if(facingPos == "E" && direction == "L" || facingPos == "W" && direction == "R")
            {
                facingPos = "N";
            }
            else if(facingPos == "S" && direction == "L" || facingPos == "N" && direction == "R")
            {
                facingPos = "E";
            }
            else if(facingPos == "W" && direction == "L" || facingPos == "E" && direction == "R")
            {
                facingPos = "S";
            }
            else if(facingPos == "N" && direction == "L" || facingPos == "S" && direction == "R")
            {
                facingPos = "W";
            }

            Console.WriteLine($"Turtle rotated to the {(direction == "R" ? "Right" : "Left")}.");

            return facingPos;
        }

        public void Move()
        {
            if(facingPos == "N" && posX >= 1)
            {
                posX -= 1;

                Console.WriteLine("Turtle moved up.");
            }
            else if (facingPos == "E" && posY >= 0)
            {
                posY += 1;

                Console.WriteLine("Turtle moved right.");
            }
            else if(facingPos == "S" && posX >= 0)
            {
                posX += 1;

                Console.WriteLine("Turtle moved down.");
            }
            else if(facingPos == "W" && posY >= 1)
            {
                posY -= 1;

                Console.WriteLine("Turtle moved left.");
            }
            else
            {
                Console.WriteLine("Cannot move, a wall is in front.");
            }
        }
    }
}
