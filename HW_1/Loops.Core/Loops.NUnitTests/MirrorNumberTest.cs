using NUnit.Framework;
using Loops.Core;

namespace Loops.NUnitTests
{
    [TestFixture]
    public class MirrorNumberTest
    {
        private MirrorNumber mn;

        [SetUp]
        protected void SetUp()
        {
            mn = new MirrorNumber();
        }

        [TearDown]
        public void TearDown()
        {
            mn = null;
        }

        [Test]
        public void FindMirrorNumberShouldReturnCorrectValue1()
        {
            Assert.AreEqual(1, mn.FindMirrorNumber(1));
        }

        [Test]
        public void FindMirrorNumberShouldReturnCorrectValue2()
        {
            Assert.AreEqual(21, mn.FindMirrorNumber(12));
        }

        [Test]
        public void FindMirrorNumberShouldReturnCorrectValue3()
        {
            Assert.AreEqual(7654321, mn.FindMirrorNumber(1234567));
        }

        [Test]
        public void FindMirrorNumberShouldReturnCorrectValue4()
        {
            Assert.AreEqual(0, mn.FindMirrorNumber(0));
        }

        [Test]
        public void FindMirrorNumberShouldReturnCorrectValue5()
        {
            Assert.AreEqual(1, mn.FindMirrorNumber(-1));
        }

        [Test]
        public void FindMirrorNumberShouldReturnCorrectValue6()
        {
            Assert.AreEqual(21, mn.FindMirrorNumber(-12));
        }

        [Test]
        public void FindMirrorNumberShouldReturnCorrectValue7()
        {
            Assert.AreEqual(7654321, mn.FindMirrorNumber(-1234567));
        }
    }
}
