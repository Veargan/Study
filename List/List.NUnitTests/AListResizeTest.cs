using NUnit.Framework;
using System;
using List.Core;

namespace List.NUnitTests
{
    [TestFixture(typeof(AList1))]
    [TestFixture(typeof(AList2))]
    [TestFixture(typeof(AListR))]

    public class AListResizeTest<TList> where TList : IList, new()
    {
        private TList list = new TList();

        [SetUp]
        public void Clear_all()
        {
            list.Clear();
        }

        [TestCase(new int[] { 1, 2, 3, 5, 4, 7, 6, 8, 1, 2, 1, 4, 6, 1 }, new int[] { 1, 2, 3, 5, 4, 7, 6, 8, 1, 2, 1, 4, 6, 1 }, TestName = "Init")]
        public void Init(int[] ar, int[] exp)
        {
            list.Init(ar);
            int[] res = list.ToArray();
            Assert.AreEqual(exp, res);
        }

        [TestCase(null, 5, 30, TestName = "AddPosExcNull_1")]
        [TestCase(null, -1, 30, TestName = "AddPosExcNull_2")]
        [TestCase(new int[] { }, 5, 30, TestName = "AddPosExc0_1")]
        [TestCase(new int[] { }, -1, 30, TestName = "AddPosExc0_2")]
        [TestCase(new int[] { 1 }, 5, 30, TestName = "AddPosExc1_1")]
        [TestCase(new int[] { 1 }, -1, 30, TestName = "AddPosExc1_2")]
        [TestCase(new int[] { 10, 22 }, 5, 30, TestName = "AddPosExc2_1")]
        [TestCase(new int[] { 10, 22 }, -1, 30, TestName = "AddPosExc2_2")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, 15, 30, TestName = "AddPosExcMany_1")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, -1, 30, TestName = "AddPosExcMany_2")]
        public void AddPosIndexOutOfRange(int[] ar, int pos, int count)
        {
            list.Init(ar);
            for (int i = 0; i < count; i++)
            {
                Assert.Throws<IndexOutOfRangeException>(() => list.AddPos(pos, i));
            }
        }

        [TestCase(null, 0, 30, new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, TestName = "AddPosNull")]
        [TestCase(new int[] { }, 0, 30, new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, TestName = "AddPos0")]
        [TestCase(new int[] { 1 }, 0, 30, new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 1 }, TestName = "AddPos1_0")]
        [TestCase(new int[] { 1 }, 1, 30, new int[] { 1, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, TestName = "AddPos1_1")]
        [TestCase(new int[] { 10, 22 }, 0, 30, new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 10, 22 }, TestName = "AddPos2_0")]
        [TestCase(new int[] { 10, 22 }, 1, 30, new int[] { 10, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 22 }, TestName = "AddPos2_1")]
        [TestCase(new int[] { 10, 22 }, 2, 30, new int[] { 10, 22, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, TestName = "AddPos2_2")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, 0, 30, new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 10, 22, 34, 25, 67, 1, 23 }, TestName = "AddPosMany_0")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, 1, 30, new int[] { 10, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 22, 34, 25, 67, 1, 23 }, TestName = "AddPosMany_1")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, 2, 30, new int[] { 10, 22, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 34, 25, 67, 1, 23 }, TestName = "AddPosMany_2")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, 5, 30, new int[] { 10, 22, 34, 25, 67, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 1, 23 }, TestName = "AddPosMany_Many")]
        public void AddPos(int[] ar, int pos, int count, int[] exp)
        {
            list.Init(ar);
            for (int i = 0; i < count; i++)
            {
                list.AddPos(pos, i);
            }
            int[] res = list.ToArray();
            Assert.AreEqual(exp, res);
        }

        [TestCase(null, new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, 30, TestName = "AddStartNull")]
        [TestCase(new int[] { }, new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, 30, TestName = "AddStart0")]
        [TestCase(new int[] { 1 }, new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 1 }, 30, TestName = "AddStart1")]
        [TestCase(new int[] { 10, 22 }, new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 10, 22 }, 30, TestName = "AddStart2")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 10, 22, 34, 25, 67, 1, 23 }, 30, TestName = "AddStartMany")]
        public void AddStart(int[] ar, int[] exp, int count)
        {
            list.Init(ar);
            for (int i = 0; i < count; i++)
            {
                list.AddStart(i);
            }
            int[] res = list.ToArray();
            Assert.AreEqual(exp, res);
        }

        [TestCase(null, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 }, 30, TestName = "AddEndNull")]
        [TestCase(new int[] { }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 }, 30,  TestName = "AddEnd0")]
        [TestCase(new int[] { 1 }, new int[] { 1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 }, 30, TestName = "AddEnd1")]
        [TestCase(new int[] { 10, 22 }, new int[] { 10, 22, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 }, 30, TestName = "AddEnd2")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, new int[] { 10, 22, 34, 25, 67, 1, 23, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 }, 30, TestName = "AddEndMany")]
        public void AddEnd(int[] ar, int[] exp, int count)
        {
            list.Init(ar);
            for (int i = 0; i < count; i++)
            {
                list.AddEnd(i);
            }
            int[] res = list.ToArray();
            Assert.AreEqual(exp, res);
        }
    }
}
