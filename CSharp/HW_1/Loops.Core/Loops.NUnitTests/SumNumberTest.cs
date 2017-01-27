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
    public class SumNumberTest
    {
        private SumNumber sn;

        [SetUp]
        protected void SetUp()
        {
            sn = new SumNumber();
        }

        [TearDown]
        public void TearDown()
        {
            sn = null;
        }

        [Test]
        public void SumNumberShouldReturnCorrectValue1()
        {
            Assert.AreEqual(1, sn.SumN(1));
        }

        [Test]
        public void SumNumberShouldReturnCorrectValue2()
        {
            Assert.AreEqual(3, sn.SumN(12));
        }

        [Test]
        public void SumNumberShouldReturnCorrectValue3()
        {
            Assert.AreEqual(6, sn.SumN(123));
        }

        [Test]
        public void SumNumberShouldReturnCorrectValue4()
        {
            Assert.AreEqual(0, sn.SumN(0));
        }

        [Test]
        public void SumNumberShouldReturnCorrectValue5()
        {
            Assert.AreEqual(1, sn.SumN(01));
        }

        [Test]
        public void SumNumberShouldReturnCorrectValue6()
        {
            Assert.AreEqual(1, sn.SumN(-1));
        }

        [Test]
        public void SumNumberShouldReturnCorrectValue7()
        {
            Assert.AreEqual(3, sn.SumN(-12));
        }

        [Test]
        public void SumNumberShouldReturnCorrectValue8()
        {
            Assert.AreEqual(28, sn.SumN(1234567));
        }
    }
}
