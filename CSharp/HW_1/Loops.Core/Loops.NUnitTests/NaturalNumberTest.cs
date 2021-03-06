﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loops.Core;

namespace Loops.NUnitTests
{
    [TestFixture]
    public class NaturalNumberTest
    {
        private NaturalNumber nm;

        [SetUp]
        protected void SetUp()
        {
            nm = new NaturalNumber();
        }

        [TearDown]
        public void TearDown()
        {
            nm = null;
        }

        [Test]
        public void CalculateRootLoopShouldReturnCorrectValue1()
        {
            Assert.AreEqual(2, nm.CalculateRootLoop(4));
        }

        [Test]
        public void CalculateRootLoopShouldReturnCorrectValue2()
        {
            Assert.AreEqual(3, nm.CalculateRootLoop(6));
        }

        [Test]
        public void CalculateRootLoopShouldRaiseArgumentException1()
        {
            Assert.Throws<ArgumentException>(() => nm.CalculateRootLoop(0));
        }

        [Test]
        public void CalculateRootLoopShouldRaiseArgumentException2()
        {
            Assert.Throws<ArgumentException>(() => nm.CalculateRootLoop(-5));
        }

        [Test]
        public void CalculateRootShouldReturnCorrectValue1()
        {
            Assert.AreEqual(3, nm.CalculateRoot(9));
        }

        [Test]
        public void CalculateRootShouldReturnCorrectValue2()
        {
            Assert.AreEqual(2, nm.CalculateRoot(6));
        }

        [Test]
        public void CalculateRootShouldReturnCorrectValue3()
        {
            Assert.AreEqual(3, nm.CalculateRoot(9));
        }

        [Test]
        public void CalculateRootShouldRaiseArgumentException1()
        {
            Assert.Throws<ArgumentException>(() => nm.CalculateRoot(0));
        }

        [Test]
        public void CalculateRootShouldRaiseArgumentException2()
        {
            Assert.Throws<ArgumentException>(() => nm.CalculateRoot(-5));
        }
    }
}
