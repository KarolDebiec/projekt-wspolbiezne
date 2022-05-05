using System;
using NUnit.Framework;
using Logic;
using System.Numerics;

namespace LogicTest
{
    class StorageTest
    {
        [Test]
        public void CreateBallsTest()
        {
            Storage storage = new();
            int emptyStorage = storage.Balls.Count;
            Assert.True(emptyStorage == 0);
            storage.CreateBalls(0);
            Assert.True(emptyStorage == storage.Balls.Count);
            storage.CreateBalls(2);
            Assert.False(emptyStorage == storage.Balls.Count);
            Assert.True(2 == storage.Balls.Count);
            storage.CreateBalls(3);
            Assert.True(5 == storage.Balls.Count);
        }

        [Test]
        public void StopBallsTest()
        {
            Storage storage = new();
            storage.CreateBalls(3);
            Assert.True(3 == storage.Balls.Count);
            storage.StopBalls();
            Assert.True(0 == storage.Balls.Count);
            storage.CreateBalls(2);
            storage.CreateBalls(2);
            Assert.True(4 == storage.Balls.Count);
            storage.StopBalls();
            Assert.True(0 == storage.Balls.Count);
        }

        [Test]
        public void MovingTest()
        {
            Storage storage = new();
            storage.CreateBalls(2);
            float x1 = storage.Balls[0].X;
            float y1 = storage.Balls[0].Y;
            float x2 = storage.Balls[1].X;
            float y2 = storage.Balls[1].Y;
            System.Threading.Thread.Sleep(100);
            Assert.True(x1 == storage.Balls[0].X);
            Assert.True(y1 == storage.Balls[0].Y);
            Assert.True(x2 == storage.Balls[1].X);
            Assert.True(y2 == storage.Balls[1].Y);
            storage.Moving();
            System.Threading.Thread.Sleep(100);
            Assert.True(x1 != storage.Balls[0].X);
            Assert.True(y1 != storage.Balls[0].Y);
            Assert.True(x2 != storage.Balls[1].X);
            Assert.True(y2 != storage.Balls[1].Y);

        }
    }
}
