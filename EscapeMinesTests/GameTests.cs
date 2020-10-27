using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
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

            Assert.IsTrue(minesList.Length > 0);
        }
    }
}
