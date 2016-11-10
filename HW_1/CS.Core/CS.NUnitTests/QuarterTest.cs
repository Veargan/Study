using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.Core;
using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture]
    public class QuarterTest
    {
        private Quarter q;

        [SetUp]
        protected void SetUp()
        {
            q = new Quarter();
        }

        [Test]
        public void FindQuarterShouldReturnQuarter1()
        {
            Assert.AreEqual(1, q.FindQuarter(5, 5));
        }

        [Test]
        public void FindQuarterShouldReturnQuarter2()
        {
            Assert.AreEqual(2, q.FindQuarter(-5, 5));
        }

        [Test]
        public void FindQuarterShouldReturnQuarter3()
        {
            Assert.AreEqual(3, q.FindQuarter(-5, -5));
        }

        [Test]
        public void FindQuarterShouldReturnQuarter4()
        {
            Assert.AreEqual(4, q.FindQuarter(5, -5));
        }

        [Test]
        public void FindQuarterShouldRaiseExceptionIfCoordinates0()
        {
            Assert.Throws<ArgumentException>(() => q.FindQuarter(0, 0));
        }

        [Test]
        public void FindQuarterShouldRaiseExceptionIfCoordinate0()
        {
            Assert.Throws<ArgumentException>(() => q.FindQuarter(5, 0));
        }
    }
}