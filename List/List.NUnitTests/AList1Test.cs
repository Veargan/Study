using NUnit.Framework;
using System;
using List.Core;

namespace List.NUnitTests
{
    [TestFixture]
    public class AList1Test
    {
        private AList1 a;

        [SetUp]
        protected void SetUp()
        {
            a = new AList1();
        }

        [TearDown]
        public void TearDown()
        {
            a = null;
        }

        [Test]
        public void testInit_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.Init(zz));
        }

        [Test]
        public void testInit_0()
        {
            int[] zz = {};
            int[] exp = {};
            a.SetArray(zz);
            int[] res = a.ToArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testInit_1()
        {
            int[] zz = {10};
            int[] exp = {10};
            a.SetArray(zz);
            int[] res = a.ToArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testInit_2()
        {
            int[] zz = {10, 15};
            int[] exp = {10, 15};
            a.SetArray(zz);
            int[] res = a.ToArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testInit_many()
        {
            int[] zz = {10, 15, 20, 25, 30};
            int[] exp = {10, 15, 20, 25, 30};
            a.SetArray(zz);
            int[] res = a.ToArray();
            CollectionAssert.AreEqual(exp, res);
        }


        [Test]
        public void testToArray_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }

        [Test]
        public void testToArray_0()
        {
            int[] zz = {};
            int[] exp = {};
            a.SetArray(zz);
            int[] res = a.ToArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testToArray_1()
        {
            int[] zz = {10};
            int[] exp = {10};
            a.SetArray(zz);
            int[] res = a.ToArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testToArray_2()
        {
            int[] zz = {10, 15};
            int[] exp = {10, 15};
            a.SetArray(zz);
            int[] res = a.ToArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testToArray_many()
        {
            int[] zz = {10, 15, 20, 25, 30};
            int[] exp = {10, 15, 20, 25, 30};
            a.SetArray(zz);
            int[] res = a.ToArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testAddStart_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }

        [Test]
        public void testAddStart_0()
        {
            int[] zz = {};
            int[] exp = {5};
            a.SetArray(zz);
            a.AddStart(5);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testAddStart_1()
        {
            int[] zz = {10};
            int[] exp = {5, 10};
            a.SetArray(zz);
            a.AddStart(5);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testAddStart_2()
        {
            int[] zz = {10, 20};
            int[] exp = {5, 10, 20};
            a.SetArray(zz);
            a.AddStart(5);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testAddStart_many()
        {
            int[] zz = {10, 20, 77, 11, 24, 99, 32};
            int[] exp = {5, 10, 20, 77, 11, 24, 99, 32};
            a.SetArray(zz);
            a.AddStart(5);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }


        [Test]
        public void testAddEnd_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }

        [Test]
        public void testAddEnd_0()
        {
            int[] zz = {};
            int[] exp = {5};
            a.SetArray(zz);
            a.AddEnd(5);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testAddEnd_1()
        {
            int[] zz = {10};
            int[] exp = {10, 5};
            a.SetArray(zz);
            a.AddEnd(5);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testAddEnd_2()
        {
            int[] zz = {10, 20};
            int[] exp = {10, 20, 5};
            a.SetArray(zz);
            a.AddEnd(5);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testAddEnd_many()
        {
            int[] zz = {10, 20, 77, 11, 24, 99, 32};
            int[] exp = {10, 20, 77, 11, 24, 99, 32, 5};
            a.SetArray(zz);
            a.AddEnd(5);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }


        [Test]
        public void testAddPos_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }

        [Test]
        public void testAddPos_0()
        {
            int[] zz = {};
            int[] exp = {5};
            a.SetArray(zz);
            a.AddPos(0, 5);
            CollectionAssert.AreEqual(exp, a.GetArray());
        }

        [Test]
        public void testAddPos_1()
        {
            int[] zz = {10, 5};
            int[] exp = {2, 10, 5};
            a.SetArray(zz);
            a.AddPos(0, 2);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testAddPos_2()
        {
            int[] zz = {10, 20};
            int[] exp = {10, 5, 20};
            a.SetArray(zz);
            a.AddPos(1, 5);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testAddPos_many()
        {
            int[] zz = {10, 20, 77, 11, 24, 99, 32};
            int[] exp = {10, 20, 77, 11, 154, 24, 99, 32};

            a.SetArray(zz);
            a.AddPos(4, 154);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }


        [Test]
        public void testDelStart_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }


        [Test]
        public void testDelStart_0()
        {
            int[] zz = {};
            a.SetArray(zz);
            Assert.Throws<IndexOutOfRangeException>(() => a.DelStart());
        }

        [Test]
        public void testDelStart_1()
        {
            int[] zz = {10};
            int[] exp = {};
            a.SetArray(zz);
            a.DelStart();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testDelStart_2()
        {
            int[] zz = {10, 20};
            int[] exp = {20};

            a.SetArray(zz);
            a.DelStart();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testDelStart_many()
        {
            int[] zz = {10, 20, 77, 11, 24, 99, 32};
            int[] exp = {20, 77, 11, 24, 99, 32};

            a.SetArray(zz);
            a.DelStart();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }


        [Test]
        public void testDelEnd_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }


        [Test]
        public void testDelEnd_0()
        {
            int[] zz = {};
            a.SetArray(zz);
            Assert.Throws<IndexOutOfRangeException>(() => a.DelEnd());
        }

        [Test]
        public void testDelEnd_1()
        {
            int[] zz = {10};
            int[] exp = {};
            a.SetArray(zz);
            a.DelEnd();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testDelEnd_2()
        {
            int[] zz = {10, 20};
            int[] exp = {10};

            a.SetArray(zz);
            a.DelEnd();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testDelEnd_many()
        {
            int[] zz = {10, 20, 77, 11, 24, 99, 32};
            int[] exp = {10, 20, 77, 11, 24, 99};

            a.SetArray(zz);
            a.DelEnd();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }


        [Test]
        public void testDelPos_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }


        [Test]
        public void testDelPos_0()
        {
            int[] zz = {};
            a.SetArray(zz);
            Assert.Throws<IndexOutOfRangeException>(() => a.DelPos(0));
        }

        [Test]
        public void testDelPos_1()
        {
            int[] zz = {10};
            int[] exp = {};
            a.SetArray(zz);
            a.DelPos(0);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testDelPos_2()
        {
            int[] zz = {10, 20};
            int[] exp = {10};
            a.SetArray(zz);
            a.DelPos(1);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testDelPos_many()
        {
            int[] zz = {10, 20, 77, 11, 24, 99, 32};
            int[] exp = {10, 20, 77, 11, 99, 32};
            a.SetArray(zz);
            a.DelPos(4);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }


        [Test]
        public void testClear_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }

        [Test]
        public void testClear_0()
        {
            int[] zz = {};
            int[] exp = {};
            a.SetArray(zz);
            a.Clear();
            CollectionAssert.AreEqual(exp, a.ToArray());
        }

        [Test]
        public void testClear_1()
        {
            int[] zz = {10};
            int[] exp = {};
            a.SetArray(zz);
            a.Clear();
            CollectionAssert.AreEqual(exp, a.ToArray());
        }

        [Test]
        public void testClear_2()
        {
            int[] zz = {10, 54};
            int[] exp = {};
            a.SetArray(zz);
            a.Clear();
            CollectionAssert.AreEqual(exp, a.ToArray());
        }

        [Test]
        public void testClear_many()
        {
            int[] zz = {25, 11, 45, 23, 66};
            int[] exp = {};
            a.SetArray(zz);
            a.Clear();
            CollectionAssert.AreEqual(exp, a.ToArray());
        }


        [Test]
        public void testSize_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }

        [Test]
        public void testSize_0()
        {
            int[] zz = {};
            int exp = 0;
            a.SetArray(zz);
            int res = a.Size();
            Assert.AreEqual(exp, res);
        }

        [Test]
        public void testSize_1()
        {
            int[] zz = {10};
            int exp = 1;
            a.SetArray(zz);
            int res = a.Size();
            Assert.AreEqual(exp, res);
        }

        [Test]
        public void testSize_2()
        {
            int[] zz = {10, 25};
            int exp = 2;
            a.SetArray(zz);
            int res = a.Size();
            Assert.AreEqual(exp, res);
        }

        [Test]
        public void testSize_many()
        {
            int[] zz = {10, 25, 66, 85, 44};
            int exp = 5;
            a.SetArray(zz);
            int res = a.Size();
            Assert.AreEqual(exp, res);
        }


        [Test]
        public void testSet_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }


        [Test]
        public void testSet_0()
        {
            int[] zz = {};
            a.SetArray(zz);
            Assert.Throws<IndexOutOfRangeException>(() => a.Set(0, 5));
        }

        [Test]
        public void testSet_1()
        {
            int[] zz = {10};
            int[] exp = {5};
            a.SetArray(zz);
            a.Set(0, 5);
            CollectionAssert.AreEqual(exp, a.GetArray());
        }

        [Test]
        public void testSet_2()
        {
            int[] zz = {10, 15};
            int[] exp = {5, 15};
            a.SetArray(zz);
            a.Set(0, 5);
            CollectionAssert.AreEqual(exp, a.GetArray());
        }

        [Test]
        public void testSet_many()
        {
            int[] zz = {10, 15, 20, 25, 30};
            int[] exp = {10, 15, 50, 25, 30};
            a.SetArray(zz);
            a.Set(2, 50);
            CollectionAssert.AreEqual(exp, a.GetArray());
        }


        [Test]
        public void testGet_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }


        [Test]
        public void testGet_0()
        {
            int[] zz = {};
            a.SetArray(zz);
            Assert.Throws<IndexOutOfRangeException>(() => a.Get(0));
        }

        [Test]
        public void testGet_1()
        {
            int[] zz = {10};
            int exp = 10;
            a.SetArray(zz);
            int res = a.Get(0);
            Assert.AreEqual(exp, res);
        }

        [Test]
        public void testGet_2()
        {
            int[] zz = {10, 25};
            int exp = 10;
            a.SetArray(zz);
            int res = a.Get(0);
            Assert.AreEqual(exp, res);
        }

        [Test]
        public void testGet_many()
        {
            int[] zz = {10, 15, 20, 25, 30};
            int exp = 20;
            a.SetArray(zz);
            int res = a.Get(2);
            Assert.AreEqual(exp, res);
        }


        [Test]
        public void testMax_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }


        [Test]
        public void testMax_0()
        {
            int[] zz = {};
            a.SetArray(zz);
            Assert.Throws<IndexOutOfRangeException>(() => a.Max());
        }

        [Test]
        public void testMax_1()
        {
            int[] zz = {10};
            a.SetArray(zz);
            int res = a.Max();
            Assert.AreEqual(10, res);
        }

        [Test]
        public void testMax_2()
        {
            int[] zz = {10, 20};
            a.SetArray(zz);
            int res = a.Max();
            Assert.AreEqual(20, res);
        }

        [Test]
        public void testMax_many()
        {
            int[] zz = {10, 20, 77, 11, 24, 99, 32};
            a.SetArray(zz);
            int res = a.Max();
            Assert.AreEqual(99, res);
        }


        [Test]
        public void testMin_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }


        [Test]
        public void testMin_0()
        {
            int[] zz = {};
            a.SetArray(zz);
            Assert.Throws<IndexOutOfRangeException>(() => a.Min());
        }

        [Test]
        public void testMin_1()
        {
            int[] zz = {10};
            a.SetArray(zz);
            int res = a.Min();
            Assert.AreEqual(10, res);
        }

        [Test]
        public void testMin_2()
        {
            int[] zz = {10, 20};
            a.SetArray(zz);
            int res = a.Min();
            Assert.AreEqual(10, res);
        }

        [Test]
        public void testMin_many()
        {
            int[] zz = {10, 20, 77, 11, 24, 99, 32};
            a.SetArray(zz);
            int res = a.Min();
            Assert.AreEqual(10, res);
        }


        [Test]
        public void testMaxIndex_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }


        [Test]
        public void testMaxIndex_0()
        {
            int[] zz = {};
            a.SetArray(zz);
            Assert.Throws<IndexOutOfRangeException>(() => a.MaxIndex());
        }

        [Test]
        public void testMaxIndex_1()
        {
            int[] zz = {10};
            a.SetArray(zz);
            int res = a.MaxIndex();
            Assert.AreEqual(0, res);
        }

        [Test]
        public void testMaxIndex_2()
        {
            int[] zz = {10, 20};
            a.SetArray(zz);
            int res = a.MaxIndex();
            Assert.AreEqual(1, res);
        }

        [Test]
        public void testMaxIndex_many()
        {
            int[] zz = {10, 20, 77, 11, 24, 99, 32};
            a.SetArray(zz);
            int res = a.MaxIndex();
            Assert.AreEqual(5, res);
        }

        // ======================================
        // MinIndex
        // ======================================
        [Test]
        public void testMinIndex_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }

        [Test]
        public void testMinIndex_0()
        {
            int[] zz = {};
            a.SetArray(zz);
            Assert.Throws<IndexOutOfRangeException>(() => a.MinIndex());
        }

        [Test]
        public void testMinIndex_1()
        {
            int[] zz = {10};
            a.SetArray(zz);
            int res = a.MinIndex();
            Assert.AreEqual(0, res);
        }

        [Test]
        public void testMinIndex_2()
        {
            int[] zz = {10, 20};
            a.SetArray(zz);
            int res = a.MinIndex();
            Assert.AreEqual(0, res);
        }

        [Test]
        public void testMinIndex_many()
        {
            int[] zz = {10, 20, 77, 11, 24, 99, 32};
            a.SetArray(zz);
            int res = a.MinIndex();
            Assert.AreEqual(0, res);
        }


        [Test]
        public void testReversArr_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }

        [Test]
        public void testReversArr_0()
        {
            int[] zz = {};
            int[] exp = {};
            a.SetArray(zz);
            a.Reverse();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testReversArr_1()
        {
            int[] zz = {10};
            a.SetArray(zz);
            a.Reverse();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(zz, res);
        }

        [Test]
        public void testReversArr_2()
        {
            int[] zz = {10, 20};
            int[] exp = {20, 10};
            a.SetArray(zz);
            a.Reverse();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testReversArr_many()
        {
            int[] zz = {10, 20, 77, 11, 24, 99, 32};
            int[] exp = {32, 99, 24, 11, 77, 20, 10};
            a.SetArray(zz);
            a.Reverse();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testHalfReversArr_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }

        [Test]
        public void testHalfReversArr_0()
        {
            int[] zz = {};
            int[] exp = {};
            a.SetArray(zz);
            a.HalfReverse();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testHalfReversArr_1()
        {
            int[] zz = {10};
            a.SetArray(zz);
            a.HalfReverse();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(zz, res);
        }

        [Test]
        public void testHalfReversArr_2()
        {
            int[] zz = {10, 20};
            int[] exp = {20, 10};
            a.SetArray(zz);
            a.HalfReverse();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testHalfReversArr_4()
        {
            int[] zz = {10, 20, 30, 40};
            int[] exp = {20, 10, 30, 40};
            a.SetArray(zz);
            a.HalfReverse();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testHalfReversArr_many()
        {
            int[] zz = {10, 20, 77, 11, 24, 99, 32};
            int[] exp = {32, 99, 24, 11, 24, 99, 32};
            a.SetArray(zz);
            a.HalfReverse();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }


        [Test]
        public void testSortArr_NULL()
        {
            int[] zz = null;
            Assert.Throws<NullReferenceException>(() => a.SetArray(zz));
        }

        [Test]
        public void testSortArr_0()
        {
            int[] zz = {};
            int[] exp = {};
            a.SetArray(zz);
            a.Sort();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testSortArr_1()
        {
            int[] zz = {10};
            a.SetArray(zz);
            a.Sort();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(zz, res);
        }

        [Test]
        public void testSortArr_2()
        {
            int[] zz = {10, 20};
            int[] exp = {10, 20};
            a.SetArray(zz);
            a.Sort();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testSortArr_many()
        {
            int[] zz = {20, 10, 77, 11, 24, 99, 32};
            int[] exp = {10, 11, 20, 24, 32, 77, 99};
            a.SetArray(zz);
            a.Sort();
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }

        [Test]
        public void testTEMP()
        {
            int[] zz = {10, 20, 32};
            int[] exp = {10, 20, 32, 5};
            a.Init(zz);
            a.AddEnd(5);
            int[] res = a.GetArray();
            CollectionAssert.AreEqual(exp, res);
        }
    }
}