using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void ChangeBallPosTest()
        {
            Logger log = new Logger("LogTest.log");
            Ball ball = new Ball(1,log);

            double positionX = ball.posX;
            double positionY = ball.posY;
            ball.MovePos();
            Assert.AreEqual(ball.posX, positionX + ball.offsetX);
            Assert.AreEqual(ball.posY, positionY + ball.offsetY);
        }

        [TestMethod]
        public void RandomPosAndMoveTest()
        {
            Logger log = new Logger("LogTest.log");
            Ball ball = new Ball(1,log);

            Assert.IsTrue(ball.posX <= 500 && ball.posX >= 1);
            Assert.IsTrue(ball.posY <= 500 && ball.posY >= 1);

            Assert.IsTrue(ball.offsetX <= 5 && ball.offsetX >= 2);
            Assert.IsTrue(ball.offsetY <= 5 && ball.offsetY >= 2);
        }
    }
}