using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace addressbook_web_tests
{
    [TestClass]
    public class SquareCircleTests
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(5);
            Square s2 = new Square(10);
            Square s3 = s1; //s3 & s1 point at the same object 

            Assert.AreEqual(s1.Size, 5); //get size for s1 and sompare with 5
            Assert.AreEqual(s2.Size, 10);
            Assert.AreEqual(s3.Size, 5);

            s3.Size = 15;//set a new size for s3

            Assert.AreEqual(s3.Size, 15);

            s2.Colored = true;//set colored true to s2 to check something later


        }

        [TestMethod]
        public void TestMethodCircle()
        {
            Circle c1 = new Circle(5);
            Circle c2 = new Circle(10);
            Circle c3 = c1;

            Assert.AreEqual(c1.Radius, 5);
            Assert.AreEqual(c2.Radius, 10);
            Assert.AreEqual(c3.Radius, 5);

            c3.Radius = 15;

            Assert.AreEqual(c3.Radius, 15);

        }
    }
}
