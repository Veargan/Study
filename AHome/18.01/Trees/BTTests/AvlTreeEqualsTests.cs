using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace BTTests
{
    class AvlTreeEqualsTests
    {
        AvlTree bs = null;
        [SetUp]
        public void Clear_al()
        {
            bs = new AvlTree();
        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 1, 3 }, 3, TestName = "EqualsAddTestAvlBalLeft")]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 2, 1, 3 }, 3, TestName = "EqualsAddTestAvlBalRight")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 4, 2, 5, 1, 3, 6 }, 6, TestName = "EqualsAddTestAvlBalLeftB")]
        [TestCase(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 3, 2, 5, 1, 4, 6 }, 6, TestName = "EqualsAddTestAvlBalRightB")]
        public void TestEqualsAdd(int[] ar, int[] at, int res)
        {
            bs.Init(ar);
            AvlTree act = new AvlTree();
            act.Init(at);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));

        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 3, 2, 4 }, 1, 3, TestName = "EqualsDelTestLeftAvl")]
        [TestCase(new int[] { 1, 2, 3, 0 }, new int[] { 1, 0, 2 }, 3, 3, TestName = "EqualsDelTestRightAvl")]
        [TestCase(new int[] { 1, 2, 3, 0 }, new int[] { 1, 0, 3 }, 2, 3, TestName = "EqualsDelTestRootAvl")]
        public void TestEqualsDel(int[] ar, int[] at, int val, int res)
        {
            bs.Init(ar);
            AvlTree act = new AvlTree();
            act.Init(at);
            bs.Del(val);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));

        }

        [TestCase(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 3, 2, 5, 1, 4, 6 }, 3, 6, TestName = "EqualsHeightTestAvl")]
        public void TestEqualsHeight(int[] ar, int[] at, int h, int res)
        {
            bs.Init(ar);
            AvlTree act = new AvlTree();
            act.Init(at);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));
            Assert.AreEqual(h, bs.Height());
        }

        [TestCase(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 3, 2, 5, 1, 4, 6 }, 3, 6, TestName = "EqualsWidthTestAvl")]
        public void TestEqualsWidth(int[] ar, int[] at, int h, int res)
        {
            bs.Init(ar);
            AvlTree act = new AvlTree();
            act.Init(at);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));
            Assert.AreEqual(h, bs.Width());
        }

        [TestCase(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 3, 2, 5, 1, 4, 6 }, 3, 6, TestName = "EqualsLeavesTestAvl")]
        public void TestEqualsLeaves(int[] ar, int[] at, int h, int res)
        {
            bs.Init(ar);
            AvlTree act = new AvlTree();
            act.Init(at);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));
            Assert.AreEqual(h, bs.Leaves());
        }

        [TestCase(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 3, 2, 5, 1, 4, 6 }, 3, 6, TestName = "EqualsNodesTestAvl")]
        public void TestEqualsNodes(int[] ar, int[] at, int h, int res)
        {
            bs.Init(ar);
            AvlTree act = new AvlTree();
            act.Init(at);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));
            Assert.AreEqual(h, bs.Nodes());
        }
    }
}
