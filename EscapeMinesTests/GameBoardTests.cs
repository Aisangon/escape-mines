using Microsoft.VisualStudio.TestTools.UnitTesting;
using EscapeMines;

namespace EscapeMinesTests
{
    [TestClass]
    public class GameBoardTests
    {
        private GameBoard gameBoard = new GameBoard();

        [TestMethod]
        public void CanSetBoardSize()
        {
            string boardSize = "5 4";
            gameBoard.boardSize = boardSize;
            gameBoard.SetBoardSize();

            Assert.AreEqual((gameBoard.rows + 1) * (gameBoard.columns + 1), gameBoard.grids.Length);
        }

        [TestMethod]
        public void CanSetMines()
        {
            gameBoard.grids = new string[4, 4];

            string mines = "1,1 1,3 3,3";
            gameBoard.minesList = mines;
            gameBoard.SetMines();

            Assert.IsTrue(gameBoard.grids[1, 1].Contains(GameObjects.Mine));
        }

        [TestMethod]
        public void CanSetExit()
        {
            gameBoard.grids = new string[5, 3];
            string exit = "4 2";
            gameBoard.exit = exit;
            gameBoard.SetExit();

            Assert.IsTrue(gameBoard.grids[4, 2].Contains(GameObjects.Exit));
        }
    }
}
