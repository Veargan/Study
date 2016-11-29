using List.Core;
using NUnit.Framework;
using System;

namespace List.NUnitTests
{
    [TestFixture(typeof(AList0))]
    [TestFixture(typeof(AList1))]
    [TestFixture(typeof(AList2))]
    [TestFixture(typeof(AListR))]
    [TestFixture(typeof(LList1))]

    public class AListTests<TList> where TList : IList, new()
    {
        private TList list = new TList();

        [SetUp]
        protected void SetUp()
        {
            list.Clear();
        }

        #region INIT
        [TestCase(null, new int[] { }, TestName = "InitNull")]
        [TestCase(new int[] { }, new int[] { }, TestName = "Init0")]
        [TestCase(new int[] { 10 }, new int[] { 10 }, TestName = "Init1")]
        [TestCase(new int[] { 10, 2 }, new int[] { 10, 2 }, TestName = "Init2")]
        [TestCase(new int[] { 10, 30, 4, 0, 55, 9 }, new int[] { 10, 30, 4, 0, 55, 9 }, TestName = "InitMany")]
        public void TestInit(int[] ar, int[] exp)
        {
            list.Init(ar);
            Assert.AreEqual(exp, list.ToArray());
        }
        #endregion

        #region CLEAR
        [TestCase(null, new int[] { }, TestName = "ClearNull")]
        [TestCase(new int[] { }, new int[] { }, TestName = "Clear0")]
        [TestCase(new int[] { 10 }, new int[] { }, TestName = "Clear1")]
        [TestCase(new int[] { 10, 2 }, new int[] { }, TestName = "Clear2")]
        [TestCase(new int[] { 10, 2, 30, 4, 0, 55, 9 }, new int[] { }, TestName = "ClearMany")]
        public void Clear(int[] ar, int[] res)
        {
            list.Init(ar);
            list.Clear();
            int[] act = list.ToArray();
            Assert.AreEqual(act, res);
        }
        #endregion

        #region TO_ARRAY
        [TestCase(null, new int[] { }, TestName = "ToArrayNull")]
        [TestCase(new int[] { }, new int[] { }, TestName = "ToArray0")]
        [TestCase(new int[] { 10 }, new int[] { 10 }, TestName = "ToArray1")]
        [TestCase(new int[] { 10, 2 }, new int[] { 10, 2 }, TestName = "ToArray2")]
        [TestCase(new int[] { 5, 15, 4, 0, 0, -3, -10 }, new int[] { 5, 15, 4, 0, 0, -3, -10 }, TestName = "ToArrayMany")]
        public void TestToArray(int[] ar, int[] exp)
        {
            list.Init(ar);
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region SIZE
        [TestCase(null, 0, TestName = "SizeNull")]
        [TestCase(new int[] { }, 0, TestName = "Size0")]
        [TestCase(new int[] { 10 }, 1, TestName = "Size1")]
        [TestCase(new int[] { 10, 2 }, 2, TestName = "Size2")]
        [TestCase(new int[] { 10, 2, 30, 4, 0, 55, 9 }, 7, TestName = "SizeMany")]
        public void TestSize(int[] ar, int res)
        {
            list.Init(ar);
            int act = list.Size();
            Assert.AreEqual(res, act);
        }
        #endregion

        #region SET
        [TestCase(new int[] { }, TestName = "Set0")]
        [TestCase(new int[] { 1, 6 }, TestName = "Set0Out")]
        public void TestSet_ex(int[] ar)
        {
            list.Init(ar);
            Assert.That(() => list.Set(6, 5), Throws.TypeOf<IndexOutOfRangeException>());
        }
        [TestCase(new int[] { 10 }, new int[] { 89 }, 0, 89, TestName = "Set1")]
        [TestCase(new int[] { 1, 6 }, new int[] { 1, 89 }, 1, 89, TestName = "Set2")]
        [TestCase(new int[] { 1, 6, 87, 78, 90 }, new int[] { 1, 6, 87, 89, 90 }, 3, 89, TestName = "SetMany")]
        public void Set(int[] ar, int[] res, int pos, int val)
        {
            list.Init(ar);
            list.Set(pos, val);
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(act, res);
        }
        #endregion

        #region GET
        [TestCase(new int[] { }, TestName = "Get0")]
        [TestCase(new int[] { 1, 6 }, TestName = "Get0Out")]
        public void TestGet_ex(int[] ar)
        {
            list.Init(ar);
            Assert.That(() => list.Get(6), Throws.TypeOf<IndexOutOfRangeException>());
        }
        [TestCase(new int[] { 10 }, 0, 10, TestName = "Get1")]
        [TestCase(new int[] { 1, 6 }, 1, 6, TestName = "Get2")]
        [TestCase(new int[] { 1, 6, 87, 78, 90 }, 3, 78, TestName = "GetMany")]
        public void Get(int[] ar, int pos, int res)
        {
            list.Init(ar);
            int act = list.Get(pos);
            Assert.AreEqual(act, res);
        }
        #endregion

        #region ADD_START
        [TestCase(new int[] { }, new int[] { 9 }, 9, 1, TestName = "AddStart0")]
        [TestCase(new int[] { 10 }, new int[] { 9, 10 }, 9, 2, TestName = "AddStart1")]
        [TestCase(new int[] { 10, 2 }, new int[] { 9, 10, 2 }, 9, 3, TestName = "AddStart2")]
        [TestCase(new int[] { 5, 15, 4, 0, 0, -3, -10 }, new int[] { 9, 5, 15, 4, 0, 0, -3, -10 }, 9, 8, TestName = "AddStartMany")]
        public void TestAddStart(int[] ar, int[] exp, int val, int expSize)
        {
            list.Init(ar);
            list.AddStart(val);
            int[] act = list.ToArray();
            int actSize = list.Size();
            Assert.AreEqual(expSize, actSize);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region ADD_END
        [TestCase(new int[] { }, new int[] { 9 }, 9, 1, TestName = "AddEnd0")]
        [TestCase(new int[] { 10 }, new int[] { 10, 9 }, 9, 2, TestName = "AddEnd1")]
        [TestCase(new int[] { 10, 2 }, new int[] { 10, 2, 9 }, 9, 3, TestName = "AddEnd2")]
        [TestCase(new int[] { 5, 15, 4, 0, 0, -3, -10 }, new int[] { 5, 15, 4, 0, 0, -3, -10, 9 }, 9, 8, TestName = "AddEndMany")]
        public void TestAddEnd(int[] ar, int[] exp, int val, int expSize)
        {
            list.Init(ar);
            list.AddEnd(val);
            int[] act = list.ToArray();
            int actSize = list.Size();
            Assert.AreEqual(expSize, actSize);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region ADD_POS
        [TestCase(null, TestName = "AddPosNull")]
        public void TestAddPos_ex(int[] ar)
        {
            list.Init(ar);
            Assert.That(() => list.AddPos(12, 2), Throws.TypeOf<IndexOutOfRangeException>());
        }
        [TestCase(new int[] { }, new int[] { 9 }, 0, 9, 1, TestName = "AddPos0")]
        [TestCase(new int[] { 10 }, new int[] { 9, 10 }, 0, 9, 2, TestName = "AddPos1")]
        [TestCase(new int[] { 10, 2 }, new int[] { 10, 9, 2 }, 1, 9, 3, TestName = "AddPos2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 9, 4, 5, 6, 7 }, 3, 9, 8, TestName = "AddPosMany")]
        public void TestAddPos(int[] ar, int[] exp, int pos, int val, int expSize)
        {
            list.Init(ar);
            list.AddPos(pos, val);
            int[] act = list.ToArray();
            int actSize = list.Size();
            Assert.AreEqual(expSize, actSize);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region DEL_START
        [TestCase(new int[] { }, TestName = "DelStart0")]
        public void TestDelStartEx(int[] ar)
        {
            list.Init(ar);
            Assert.Throws<NullReferenceException>(() => list.DelStart());
        }
        [TestCase(new int[] { 10 }, new int[] { }, 10, 0, TestName = "DelStart1")]
        [TestCase(new int[] { 10, 2 }, new int[] { 2 }, 10, 1, TestName = "DelStart2")]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60, 70 }, new int[] { 20, 30, 40, 50, 60, 70 }, 10, 6, TestName = "DelStartMany")]
        public void TestDelStart(int[] ar, int[] exp, int expVal, int expSize)
        {
            list.Init(ar);
            int actVal = list.DelStart();
            int[] act = list.ToArray();
            int actSize = list.Size();
            Assert.AreEqual(expSize, actSize);
            Assert.AreEqual(expVal, actVal);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region DEL_END
        [TestCase(new int[] { }, TestName = "DelEnd0")]
        public void TestDelEndEx(int[] ar)
        {
            list.Init(ar);
            Assert.Throws<NullReferenceException>(() => list.DelEnd());
        }
        [TestCase(new int[] { 1 }, new int[] { }, 0, TestName = "DelEnd1")]
        [TestCase(new int[] { 2, 1 }, new int[] { 2 }, 1, TestName = "DelEnd2")]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2, 3, 4, 5 }, 6, TestName = "DelEndMany")]
        public void TestDelEnd(int[] ar, int[] exp, int expSize)
        {
            list.Init(ar);
            int actVal = list.DelEnd();
            int[] act = list.ToArray();
            int actSize = list.Size();
            Assert.AreEqual(expSize, actSize);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region DEL_POS
        [TestCase(new int[] { }, TestName = "DelPos0")]
        public void TestDelPos_ex(int[] ar)
        {
            list.Init(ar);
            Assert.That(() => list.DelPos(4), Throws.TypeOf<NullReferenceException>());
        }
        [TestCase(new int[] { 1 }, new int[] { }, 0, 1, 0, TestName = "DelPos1")]
        [TestCase(new int[] { 2, 1 }, new int[] { 2 }, 1, 1, 1, TestName = "DelPos2")]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2, 4, 5, 6 }, 3, 3, 6, TestName = "DelPosMany")]
        public void TestDelPos(int[] ar, int[] exp, int expPos, int expVal, int expSize)
        {
            list.Init(ar);
            int actVal = list.DelPos(expPos);
            int[] act = list.ToArray();
            int actSize = list.Size();
            Assert.AreEqual(expSize, actSize);
            Assert.AreEqual(expVal, actVal);
            CollectionAssert.AreEqual(exp, act);
        }
        #endregion

        #region MAX
        [TestCase(new int[] { }, TestName = "Max0")]
        public void TestMax_ex(int[] ar)
        {
            list.Init(ar);
            Assert.That(() => list.Max(), Throws.TypeOf<NullReferenceException>());
        }
        [TestCase(new int[] { 10 }, 10, TestName = "Max1")]
        [TestCase(new int[] { 10, 2 }, 10, TestName = "Max2")]
        [TestCase(new int[] { 10, 2, 30, 4, 0, 55, 9 }, 55, TestName = "MaxMany")]
        public void Max(int[] ar, int res)
        {
            list.Init(ar);
            int act = list.Max();
            Assert.AreEqual(act, res);
        }
        #endregion

        #region MIN
        [TestCase(new int[] { }, TestName = "Min0")]
        public void TestMin_ex(int[] ar)
        {
            list.Init(ar);
            Assert.That(() => list.Min(), Throws.TypeOf<NullReferenceException>());
        }
        [TestCase(new int[] { 10 }, 10, TestName = "Min1")]
        [TestCase(new int[] { 10, 2 }, 2, TestName = "Min2")]
        [TestCase(new int[] { 10, 2, 30, 4, 0, 55, 9 }, 0, TestName = "MinMany")]
        public void Min(int[] ar, int res)
        {
            list.Init(ar);
            int act = list.Min();
            Assert.AreEqual(act, res);
        }
        #endregion

        #region IND_MAX
        [TestCase(new int[] { }, TestName = "IndMax0")]
        public void TestMaxInd_ex(int[] ar)
        {
            list.Init(ar);
            Assert.That(() => list.IndMax(), Throws.TypeOf<NullReferenceException>());
        }
        [TestCase(new int[] { 10 }, 0, TestName = "IndMax1")]
        [TestCase(new int[] { 10, 2 }, 0, TestName = "IndMax2")]
        [TestCase(new int[] { 10, 2, 30, 4, 0, 55, 9 }, 5, TestName = "IndMaxMany")]
        public void MaxInd(int[] ar, int res)
        {
            list.Init(ar);
            int act = list.IndMax();
            Assert.AreEqual(act, res);
        }
        #endregion

        #region IND_MIN
        [TestCase(new int[] { }, TestName = "IndMin0")]
        public void TestMinInd_ex(int[] ar)
        {
            list.Init(ar);
            Assert.That(() => list.IndMin(), Throws.TypeOf<NullReferenceException>());
        }
        [TestCase(new int[] { 10 }, 0, TestName = "IndMin1")]
        [TestCase(new int[] { 10, 2 }, 1, TestName = "IndMin2")]
        [TestCase(new int[] { 10, 2, 30, 4, 0, 55, 9 }, 4, TestName = "IndMinMany")]
        public void MinInd(int[] ar, int res)
        {
            list.Init(ar);
            int act = list.IndMin();
            Assert.AreEqual(act, res);
        }
        #endregion

        #region REVERSE
        [TestCase(new int[] { }, new int[] { }, TestName = "Reverse0")]
        [TestCase(new int[] { 10 }, new int[] { 10 }, TestName = "Reverse1")]
        [TestCase(new int[] { 1, 6 }, new int[] { 6, 1 }, TestName = "Reverse2")]
        [TestCase(new int[] { 1, 6, 87, 78, 90 }, new int[] { 90, 78, 87, 6, 1 }, TestName = "ReverseMany")]
        public void Reverse(int[] ar, int[] res)
        {
            list.Init(ar);
            list.Reverse();
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(act, res);
        }
        #endregion

        #region HALF_REVERSE
        [TestCase(new int[] { }, new int[] { }, TestName = "HalfReverse0")]
        [TestCase(new int[] { 10 }, new int[] { 10 }, TestName = "HalfReverse1")]
        [TestCase(new int[] { 1, 6 }, new int[] { 6, 1 }, TestName = "HalfReverse2")]
        [TestCase(new int[] { 1, 6, 87, 78, 90 }, new int[] { 78, 90, 87, 1, 6, }, TestName = "HalfReverseManyEven")]
        [TestCase(new int[] { 1, 6, 87, 78, 90, 70 }, new int[] { 78, 90, 70, 1, 6, 87 }, TestName = "HalfReverseManyOdd")]
        public void HalfReverse(int[] ar, int[] res)
        {
            list.Init(ar);
            list.HalfReverse();
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(act, res);
        }
        #endregion

        #region SORT
        [TestCase(new int[] { }, new int[] { }, TestName = "Sort0")]
        [TestCase(new int[] { 10 }, new int[] { 10 }, TestName = "Sort1")]
        [TestCase(new int[] { 10, 2 }, new int[] { 2, 10 }, TestName = "Sort2")]
        [TestCase(new int[] { 10, 2, 30, 4, 0, 55, 9 }, new int[] { 0, 2, 4, 9, 10, 30, 55 }, TestName = "SortMany")]
        public void SortMany(int[] ar, int[] res)
        {
            list.Init(ar);
            list.Sort();
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(act, res);
        }
        #endregion

        #region TO_STRING
        [TestCase(null, "", TestName = "ToStringNull")]
        [TestCase(new int[] { }, "", TestName = "ToString0")]
        [TestCase(new int[] { 10 }, "10 ", TestName = "ToString1")]
        [TestCase(new int[] { 10, 2 }, "10 2 ", TestName = "ToString2")]
        [TestCase(new int[] { 5, 15, 4, 0, 0, -3, -10 }, "5 15 4 0 0 -3 -10 ", TestName = "ToStringMany")]
        public void TestToString(int[] ar, string exp)
        {
            list.Init(ar);
            Assert.AreEqual(exp, list.ToString());
        }
        #endregion
    }
}