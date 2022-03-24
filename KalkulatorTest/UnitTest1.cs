using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kalkulator;

namespace KalkulatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program p = new Kalkulator.Program();
            Assert.AreEqual(4, p.Add(2,2), 0.001, "Nie dodaje");
            Assert.AreEqual(6, p.Multiply(3, 2), 0.001, "Nie mnoøy");
            Assert.AreNotEqual(6, p.Add(3, 2), 0.001, "èle dodaje");
            Assert.AreNotEqual(10, p.Multiply(5, 3), 0.001, "èle mnoøy");
        }
    }
}
