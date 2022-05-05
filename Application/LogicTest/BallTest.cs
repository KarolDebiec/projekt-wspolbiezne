using System;
using NUnit.Framework;
using Logic;
using System.Numerics;

namespace LogicTest
{
    class BallTest
    {

        [Test]
        public void BallConstructor()
        {
            Ball ball0 = new(2, 3, 5, 2);
            Assert.True(ball0.X == 2);
            Assert.True(ball0.Y == 3);
            float destX = ball0.vectorDestination.X;
            float destY = ball0.vectorDestination.Y;
            Assert.True(destX == 5 || destX == Storage.width - 5 || destY == 5 || destY == Storage.height - 5);
            Assert.False(destX == 3);
            Assert.False(destX == Storage.height - 2);
            Assert.True(ball0.Diameter == 10);// srednica
            Assert.True(ball0.Speed == 2);// predkosc
        }

        [Test]
        public void GenerateDestinationTest()
        {
            Ball ball1 = new(5, 33, 5, 2);//punkt na lewej scianie
            ball1.generateNewVectorDestination();
            Assert.True(ball1.vectorDestination.X > 5 && 
                        ball1.vectorDestination.Y >= 5 && 
                        ball1.vectorDestination.Y <= Storage.height - 5 && 
                        ball1.vectorDestination.X <= Storage.width - 5);
            Ball ball2 = new(33, 5, 5, 2);//punkt na dolnej scianie
            ball2.generateNewVectorDestination();
            Assert.True(ball2.vectorDestination.X >= 5 && 
                        ball2.vectorDestination.Y > 5 && 
                        ball2.vectorDestination.Y <= Storage.height - 5 && 
                        ball2.vectorDestination.X <= Storage.width - 5);
            Ball ball3 = new(Storage.width - 5, 33, 5, 2);//punkt na prawej scianie
            ball3.generateNewVectorDestination();
            Assert.True(ball3.vectorDestination.X >= 5 && 
                        ball3.vectorDestination.Y >= 5 && 
                        ball3.vectorDestination.Y <= Storage.height - 5 && 
                        ball3.vectorDestination.X < Storage.width - 5);
            Ball ball4 = new(33, Storage.height - 5, 5, 2);//punkt na gornej scianie
            ball4.generateNewVectorDestination();
            Assert.True(ball4.vectorDestination.X >= 5 && 
                        ball4.vectorDestination.Y >= 5 && 
                        ball4.vectorDestination.Y < Storage.height - 5 && 
                        ball4.vectorDestination.X <= Storage.width - 5);

        }

        [Test]
        public void UpdatePositionTest()
        {
            Ball ball5 = new(5, 5, 5, 2);
            Vector2 first = ball5.vectorCurrent;
            Vector2 second = new(10, 20);
            ball5.vectorDestination = second;
            ball5.UpdatePosition();
            Assert.AreEqual(System.Math.Ceiling(2f), System.Math.Ceiling(Vector2.Distance(ball5.vectorCurrent, first)));
            Assert.AreEqual(6, System.Math.Ceiling(ball5.X));
            Assert.AreEqual(7, System.Math.Ceiling(ball5.Y));
        }
    }
}
