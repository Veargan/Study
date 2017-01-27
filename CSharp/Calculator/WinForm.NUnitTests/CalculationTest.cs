using NUnit.Framework;
using System;
using Calculator;

namespace WinForm.NUnitTests
{
    [TestFixture]
    public class CalculationTest
    {
        private Calculation c;

        [SetUp]
        protected void SetUp()
        {
            c = new Calculation();
        }

        [TearDown]
        public void TearDown()
        {
            c = null;
        }

        [Test]
        public void CalculateShouldReturnCorrectValuePlus()
        {
            Assert.AreEqual("-2", c.Calculate(-6, 4, "+"));
        }

        [Test]
        public void CalculateShouldReturnCorrectValueMinus()
        {
            Assert.AreEqual("4", c.Calculate(6, 2, "-"));
        }

        [Test]
        public void CalculateShouldReturnCorrectValueMultiply()
        {
            Assert.AreEqual("17,5", c.Calculate(3.5, 5, "*"));
        }

        [Test]
        public void CalculateShouldReturnCorrectValueDivide()
        {
            Assert.AreEqual("0,75", c.Calculate(3, 4, "/"));
        }

        [Test]
        public void CalculateShouldRaiseDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => c.Calculate(3, 0, "/"));
        }

        [Test]
        public void CalculateShouldRaiseArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => c.Calculate(0, 0, "/"));
        }
    }
}
