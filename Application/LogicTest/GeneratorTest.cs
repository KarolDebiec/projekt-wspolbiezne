using NUnit.Framework;
using Logic;
using System.Numerics;

namespace LogicTest
{
    class GeneratorTest
    {
        [Test]
        public void generateBallTest()
        {
            Generator g = new();
            Ball b = g.GenerateBall();
            Assert.True(b.X >= 2 + g.Radius && b.X <= Storage.width - g.Radius - 1);
            Assert.True(b.Y >= 2 + g.Radius && b.Y <= Storage.height - g.Radius - 1);
            Assert.True(b.Diameter / 2 == g.Radius);
            Assert.True(b.Speed == g.Speed);
        }
    }
}
