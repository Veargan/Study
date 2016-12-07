using NUnit.Framework;
using Tree.Core;
using System;

namespace Tree.NUnitTests
{
    [TestFixture(typeof(BSTree))]
    [TestFixture(typeof(BsTreeVis))]
    public class BSTreeTest<TTree> where TTree : ITree, new()
    {
        BSTree list;

        [SetUp]
        protected void SetUp()
        {
            list = new BSTree();
        }

        #region Init
        [TestCase(null, TestName="InitNull")]
        [TestCase(null, TestName = "Init0")]
        public void TestInitExc(int[] ar)
        {
            Assert.Throws<NullReferenceException>(() => list.Init(ar));
        }
        [TestCase(new int[] { 1 }, new int[] { 1 }, TestName = "Init1")]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, TestName = "Init2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, TestName = "InitMany")]
        public void TestInit(int[] ar, int[] exp)
        {
            list.Init(ar);
            CollectionAssert.AreEqual(exp, list.ToArray());
        }
        #endregion

        #region Size
        [TestCase(null, TestName = "SizeNull")]
        public void TestSizeExc(int[] ar)
        {
            Assert.Throws<NullReferenceException>(() => list.Init(ar));
        }
        [TestCase(new int[] { }, 0, TestName = "Size0")]
        [TestCase(new int[] { 1 }, 1, TestName = "Size1")]
        [TestCase(new int[] { 1, 2 }, 2, TestName = "Size2")]
        [TestCase(new int[] { 1, 2, 3, 2, 5, 6, 7 }, 7, TestName = "SizeMany")]
        public void TestSize(int[] ar, int res)
        {
            list.Init(ar);
            int act = list.Size();
            Assert.AreEqual(res, act);
        }
        #endregion

        #region ToArray
        [TestCase(null, TestName = "ToArrayNull")]
        public void TestToArrayExc(int[] ar)
        {
            Assert.Throws<NullReferenceException>(() => list.Init(ar));
        }
        [TestCase(new int[] { }, new int[] { }, TestName = "ToArray0")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, TestName = "ToArray1")]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, TestName = "ToArray2")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 100 }, new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 100 }, TestName = "ToArrayMany")]
        public void TestToArray(int[] ar, int[] exp)
        {
            list.Init(ar);
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion
        [TestCase(null, TestName = "ToStringNull")]
        
        public void TestToStringExc(int[] ar)
        {
            Assert.Throws<NullReferenceException>(() => list.Init(ar));
        }
        #region ToString
        [TestCase(new int[] { }, "", TestName = "ToString0")]
        [TestCase(new int[] { 1 }, "1 ", TestName = "ToString1")]
        [TestCase(new int[] { 1, 2 }, "1 2 ", TestName = "ToString2")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, "50 25 11 7 30 27 40 90 80 110 ", TestName = "ToStringMany")]
        public void TestToString(int[] ar, string exp)
        {
            list.Init(ar);
            Assert.AreEqual(exp, list.ToString());
        }
        #endregion

        #region Add
        [TestCase(null, TestName = "AddNull")]
        public void TestAddExp(int[] ar)
        {
            Assert.Throws<NullReferenceException>(() => list.Init(ar));
        }
        [TestCase(new int[] { }, new int[] { 0 }, 0, 1, TestName = "Add0")]
        [TestCase(new int[] { 1 }, new int[] { 1, 2 }, 2, 2, TestName = "Add1")]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3 }, 3, 3, TestName = "Add2")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110, 120 }, 120, 11, TestName = "AddMany")]
        public void TestAdd(int[] ar, int[] exp, int val, int expSize)
        {
            list.Init(ar);
            list.Add(val);
            int[] act = list.ToArray();
            int actSize = list.Size();
            Assert.AreEqual(actSize, expSize);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region Leaves
        [TestCase(null, TestName = "LeavesNull")]
        public void TestLeavesExc(int[] ar)
        {
            Assert.Throws<NullReferenceException>(() => list.Init(ar));
        }
        [TestCase(new int[] { }, 0, TestName = "Leaves0")]
        [TestCase(new int[] { 1 }, 1, TestName = "Leaves1")]
        [TestCase(new int[] { 1, 2 }, 1, TestName = "Leaves2")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, 5, TestName = "LeavesMany")]
        public void TestLeaves(int[] ar, int res)
        {
            list.Init(ar);
            int act = list.Leaves();
            Assert.AreEqual(res, act);
        }
        #endregion

        #region NndeS
        [TestCase(null, TestName = "NodeSNull")]
        public void TestNodeSExc(int[] ar)
        {
            Assert.Throws<NullReferenceException>(() => list.Init(ar));
        }
        [TestCase(new int[] { }, 0, TestName = "NodeS0")]
        [TestCase(new int[] { 1 }, 1, TestName = "NodeS1")]
        [TestCase(new int[] { 1, 2 }, 1, TestName = "Nodes2")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, 5, TestName = "NodeSMany")]
        public void TestNodeS(int[] ar, int res)
        {
            list.Init(ar);
            int act = list.NodeS();
            Assert.AreEqual(res, act);
        }
        #endregion

        #region Width
        [TestCase(null, TestName = "WidthNull")]
        public void TestWidthExc(int[] ar)
        {
            Assert.Throws<NullReferenceException>(() => list.Init(ar));
        }
        [TestCase(new int[] { }, 0, TestName = "Width0")]
        [TestCase(new int[] { 1 }, 1, TestName = "Width1")]
        [TestCase(new int[] { 50, 25, 110 }, 2, TestName = "Width2")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, 4, TestName = "WidthMany")]
        public void TestWidth(int[] ar, int res)
        {
            list.Init(ar);
            int act = list.Width();
            Assert.AreEqual(res, act);
        }
        #endregion

        #region Height
        [TestCase(null, TestName = "HeightNull")]
        public void TestHeightExc(int[] ar)
        {
            Assert.Throws<NullReferenceException>(() => list.Init(ar));
        }
        [TestCase(new int[] { }, 0, TestName = "Height0")]
        [TestCase(new int[] { 1 }, 1, TestName = "Height1")]
        [TestCase(new int[] { 1, 2 }, 2, TestName = "Height2")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, 4, TestName = "HeightMany")]
        public void TestHeight(int[] ar, int res)
        {
            list.Init(ar);
            int act = list.Height();
            Assert.AreEqual(res, act);
        }
        #endregion

        #region Reverse
        [TestCase(new int[] { }, new int[] { }, TestName = "Reverse0")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, TestName = "Reverse1")]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, TestName = "Reverse2")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 50, 90, 110, 80, 25, 30, 40, 27, 11, 7 }, TestName = "ReverseMany")]
        public void Reverse(int[] ar, int[] res)
        {
            list.Init(ar);
            list.Reverse();
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(act, res);
        }
        #endregion

        #region DelNode
        [TestCase(null, TestName = "DelNull")]
        
        public void TestDelNodeExp(int[] ar)
        {
            Assert.Throws<NullReferenceException>(() => list.Init(ar));
        }
        [TestCase(new int[] { 1 }, new int[] { }, 1, 0, TestName = "Del1")]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 }, 2, 1, TestName = "Del2")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80 }, 110, 9, TestName = "DelMany")]
        public void TestNode(int[] ar, int[] exp, int val, int expSize)
        {
            list.Init(ar);
            list.DelNode(val);
            int[] act = list.ToArray();
            int actSize = list.Size();
            Assert.AreEqual(actSize, expSize);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region Enumerator
        [TestCase(new int[] { }, new int[] { }, TestName = "Enumerator0")]
        [TestCase(new int[] { 0 }, new int[] { 0 }, TestName = "Enumerator1")]
        [TestCase(new int[] { 0, 1 }, new int[] { 0, 1 }, TestName = "Enumerator2")]
        [TestCase(new int[] { 0, 1, 4, 3, 2, 5, 6, 7, 8 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, TestName = "EnumeratorMany")]
        public void TestEnumerator(int[] array, int[] result)
        {
            list.Init(array);
            int[] actual = new int[array.Length];
            int iterator = 0;
            foreach (var item in list)
            {
                actual[iterator++] = (int)item;
            }
            Assert.AreEqual(actual, result);
        }
        #endregion
    }
}