using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree.Core;

namespace Tree.NUnitTests
{
    public class RBTreeTest
    {
        RBTree bs = null;
        [SetUp]
        public void Clear_al()
        {
            bs = new RBTree();
        }
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 10 }, 1)]
        [TestCase(new int[] { 10, 2 }, 2)]
        [TestCase(new int[] { 10, 2, 30, 4, 0 }, 5)]
        public void TestInit(int[] ar, int res)
        {
            bs.Init(ar);
            int act = bs.Size();
            Assert.AreEqual(res, act);
        }
        [TestCase(null, "")]
        [TestCase(new int[] { }, "")]
        [TestCase(new int[] { 10 }, "10 ")]
        [TestCase(new int[] { 10, 2 }, "2 10 ")]
        [TestCase(new int[] { 5, 15, 4, 0, 157, -3, -10 }, "-10 -3 0 4 5 15 157 ")]
        public void TestToString(int[] ar, String exp)
        {
            bs.Init(ar);
            String act = bs.ToString();
            Assert.AreEqual(exp, act);
        }
        [TestCase(null, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 10 }, new int[] { 10 })]
        [TestCase(new int[] { 10, 2 }, new int[] { 2, 10 })]
        [TestCase(new int[] { 5, 15, 4, 0, 157, -3, -10 }, new int[] { -10, -3, 0, 4, 5, 15, 157 })]
        public void TesTToArray(int[] ar, int[] exp)
        {
            bs.Init(ar);
            int[] act = bs.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        [TestCase(new int[] { }, new int[] { 9 }, 9, 1)]
        [TestCase(new int[] { 10 }, new int[] { 9, 10 }, 9, 2)]
        [TestCase(new int[] { 10, 2 }, new int[] { 2, 9, 10 }, 9, 3)]
        [TestCase(new int[] { 50, 25, 76, 178, -6 }, new int[] { -6, 9, 25, 50, 76, 178 }, 9, 6)]
        public void TestAdd(int[] ar, int[] exp, int val, int expSize)
        {
            bs.Init(ar);
            bs.Add(val);
            int[] act = bs.ToArray();
            int actSize = bs.Size();
            Assert.AreEqual(expSize, actSize);
            CollectionAssert.AreEqual(exp, act);
        }
        [TestCase(null, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 10 }, new int[] { 10 })]
        [TestCase(new int[] { 10, 2 }, new int[] { 10, 2 })]
        [TestCase(new int[] { 5, 15, 4, 0, 157, -3, -10 }, new int[] { 157, 15, 5, 4, 0, -3, -10 })]
        public void TesTReverse(int[] ar, int[] exp)
        {
            bs.Init(ar);
            bs.Reverse();
            int[] act = bs.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 10 }, 1)]
        [TestCase(new int[] { 10, 2 }, 2)]
        [TestCase(new int[] { 5, 15, 4, 0, 157, -3, -10 }, 4)]
        public void Testheight(int[] ar, int exp)
        {
            bs.Init(ar);
            int act = bs.Height();
            Assert.AreEqual(exp, act);
        }
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 10 }, 1)]
        [TestCase(new int[] { 10, 2 }, 1)]
        [TestCase(new int[] { 5, 15, 4, 0, 157, -3, -10, 7, 14 }, 4)]
        public void TestWidth(int[] ar, int exp)
        {
            bs.Init(ar);
            int act = bs.Width();
            Assert.AreEqual(exp, act);
        }
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 10 }, 1)]
        [TestCase(new int[] { 10, 2 }, 1)]
        [TestCase(new int[] { 5, 15, 4, 0, 157, -3, -10, 7, 14 }, 4)]
        public void TestLeaves(int[] ar, int exp)
        {
            bs.Init(ar);
            int act = bs.Leaves();
            Assert.AreEqual(exp, act);
        }
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 10 }, 0)]
        [TestCase(new int[] { 10, 2 }, 1)]
        [TestCase(new int[] { 5, 15, 4, 0, 157, -3, -10, 7, 14 }, 5)]
        public void TestNodes(int[] ar, int exp)
        {
            bs.Init(ar);
            int act = bs.NodeS();
            Assert.AreEqual(exp, act);
        }
        [TestCase(null, new int[] { }, 6)]
        [TestCase(new int[] { }, new int[] { }, 6)]
        public void TestDel_Exc(int[] ar, int[] exp, int val)
        {
            bs.Init(ar);
            Assert.That(() => bs.Del(val), Throws.TypeOf<NullReferenceException>());
        }
        [TestCase(new int[] { 10 }, new int[] { }, 10)]
        [TestCase(new int[] { 10, 2 }, new int[] { 2 }, 10)]
        [TestCase(new int[] { 5, 15, 4, 0, 157, -3, -10 }, new int[] { -10, -3, 0, 4, 5, 157 }, 15)]
        [TestCase(new int[] { 5, 15, 4, 0, 157, -3, -10 }, new int[] { -10, -3, 0, 4, 5, 15 }, 157)]
        public void TestDel(int[] ar, int[] exp, int val)
        {
            bs.Init(ar);
            bs.Del(val);
            int[] act = bs.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }

    }
}
