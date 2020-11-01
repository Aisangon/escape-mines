using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using EscapeMines;

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
            EscapeMinesGame escapeMines = new EscapeMinesGame(fileName);
            Assert.IsNotNull(escapeMines.textFile);
        }
    }
}
