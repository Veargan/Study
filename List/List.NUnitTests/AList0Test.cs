using NUnit.Framework;
using List.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.NUnitTests
{
    [TestFixture]
    public class AList0Test
    {
        private AList0 a;

        protected void SetUp()
        {
            a = new AList0();
        }

        [TearDown]
        public void TearDown()
        {
            a = null;
        }

        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }
    }
}
