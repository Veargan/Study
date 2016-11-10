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
    public class NumbersTest
    {
        private Numbers s;

        [SetUp]
        protected void SetUp()
        {
            s = new Numbers();
        }

        [Test]
        public void SumOnlyPosNumbersShouldReturnZero()
        {
            Assert.AreEqual(0, s.SumOnlyPosNumbers(-2, -5, -10));
        }

        [Test]
        public void SumOnlyPosNumbersShouldReturnCorrectValue1()
        {
            Assert.AreEqual(7, s.SumOnlyPosNumbers(2, 5, -10));
        }

        [Test]
        public void SumOnlyPosNumbersShouldReturnCorrectValue2()
        {
            Assert.AreEqual(7, s.SumOnlyPosNumbers(2, 5, 0));
        }
    }
}