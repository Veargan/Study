using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loops.Core;

namespace Loops.NUnitTests
{
    [TestFixture]
    public class PrimeNumberTest
    {
        private PrimeNumber pm;

        [SetUp]
        protected void SetUp()
        {
            pm = new PrimeNumber();
        }

        [TearDown]
        public void TearDown()
        {
            pm = null;
        }

        [Test]
        public void IsPrimeShouldReturnTrue()
        {
            Assert.True(pm.IsPrime(3));
        }

        [Test]
        public void IsPrimeShouldReturnFalse1()
        {
            Assert.False(pm.IsPrime(6));
        }

        [Test]
        public void IsPrimeShouldRaiseArgumentException1()
        {
            Assert.Throws<ArgumentException>(() => pm.IsPrime(0));
        }

        [Test]
        public void IsPrimeShouldRaiseArgumentException2()
        {
            Assert.Throws<ArgumentException>(() => pm.IsPrime(-1));
        }

        [Test]
        public void IsPrimeShouldRaiseArgumentException3()
        {
            Assert.Throws<ArgumentException>(() => pm.IsPrime(1));
        }
    }
}
