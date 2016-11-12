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
    public class EvenTest
    {
        private Even e;

        [SetUp]
        protected void SetUp()
        {
            e = new Even();
        }

        [TearDown]
        public void TearDown()
        {
            e = null;
        }

        [Test]
        public void SumEvenNumbersShouldReturnCorrectValue()
        {
            Assert.AreEqual(2450, e.SumEvenNumbers());
        }

        [Test]
        public void CountEvenNumbersShouldReturnCorrectValue()
        {
            Assert.AreEqual(49, e.CountEvenNumbers());
        }
    }
}
