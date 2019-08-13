using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParagonPingSystem;

namespace ParagonPingSystemTests {

    [TestClass]
    public class LineSelectorTests {

        [TestMethod]
        public void MathTest() {
            var origin = new Point(300, 350);

            Assert.AreEqual(1, Helpers.GetQuadrant(origin, new Point(320, 350)));
            Assert.AreEqual(0, Helpers.GetQuadrant(origin, new Point(320, 200)));
            Assert.AreEqual(3, Helpers.GetQuadrant(origin, new Point(200, 350)));
            Assert.AreEqual(2, Helpers.GetQuadrant(origin, new Point(320, 370)));
            Assert.AreEqual(2, Helpers.GetQuadrant(origin, new Point(300, 400)));
            Assert.AreEqual(0, Helpers.GetQuadrant(origin, new Point(280, 330)));
        }
    }
}