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
    public class FactorialTest
    {
        private Factorial f;

        [SetUp]
        protected void SetUp()
        {
            f = new Factorial();
        }

        [TearDown]
        public void TearDown()
        {
            f = null;
        }

        [Test]
        public void FindFactorialShouldRaiseArgumentException1()
        {
            Assert.Throws<ArgumentException>(() => f.FindFactorial(0));
        }

        [Test]
        public void FindFactorialShouldRaiseArgumentException2()
        {
            Assert.Throws<ArgumentException>(() => f.FindFactorial(-1));
        }

        [Test]
        public void FindFactorialShouldReturnCorrectValue1()
        {
            Assert.AreEqual(1, f.FindFactorial(1));
        }

        [Test]
        public void FindFactorialShouldReturnCorrectValue2()
        {
            Assert.AreEqual(2, f.FindFactorial(2));
        }

        [Test]
        public void FindFactorialShouldReturnCorrectValue3()
        {
            Assert.AreEqual(5040, f.FindFactorial(7));
        }
    }
}
