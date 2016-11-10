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
    public class CalculateTest
    {
        private Calculate c;

        [SetUp]
        protected void SetUp()
        {
            c = new Calculate();
        }

        [Test]
        public void FindMaxExpressionShouldReturnCorrectValue1()
        {
            Assert.AreEqual(11, c.FindMaxExpression(2, 2, 2));
        }

        [Test]
        public void FindMaxExpressionShouldReturnCorrectValue2()
        {
            Assert.AreEqual(-3, c.FindMaxExpression(-2, -2, -2));
        }

        [Test]
        public void FindMaxExpressionShouldReturnCorrectValue3()
        {
            Assert.AreEqual(3, c.FindMaxExpression(0, 0, 0));
        }
    }
}
