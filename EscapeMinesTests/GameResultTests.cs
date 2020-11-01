using EscapeMines;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EscapeMinesTests
{
    [TestClass]
    public class GameResultTests
    {

        [TestMethod]
        [DeploymentItem(@"Game1.txt")]
        public void ShouldFindExit()
        {
            EscapeMinesGame escapeMines = new EscapeMinesGame("Game1.txt");
            escapeMines.StartGame();

            Assert.IsTrue(escapeMines.gameResult.Contains(GameObjects.Exit));
        }

        [TestMethod]
        [DeploymentItem(@"Game2.txt")]
        public void ShouldHitMine()
        {
            EscapeMinesGame escapeMines = new EscapeMinesGame("Game2.txt");
            escapeMines.StartGame();

            Assert.IsTrue(escapeMines.gameResult.Contains(GameObjects.Mine));
        }

        [TestMethod]
        [DeploymentItem(@"Game3.txt")]
        public void ShouldBeInDanger()
        {
            EscapeMinesGame escapeMines = new EscapeMinesGame("Game3.txt");
            escapeMines.StartGame();

            Assert.IsTrue(escapeMines.gameResult.Contains(GameObjects.Danger));
        }
    }
}
