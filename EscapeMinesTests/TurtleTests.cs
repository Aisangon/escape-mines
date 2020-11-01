using Microsoft.VisualStudio.TestTools.UnitTesting;
using EscapeMines;

namespace EscapeMinesTests
{
    [TestClass]
    public class TurtleTests
    {
        private Turtle turtle = new Turtle();

        [TestMethod]
        public void CanSetInitialPosition()
        {
            turtle._initialPosition = "0 1 N";
            turtle.SetInitalPosition();

            Assert.AreEqual(turtle.posX, 1);
            Assert.AreEqual(turtle.posY, 0);
            Assert.AreEqual(turtle.facingPos, Coordinates.North);
        }

        [TestMethod]
        public void CanRotate()
        {
            turtle.facingPos = Coordinates.West;
            turtle.Rotate(Direction.Left);

            Assert.IsTrue(turtle.facingPos.Equals(Coordinates.South));
        }

        [TestMethod]
        public void CanNotEscapeBoundaries()
        {
            turtle.posY = 5;
            turtle.facingPos = Coordinates.East;

            Assert.IsFalse(turtle.CanMove(5, 4));
        }

        [TestMethod]
        public void CanMoveTurtle()
        {
            turtle.posX = 3;
            turtle.posY = 1;
            turtle.facingPos = Coordinates.North;
            turtle.Move();
            turtle.Move();

            Assert.AreEqual(turtle.posX, 1);
        }
    }
}
