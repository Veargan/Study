using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace BTTests
{
    class RbTreeEqualTests
    {
        RbTree bs = null;
        [SetUp]
        public void Clear_al()
        {
            bs = new RbTree();
        }
        [TestCase(new int[] { 10, 2, 30, 4, 0 }, new int[] { 10, 2, 30, 4, 0 }, 5, TestName = "EqualsAddTestRbNoBalance")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 30, 25, 50, 11, 27, 40, 90, 7, 80, 110 }, 10, TestName = "EqualsAddTestFlipColor")]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 2, 3, 1 }, 3, TestName = "EqualsAddTestBlanceRight")]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3, 1 }, 3, TestName = "EqualsAddTestBlanceLeft")]
        public void TestEqualsAdd(int[] ar, int[] at, int res)
        {
            bs.Init(ar);
            RbTree act = new RbTree();
            act.Init(at);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));

        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 3, 2, 4 }, 1, 3, TestName = "EqualsDelTestLeftRb")]
        [TestCase(new int[] { 1, 2, 3, 0 }, new int[] { 1, 0, 2 }, 3, 3, TestName = "EqualsDelTestRightRb")]
        [TestCase(new int[] { 1, 2, 3, 0 }, new int[] { 1, 0, 3 }, 2, 3, TestName = "EqualsDelTestRootRb")]
        public void TestEqualsDel(int[] ar, int[] at, int val, int res)
        {
            bs.Init(ar);
            RbTree act = new RbTree();
            act.Init(at);
            bs.Del(val);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));

        }

        [TestCase(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 5, 6, 3, 2, 4, 1 }, 4, 6, TestName = "EqualsHeightTestRb")]
        public void TestEqualsHeight(int[] ar, int[] at, int h, int res)
        {
            bs.Init(ar);
            RbTree act = new RbTree();
            act.Init(at);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));
            Assert.AreEqual(h, bs.Height());
        }

        [TestCase(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 5, 6, 3, 2, 4, 1 }, 2, 6, TestName = "EqualsWidthTestRb")]
        public void TestEqualsWidth(int[] ar, int[] at, int h, int res)
        {
            bs.Init(ar);
            RbTree act = new RbTree();
            act.Init(at);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));
            Assert.AreEqual(h, bs.Width());
        }

        [TestCase(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 5, 6, 3, 2, 4, 1 }, 3, 6, TestName = "EqualsLEavesTestAvl")]
        public void TestEqualsLeaves(int[] ar, int[] at, int h, int res)
        {
            bs.Init(ar);
            RbTree act = new RbTree();
            act.Init(at);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));
            Assert.AreEqual(h, bs.Leaves());
        }

        [TestCase(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 5, 6, 3, 2, 4, 1 }, 3, 6, TestName = "EqualsNodesTestAvl")]
        public void TestEqualsNodes(int[] ar, int[] at, int h, int res)
        {
            bs.Init(ar);
            RbTree act = new RbTree();
            act.Init(at);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));
            Assert.AreEqual(h, bs.Nodes());
        }
    }
}
