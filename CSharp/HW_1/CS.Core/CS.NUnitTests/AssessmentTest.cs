using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.Core;

namespace NUnitTests
{
    [TestFixture]
    public class AssessmentTest
    {
        private Assessment a;

        [SetUp]
        protected void SetUp()
        {
            a = new Assessment();
        }

        [Test]
        public void CalculationShouldReturnCorrectValueF1()
        {
            Assert.AreEqual("F", a.Calculation(0));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueF2()
        {
            Assert.AreEqual("F", a.Calculation(19));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueF3()
        {
            Assert.AreEqual("F", a.Calculation(10));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueE1()
        {
            Assert.AreEqual("E", a.Calculation(20));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueE2()
        {
            Assert.AreEqual("E", a.Calculation(39));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueE3()
        {
            Assert.AreEqual("E", a.Calculation(30));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueD1()
        {
            Assert.AreEqual("D", a.Calculation(40));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueD2()
        {
            Assert.AreEqual("D", a.Calculation(59));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueD3()
        {
            Assert.AreEqual("D", a.Calculation(50));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueC1()
        {
            Assert.AreEqual("C", a.Calculation(60));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueC2()
        {
            Assert.AreEqual("C", a.Calculation(74));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueC3()
        {
            Assert.AreEqual("C", a.Calculation(66));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueB1()
        {
            Assert.AreEqual("B", a.Calculation(75));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueB2()
        {
            Assert.AreEqual("B", a.Calculation(89));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueB3()
        {
            Assert.AreEqual("B", a.Calculation(83));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueA1()
        {
            Assert.AreEqual("A", a.Calculation(90));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueA2()
        {
            Assert.AreEqual("A", a.Calculation(100));
        }

        [Test]
        public void CalculationShouldReturnCorrectValueA3()
        {
            Assert.AreEqual("A", a.Calculation(95));
        }

        [Test]
        public void CalculationShouldRaiseExceptionArgumentOutOfRange1()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => a.Calculation(-1));
        }

        [Test]
        public void CalculationShouldRaiseExceptionArgumentOutOfRange2()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => a.Calculation(101));
        }
    }
}
