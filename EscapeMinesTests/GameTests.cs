using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EscapeMinesTests
{
    [TestClass]
    public class GameTests
    {
        private readonly string fileName = "GameInstructions.txt";

        [TestMethod]
        [DeploymentItem(@"GameInstructions.txt")]
        public void CanReadGameIntructions()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            string[] text = File.ReadAllLines(filePath) ?? null;

            Assert.IsNotNull(text);
        }

        [TestMethod]
        public void SetBoardSize()
        {
            string boardSize = "5 4";
            string[] splitSize = boardSize.Split();
            int size1 = int.Parse(splitSize[0]);
            int size2 = int.Parse(splitSize[1]);
            int[,] board = new int[size1, size2];

            Assert.AreEqual(size1 * size2, board.Length);
        }

        [TestMethod]
        public void SetMines()
        {
            string mines = "1,1 1,3 3,3";
            string[] minesList = mines.Split();
            string[,] board = new string[4, 4];

            foreach (string mine in minesList)
            {
                string[] splitMine = mine.Split(",");
                int sm1 = int.Parse(splitMine[0]);
                int sm2 = int.Parse(splitMine[1]);
                board[sm1, sm2] = "mine";
            }

            Assert.IsTrue(board[1, 1].Contains("mine"));
        }

        [TestMethod]
        public void SetExit()
        {
            string[,] board = new string[5, 3];
            string exit = "4 2";
            string[] sExit = exit.Split();
            int se1 = int.Parse(sExit[0]);
            int se2 = int.Parse(sExit[1]);
            board[se1, se2] = "exit";

            Assert.IsTrue(board[4, 2].Contains("exit"));
        }
    }
}
