using NUnit.Framework;
using List.Core;
using System;

namespace List.NUnitTests
{
    [TestFixture]
    public class AList0Test
    {
        private AList0 a;

        [SetUp]
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
        public void SizeTestMethodZero()
        {
            a.Init(new int[] {});
            Assert.AreEqual(0, a.Size());
        }

        [Test]
        public void SizeTestMethodOne()
        {
            a.Init(new[] {1});
            Assert.AreEqual(1, a.Size());
        }

        [Test]
        public void SizeTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            Assert.AreEqual(2, a.Size());
        }

        [Test]
        public void SizeTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            Assert.AreEqual(7, a.Size());
        }

        [Test]
        public void ClearTestMethodZero()
        {
            a.Init(new int[] {});
            a.Clear();
            CollectionAssert.AreEqual(new int[] {}, a.ToArray());
        }

        [Test]
        public void ClearTestMethodOne()
        {
            a.Init(new[] {1});
            a.Clear();
            CollectionAssert.AreEqual(new int[] {}, a.ToArray());
        }

        [Test]
        public void ClearTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            a.Clear();
            CollectionAssert.AreEqual(new int[] {}, a.ToArray());
        }

        [Test]
        public void ClearTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            a.Clear();
            CollectionAssert.AreEqual(new int[] {}, a.ToArray());
        }

        [Test]
        public void InitTestMethodZero()
        {
            a.Init(new int[] {});
            CollectionAssert.AreEqual(new int[] {}, a.ToArray());
        }

        [Test]
        public void InitTestMethodOne()
        {
            a.Init(new[] {1});
            CollectionAssert.AreEqual(new[] {1}, a.ToArray());
        }

        [Test]
        public void InitTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            CollectionAssert.AreEqual(new[] {1, 2}, a.ToArray());
        }

        [Test]
        public void InitTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            CollectionAssert.AreEqual(new[] {1, 2, 3, 4, 5, 6, 7}, a.ToArray());
        }

        [Test]
        public void InitTestMethodNull()
        {
            Assert.Throws<NullReferenceException>(() => a.Init(null));
        }

        [Test]
        public void ToArrayTestMethodZero()
        {
            a.Init(new int[] {});
            Assert.AreEqual(new int[] {}, a.ToArray());
        }

        [Test]
        public void ToStringTestMethodZero()
        {
            a.Init(new int[] {});
            Assert.AreEqual("", a.ToString());
        }

        [Test]
        public void ToStringTestMethodOne()
        {
            a.Init(new[] {1});
            Assert.AreEqual("1 ", a.ToString());
        }

        [Test]
        public void ToStringTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            Assert.AreEqual("1 2 ", a.ToString());
        }

        [Test]
        public void ToStringTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            Assert.AreEqual("1 2 3 4 5 6 7 ", a.ToString());
        }

        [Test]
        public void AddStartTestMethodZero()
        {
            a.Init(new int[] {});
            a.AddStart(1);
            CollectionAssert.AreEqual(new[] {1}, a.ToArray());
        }

        [Test]
        public void AddStartTestMethodOne()
        {
            a.Init(new[] {1});
            a.AddStart(1);
            CollectionAssert.AreEqual(new[] {1, 1}, a.ToArray());
        }

        [Test]
        public void AddStartTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            a.AddStart(1);
            CollectionAssert.AreEqual(new[] {1, 1, 2}, a.ToArray());
        }

        [Test]
        public void AddStartTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            a.AddStart(1);
            CollectionAssert.AreEqual(new[] {1, 1, 2, 3, 4, 5, 6, 7}, a.ToArray());
        }

        [Test]
        public void AddEndTestMethodZero()
        {
            a.Init(new int[] {});
            a.AddEnd(1);
            CollectionAssert.AreEqual(new[] {1}, a.ToArray());
        }

        [Test]
        public void AddEndTestMethodOne()
        {
            a.Init(new[] {1});
            a.AddEnd(1);
            CollectionAssert.AreEqual(new[] {1, 1}, a.ToArray());
        }

        [Test]
        public void AddEndTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            a.AddEnd(1);
            CollectionAssert.AreEqual(new[] {1, 2, 1}, a.ToArray());
        }

        [Test]
        public void AddEndTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            a.AddEnd(1);
            CollectionAssert.AreEqual(new[] {1, 2, 3, 4, 5, 6, 7, 1}, a.ToArray());
        }


        [Test]
        public void AddPosTestMethodZero()
        {
            a.Init(new int[] {});
            a.AddPos(1, 1);
            CollectionAssert.AreEqual(new[] {1}, a.ToArray());
        }

        [Test]
        public void AddPosTestMethodOne()
        {
            a.Init(new[] {1});
            a.AddPos(2, 1);
            CollectionAssert.AreEqual(new[] {1, 1}, a.ToArray());
        }

        [Test]
        public void AddPosTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            a.AddPos(2, 1);
            CollectionAssert.AreEqual(new[] {1, 1, 2}, a.ToArray());
        }

        [Test]
        public void AddPosTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            a.AddPos(3, 1);
            CollectionAssert.AreEqual(new[] {1, 2, 1, 3, 4, 5, 6, 7}, a.ToArray());
        }

        [Test]
        public void AddPosTestMethodNonePos()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            Assert.Throws<IndexOutOfRangeException>(() => a.AddPos(10, 1));
        }


        [Test]
        public void DelStartTestMethodZero()
        {
            a.Init(new int[] {});
            Assert.Throws<IndexOutOfRangeException>(() => a.DelStart());
        }

        [Test]
        public void DelStartTestMethodOne()
        {
            a.Init(new[] {1});
            Assert.AreEqual(1, a.DelStart());
        }

        [Test]
        public void DelStartTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            Assert.AreEqual(1, a.DelStart());
        }

        [Test]
        public void DelStartTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            Assert.AreEqual(1, a.DelStart());
        }

        [Test]
        public void DelEndTestMethodZero()
        {
            a.Init(new int[] {});
            Assert.Throws<IndexOutOfRangeException>(() => a.DelEnd());
        }

        [Test]
        public void DelEndTestMethodOne()
        {
            a.Init(new[] {1});
            Assert.AreEqual(1, a.DelEnd());
        }

        [Test]
        public void DelEndTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            Assert.AreEqual(2, a.DelEnd());
        }

        [Test]
        public void DelEndTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            Assert.AreEqual(7, a.DelEnd());
        }

        [Test]
        public void DelPosTestMethodZero()
        {
            a.Init(new int[] {});
            Assert.Throws<IndexOutOfRangeException>(() => a.DelPos(1));
        }

        [Test]
        public void DelPosTestMethodOne()
        {
            a.Init(new[] {1});
            Assert.AreEqual(1, a.DelPos(1));
        }

        [Test]
        public void DelPosTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            Assert.AreEqual(1, a.DelPos(1));
        }

        [Test]
        public void DelPosTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            Assert.AreEqual(3, a.DelPos(3));
        }

        [Test]
        public void SetTestMethodZero()
        {
            a.Init(new int[] {});
            Assert.Throws<IndexOutOfRangeException>(() => a.Set(1, 1));
        }

        [Test]
        public void SetTestMethodOne()
        {
            a.Init(new[] {1});
            a.Set(1, 2);
            CollectionAssert.AreEqual(new[] {2}, a.ToArray());
        }

        [Test]
        public void SetTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            a.Set(1, 2);
            CollectionAssert.AreEqual(new[] {2, 2}, a.ToArray());
        }

        [Test]
        public void SetTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            a.Set(3, 1);
            CollectionAssert.AreEqual(new[] {1, 2, 1, 4, 5, 6, 7}, a.ToArray());
        }

        [Test]
        public void GetTestMethodZero()
        {
            a.Init(new int[] {});
            Assert.Throws<IndexOutOfRangeException>(() => a.Get(1));
        }

        [Test]
        public void GetTestMethodOne()
        {
            a.Init(new[] {1});
            Assert.AreEqual(1, a.Get(1));
        }

        [Test]
        public void GetTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            Assert.AreEqual(1, a.Get(1));
        }

        [Test]
        public void GetTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            Assert.AreEqual(3, a.Get(3));
        }

        [Test]
        public void ReverseTestMethodZero()
        {
            a.Init(new int[] {});
            CollectionAssert.AreEqual(new int[] {}, a.Reverse());
        }

        [Test]
        public void ReverseTestMethodOne()
        {
            a.Init(new[] {1});
            CollectionAssert.AreEqual(new[] {1}, a.Reverse());
        }

        [Test]
        public void ReverseTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            CollectionAssert.AreEqual(new[] {2, 1}, a.Reverse());
        }

        [Test]
        public void ReverseTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            CollectionAssert.AreEqual(new[] {7, 6, 5, 4, 3, 2, 1}, a.Reverse());
        }

        [Test]
        public void HalfReverseTestMethodZero()
        {
            a.Init(new int[] {});
            CollectionAssert.AreEqual(new int[] {}, a.HalfReverse());
        }

        [Test]
        public void HalfReverseTestMethodOne()
        {
            a.Init(new[] {1});
            CollectionAssert.AreEqual(new[] {1}, a.HalfReverse());
        }

        [Test]
        public void HalfReverseTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            CollectionAssert.AreEqual(new[] {2, 1}, a.HalfReverse());
        }

        [Test]
        public void HalfReverseTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            CollectionAssert.AreEqual(new[] {5, 6, 7, 4, 1, 2, 3}, a.HalfReverse());
        }

        [Test]
        public void MinMethodZero()
        {
            a.Init(new int[] {});
            Assert.Throws<IndexOutOfRangeException>(() => a.Min());
        }

        [Test]
        public void MinTestMethodOne()
        {
            a.Init(new[] {1});
            Assert.AreEqual(1, a.Min());
        }

        [Test]
        public void MinTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            Assert.AreEqual(1, a.Min());
        }

        [Test]
        public void MinTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            Assert.AreEqual(1, a.Min());
        }

        [Test]
        public void MaxMethodZero()
        {
            a.Init(new int[] {});
            Assert.Throws<IndexOutOfRangeException>(() => a.Max());
        }

        [Test]
        public void MaxTestMethodOne()
        {
            a.Init(new[] {1});
            Assert.AreEqual(1, a.Max());
        }

        [Test]
        public void MaxTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            Assert.AreEqual(2, a.Max());
        }

        [Test]
        public void MaxTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            Assert.AreEqual(7, a.Max());
        }

        [Test]
        public void IndexMinMethodZero()
        {
            a.Init(new int[] {});
            Assert.AreEqual(0, a.IndMin());
        }

        [Test]
        public void IndexMinTestMethodOne()
        {
            a.Init(new[] {1});
            Assert.AreEqual(0, a.IndMin());
        }

        [Test]
        public void IndexMinTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            Assert.AreEqual(0, a.IndMin());
        }

        [Test]
        public void IndexMinTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            Assert.AreEqual(0, a.IndMin());
        }

        [Test]
        public void IndexMaxMethodZero()
        {
            a.Init(new int[] {});
            Assert.AreEqual(0, a.IndMax());
        }

        [Test]
        public void IndexMaxTestMethodOne()
        {
            a.Init(new[] {1});
            Assert.AreEqual(0, a.IndMax());
        }

        [Test]
        public void IndexMaxTestMethodTwo()
        {
            a.Init(new[] {1, 2});
            Assert.AreEqual(1, a.IndMax());
        }

        [Test]
        public void IndexMaxTestMethodMany()
        {
            a.Init(new[] {1, 2, 3, 4, 5, 6, 7});
            Assert.AreEqual(6, a.IndMax());
        }

        [Test]
        public void SortTestMethodZero()
        {
            a.Init(new int[] {});
            CollectionAssert.AreEqual(new int[] {}, a.Sort());
        }

        [Test]
        public void SortReverseTestMethodOne()
        {
            a.Init(new[] {1});
            CollectionAssert.AreEqual(new[] {1}, a.Sort());
        }

        [Test]
        public void SortReverseTestMethodTwo()
        {
            a.Init(new[] {2, 1});
            CollectionAssert.AreEqual(new[] {1, 2}, a.Sort());
        }

        [Test]
        public void SortReverseTestMethodMany()
        {
            a.Init(new[] {5, 6, 7, 4, 1, 2, 3});
            CollectionAssert.AreEqual(new[] {1, 2, 3, 4, 5, 6, 7}, a.Sort());
        }
    }
}