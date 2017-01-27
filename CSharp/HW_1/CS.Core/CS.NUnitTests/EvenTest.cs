using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.Core;

namespace CSNUnitTests
{
    [TestFixture]
    public class EvenTest
    {
        private Even e;

        [SetUp]
        protected void SetUp()
        {
            e = new Even();
        }

        [Test]
        public void EvenNumberShouldReturnPositiveEven()
        {
            Assert.AreEqual(20, e.EvenNumber(10, 2));
        }

        [Test]
        public void EvenNumberShouldReturnNegativeEven()
        {
            Assert.AreEqual(-4, e.EvenNumber(-2, 2));
        }

        [Test]
        public void EvenNumberShouldReturnPositiveOdd()
        {
            Assert.AreEqual(3, e.EvenNumber(1, 2));
        }

        [Test]
        public void EvenNumberShouldReturnNegativeOdd()
        {
            Assert.AreEqual(-1, e.EvenNumber(-3, 2));
        }

        [Test]
        public void EvenNumberShouldReturnZero()
        {
            Assert.AreEqual(0, e.EvenNumber(0, 10));
        }
    }
}