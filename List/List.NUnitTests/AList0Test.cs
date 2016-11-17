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
        public void SizeShouldReturn0()
        {
            a.Init(new int[] { });
            Assert.AreEqual(0, a.Size());
        }

        [Test]
        public void SizeShouldReturn1()
        {
            a.Init(new[] { 1 });
            Assert.AreEqual(1, a.Size());
        }

        [Test]
        public void SizeShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            Assert.AreEqual(2, a.Size());
        }

        [Test]
        public void SizeShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.AreEqual(7, a.Size());
        }

        [Test]
        public void ClearShouldReturn0()
        {
            a.Init(new int[] { });
            a.Clear();
            CollectionAssert.AreEqual(new int[] { }, a.ToArray());
        }

        [Test]
        public void ClearShouldReturn1()
        {
            a.Init(new[] { 1 });
            a.Clear();
            CollectionAssert.AreEqual(new int[] { }, a.ToArray());
        }

        [Test]
        public void ClearShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            a.Clear();
            CollectionAssert.AreEqual(new int[] { }, a.ToArray());
        }

        [Test]
        public void ClearShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            a.Clear();
            CollectionAssert.AreEqual(new int[] { }, a.ToArray());
        }

        [Test]
        public void InitShouldReturn0()
        {
            a.Init(new int[] { });
            CollectionAssert.AreEqual(new int[] { }, a.ToArray());
        }

        [Test]
        public void InitShouldReturn1()
        {
            a.Init(new[] { 1 });
            CollectionAssert.AreEqual(new[] { 1 }, a.ToArray());
        }

        [Test]
        public void InitShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            CollectionAssert.AreEqual(new[] { 1, 2 }, a.ToArray());
        }

        [Test]
        public void InitShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, a.ToArray());
        }

        [Test]
        public void InitShouldRaiseNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => a.Init(null));
        }

        [Test]
        public void ToArrayShouldReturn0()
        {
            a.Init(new int[] { });
            Assert.AreEqual(new int[] { }, a.ToArray());
        }

        [Test]
        public void ToStringShouldReturn0()
        {
            a.Init(new int[] { });
            Assert.AreEqual("", a.ToString());
        }

        [Test]
        public void ToStringShouldReturn1()
        {
            a.Init(new[] { 1 });
            Assert.AreEqual("1 ", a.ToString());
        }

        [Test]
        public void ToStringShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            Assert.AreEqual("1 2 ", a.ToString());
        }

        [Test]
        public void ToStringShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.AreEqual("1 2 3 4 5 6 7 ", a.ToString());
        }

        [Test]
        public void AddStartShouldReturn0()
        {
            a.Init(new int[] { });
            a.AddStart(1);
            CollectionAssert.AreEqual(new[] { 1 }, a.ToArray());
        }

        [Test]
        public void AddStartShouldReturn1()
        {
            a.Init(new[] { 1 });
            a.AddStart(1);
            CollectionAssert.AreEqual(new[] { 1, 1 }, a.ToArray());
        }

        [Test]
        public void AddStartShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            a.AddStart(1);
            CollectionAssert.AreEqual(new[] { 1, 1, 2 }, a.ToArray());
        }

        [Test]
        public void AddStartShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            a.AddStart(1);
            CollectionAssert.AreEqual(new[] { 1, 1, 2, 3, 4, 5, 6, 7 }, a.ToArray());
        }

        [Test]
        public void AddEndShouldReturn0()
        {
            a.Init(new int[] { });
            a.AddEnd(1);
            CollectionAssert.AreEqual(new[] { 1 }, a.ToArray());
        }

        [Test]
        public void AddEndShouldReturn1()
        {
            a.Init(new[] { 1 });
            a.AddEnd(1);
            CollectionAssert.AreEqual(new[] { 1, 1 }, a.ToArray());
        }

        [Test]
        public void AddEndShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            a.AddEnd(1);
            CollectionAssert.AreEqual(new[] { 1, 2, 1 }, a.ToArray());
        }

        [Test]
        public void AddEndShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            a.AddEnd(1);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 1 }, a.ToArray());
        }


        [Test]
        public void AddPosShouldReturn0()
        {
            a.Init(new int[] { });
            a.AddPos(1, 1);
            CollectionAssert.AreEqual(new[] { 1 }, a.ToArray());
        }

        [Test]
        public void AddPosShouldReturn1()
        {
            a.Init(new[] { 1 });
            a.AddPos(2, 1);
            CollectionAssert.AreEqual(new[] { 1, 1 }, a.ToArray());
        }

        [Test]
        public void AddPosShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            a.AddPos(2, 1);
            CollectionAssert.AreEqual(new[] { 1, 1, 2 }, a.ToArray());
        }

        [Test]
        public void AddPosShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            a.AddPos(3, 1);
            CollectionAssert.AreEqual(new[] { 1, 2, 1, 3, 4, 5, 6, 7 }, a.ToArray());
        }

        [Test]
        public void AddPosShouldRaiseIndexOutOfRangeException()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.Throws<IndexOutOfRangeException>(() => a.AddPos(10, 1));
        }


        [Test]
        public void DelStartShouldRaiseIndexOutOfRangeException()
        {
            a.Init(new int[] { });
            Assert.Throws<IndexOutOfRangeException>(() => a.DelStart());
        }

        [Test]
        public void DelStartShouldReturn1()
        {
            a.Init(new[] { 1 });
            Assert.AreEqual(1, a.DelStart());
        }

        [Test]
        public void DelStartShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            Assert.AreEqual(1, a.DelStart());
        }

        [Test]
        public void DelStartShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.AreEqual(1, a.DelStart());
        }

        [Test]
        public void DelEndShouldRaiseIndexOutOfRangeException()
        {
            a.Init(new int[] { });
            Assert.Throws<IndexOutOfRangeException>(() => a.DelEnd());
        }

        [Test]
        public void DelEndShouldReturn1()
        {
            a.Init(new[] { 1 });
            Assert.AreEqual(1, a.DelEnd());
        }

        [Test]
        public void DelEndShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            Assert.AreEqual(2, a.DelEnd());
        }

        [Test]
        public void DelEndShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.AreEqual(7, a.DelEnd());
        }

        [Test]
        public void DelPosShouldRaiseIndexOutOfRangeException()
        {
            a.Init(new int[] { });
            Assert.Throws<IndexOutOfRangeException>(() => a.DelPos(1));
        }

        [Test]
        public void DelPosShouldReturn1()
        {
            a.Init(new[] { 1 });
            Assert.AreEqual(1, a.DelPos(1));
        }

        [Test]
        public void DelPosShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            Assert.AreEqual(1, a.DelPos(1));
        }

        [Test]
        public void DelPosShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.AreEqual(3, a.DelPos(3));
        }

        [Test]
        public void SetShouldRaiseIndexOutOfRangeException()
        {
            a.Init(new int[] { });
            Assert.Throws<IndexOutOfRangeException>(() => a.Set(1, 1));
        }

        [Test]
        public void SetShouldReturn1()
        {
            a.Init(new[] { 1 });
            a.Set(1, 2);
            CollectionAssert.AreEqual(new[] { 2 }, a.ToArray());
        }

        [Test]
        public void SetShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            a.Set(1, 2);
            CollectionAssert.AreEqual(new[] { 2, 2 }, a.ToArray());
        }

        [Test]
        public void SetShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            a.Set(3, 1);
            CollectionAssert.AreEqual(new[] { 1, 2, 1, 4, 5, 6, 7 }, a.ToArray());
        }

        [Test]
        public void GetShouldRaiseIndexOutOfRangeException()
        {
            a.Init(new int[] { });
            Assert.Throws<IndexOutOfRangeException>(() => a.Get(1));
        }

        [Test]
        public void GetShouldReturn1()
        {
            a.Init(new[] { 1 });
            Assert.AreEqual(1, a.Get(1));
        }

        [Test]
        public void GetShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            Assert.AreEqual(1, a.Get(1));
        }

        [Test]
        public void GetShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.AreEqual(3, a.Get(3));
        }

        [Test]
        public void ReverseShouldReturn0()
        {
            a.Init(new int[] { });
            CollectionAssert.AreEqual(new int[] { }, a.Reverse());
        }

        [Test]
        public void ReverseShouldReturn1()
        {
            a.Init(new[] { 1 });
            CollectionAssert.AreEqual(new[] { 1 }, a.Reverse());
        }

        [Test]
        public void ReverseShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            CollectionAssert.AreEqual(new[] { 2, 1 }, a.Reverse());
        }

        [Test]
        public void ReverseShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            CollectionAssert.AreEqual(new[] { 7, 6, 5, 4, 3, 2, 1 }, a.Reverse());
        }

        [Test]
        public void HalfReverseShouldReturn0()
        {
            a.Init(new int[] { });
            CollectionAssert.AreEqual(new int[] { }, a.HalfReverse());
        }

        [Test]
        public void HalfReverseShouldReturn1()
        {
            a.Init(new[] { 1 });
            CollectionAssert.AreEqual(new[] { 1 }, a.HalfReverse());
        }

        [Test]
        public void HalfReverseShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            CollectionAssert.AreEqual(new[] { 2, 1 }, a.HalfReverse());
        }

        [Test]
        public void HalfReverseShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            CollectionAssert.AreEqual(new[] { 5, 6, 7, 4, 1, 2, 3 }, a.HalfReverse());
        }

        [Test]
        public void MinMethodShouldRaiseIndexOutOfRangeException()
        {
            a.Init(new int[] { });
            Assert.Throws<IndexOutOfRangeException>(() => a.Min());
        }

        [Test]
        public void MinShouldReturn1()
        {
            a.Init(new[] { 1 });
            Assert.AreEqual(1, a.Min());
        }

        [Test]
        public void MinShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            Assert.AreEqual(1, a.Min());
        }

        [Test]
        public void MinShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.AreEqual(1, a.Min());
        }

        [Test]
        public void MaxShouldRaiseIndexOutOfRangeException()
        {
            a.Init(new int[] { });
            Assert.Throws<IndexOutOfRangeException>(() => a.Max());
        }

        [Test]
        public void MaxShouldReturn1()
        {
            a.Init(new[] { 1 });
            Assert.AreEqual(1, a.Max());
        }

        [Test]
        public void MaxShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            Assert.AreEqual(2, a.Max());
        }

        [Test]
        public void MaxShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.AreEqual(7, a.Max());
        }

        [Test]
        public void IndexMinShouldReturn0()
        {
            a.Init(new int[] { });
            Assert.AreEqual(0, a.IndMin());
        }

        [Test]
        public void IndexMinShouldReturn1()
        {
            a.Init(new[] { 1 });
            Assert.AreEqual(0, a.IndMin());
        }

        [Test]
        public void IndexMinShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            Assert.AreEqual(0, a.IndMin());
        }

        [Test]
        public void IndexMinShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.AreEqual(0, a.IndMin());
        }

        [Test]
        public void IndexMaxMShould0()
        {
            a.Init(new int[] { });
            Assert.AreEqual(0, a.IndMax());
        }

        [Test]
        public void IndexMaxShouldReturn1()
        {
            a.Init(new[] { 1 });
            Assert.AreEqual(0, a.IndMax());
        }

        [Test]
        public void IndexMaxShouldReturn2()
        {
            a.Init(new[] { 1, 2 });
            Assert.AreEqual(1, a.IndMax());
        }

        [Test]
        public void IndexMaxShouldReturnMany()
        {
            a.Init(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.AreEqual(6, a.IndMax());
        }

        [Test]
        public void SortShouldReturn0()
        {
            a.Init(new int[] { });
            CollectionAssert.AreEqual(new int[] { }, a.Sort());
        }

        [Test]
        public void SortReverseShouldReturn1()
        {
            a.Init(new[] { 1 });
            CollectionAssert.AreEqual(new[] { 1 }, a.Sort());
        }

        [Test]
        public void SortReverseShouldReturn2()
        {
            a.Init(new[] { 2, 1 });
            CollectionAssert.AreEqual(new[] { 1, 2 }, a.Sort());
        }

        [Test]
        public void SortReverseShouldReturnMany()
        {
            a.Init(new[] { 5, 6, 7, 4, 1, 2, 3 });
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, a.Sort());
        }
    }
}