using System;
using NUnit.Framework;
using List.Core;

namespace List.NUnitResizeTests
{
    [TestFixture(typeof(AList1))]
    [TestFixture(typeof(AList2))]
    [TestFixture(typeof(AListR))]

    public class ListResizeTest<TList> where TList : IList, new()
    {
        private TList list = new TList();

        [TestCase(new int[] { 1, 2, 3, 5, 4, 7, 6, 8, 1, 2, 1, 4, 6, 1 }, Result = new int[] { 1, 2, 3, 5, 4, 7, 6, 8, 1, 2, 1, 4, 6, 1 }, TestName = "TestInitReallocate")]
        public int[] TestInitReallocate(int[] array)
        {
            list.Init(array);
            return list.ToArray();
        }

        [TestCase(null, 5, 30, ExpectedException = typeof(IndexOutOfRangeException), TestName = "TestAddPosReallocateNull_Exception1")]
        [TestCase(null, -1, 30, ExpectedException = typeof(IndexOutOfRangeException), TestName = "TestAddPosReallocateNull_Exception2")]
        [TestCase(null, 0, 30, Result = new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, TestName = "TestAddPosReallocateNull")]
        [TestCase(new int[] { }, 5, 30, ExpectedException = typeof(IndexOutOfRangeException), TestName = "TestAddPosReallocate0_Exception1")]
        [TestCase(new int[] { }, -1, 30, ExpectedException = typeof(IndexOutOfRangeException), TestName = "TestAddPosReallocate0_Exception2")]
        [TestCase(new int[] { }, 0, 30, Result = new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, TestName = "TestAddPosReallocate0")]
        [TestCase(new int[] { 1 }, 5, 30, ExpectedException = typeof(IndexOutOfRangeException), TestName = "TestAddPosReallocate1_Exception1")]
        [TestCase(new int[] { 1 }, -1, 30, ExpectedException = typeof(IndexOutOfRangeException), TestName = "TestAddPosReallocate1_Exception2")]
        [TestCase(new int[] { 1 }, 0, 30, Result = new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 1 }, TestName = "TestAddPosReallocate1_0")]
        [TestCase(new int[] { 1 }, 1, 30, Result = new int[] { 1, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, TestName = "TestAddPosReallocate1_1")]
        [TestCase(new int[] { 10, 22 }, 5, 30, ExpectedException = typeof(IndexOutOfRangeException), TestName = "TestAddPosReallocate2_Exception1")]
        [TestCase(new int[] { 10, 22 }, -1, 30, ExpectedException = typeof(IndexOutOfRangeException), TestName = "TestAddPosReallocate2_Exception2")]
        [TestCase(new int[] { 10, 22 }, 0, 30, Result = new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 10, 22 }, TestName = "TestAddPosReallocate2_0")]
        [TestCase(new int[] { 10, 22 }, 1, 30, Result = new int[] { 10, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 22 }, TestName = "TestAddPosReallocate2_1")]
        [TestCase(new int[] { 10, 22 }, 2, 30, Result = new int[] { 10, 22, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, TestName = "TestAddPosReallocate2_2")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, 15, 30, ExpectedException = typeof(IndexOutOfRangeException), TestName = "TestAddPosReallocateMany_Exception1")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, -1, 30, ExpectedException = typeof(IndexOutOfRangeException), TestName = "TestAddPosReallocateMany_Exception2")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, 0, 30, Result = new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 10, 22, 34, 25, 67, 1, 23 }, TestName = "TestAddPosReallocate2_0")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, 1, 30, Result = new int[] { 10, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 22, 34, 25, 67, 1, 23 }, TestName = "TestAddPosReallocate2_1")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, 2, 30, Result = new int[] { 10, 22, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 34, 25, 67, 1, 23 }, TestName = "TestAddPosReallocate2_2")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, 5, 30, Result = new int[] { 10, 22, 34, 25, 67, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 1, 23 }, TestName = "TestAddPosReallocate2_5")]
        public int[] TestAddPosReallocate(int[] array, int pos, int count)
        {
            list.Init(array);
            for (int i = 0; i < count; i++)
            {
                list.AddPos(pos, i);
            }
            return list.ToArray();
        }

        [TestCase(null, 30, Result = new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, TestName = "TestAddStartReallocateNull")]
        [TestCase(new int[] { }, 30, Result = new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, TestName = "TestAddStartReallocate0")]
        [TestCase(new int[] { 1 }, 30, Result = new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 1 }, TestName = "TestAddStartReallocate1")]
        [TestCase(new int[] { 10, 22 }, 30, Result = new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 10, 22 }, TestName = "TestAddStartReallocate2")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, 30, Result = new int[] { 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 10, 22, 34, 25, 67, 1, 23 }, TestName = "TestAddStartReallocate2")]
        public int[] TestAddStartReallocate(int[] array, int count)
        {
            list.Init(array);
            for (int i = 0; i < count; i++)
            {
                list.AddStart(i);
            }
            return list.ToArray();
        }

        [TestCase(null, 30, Result = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 }, TestName = "TestAddEndReallocateNull")]
        [TestCase(new int[] { }, 30, Result = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 }, TestName = "TestAddEndReallocate0")]
        [TestCase(new int[] { 1 }, 30, Result = new int[] { 1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 }, TestName = "TestAddEndReallocate1")]
        [TestCase(new int[] { 10, 22 }, 30, Result = new int[] { 10, 22, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 }, TestName = "TestAddEndReallocate2")]
        [TestCase(new int[] { 10, 22, 34, 25, 67, 1, 23 }, 30, Result = new int[] { 10, 22, 34, 25, 67, 1, 23, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 }, TestName = "TestAddEndReallocate2")]
        public int[] TestAddEndReallocate(int[] array, int count)
        {
            list.Init(array);
            for (int i = 0; i < count; i++)
            {
                list.AddEnd(i);
            }
            return list.ToArray();
        }
    }
}
