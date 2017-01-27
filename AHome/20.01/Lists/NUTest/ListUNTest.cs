using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Lists;
using RelevantCodes.ExtentReports;

namespace NUTest
{

    [TestFixture(typeof(AList2))]

    public class ListUNTest<TList> where TList : IList, new()
    {
        private TList lst = new TList();

        //Min
        [TestCase(new int[] { 2 }, 2, TestName="One elem")]
        [TestCase(new int[] { 2, 1 }, 1, TestName="Two elems")]
        [TestCase(new int[] { 1, 2, -9, 3, -5 }, -9, TestName="Aver elem")]
        [TestCase(new int[] { -10, 2, -9, 3, -5 }, -10, TestName="First elem")]
        [TestCase(new int[] { 1, 2, -9, 3, -15 }, -15, TestName="Last elem")]
        [TestCase(new int[] { 2, 2, 2 }, 2, TestName="Same elems")]
        public void GetMinTest(int[] array, int result)
        {
            lst.Init(array);
            Assert.AreEqual(result, lst.Min());
        }

        [Test]
        public void GetMinCatchTest()
        {
            lst.Init(new int[] { });
            Assert.That(() => lst.Min(), Throws.Exception);
        }

        [Test]
        public void GetMinCatchTest2()
        {
            Assert.That(() => lst.Min(), Throws.Exception);
        }

        //Max
        [TestCase(new int[] { 2 }, 2)]
        [TestCase(new int[] { 2, 1 }, 2)]
        [TestCase(new int[] { 1, 2, 10, 3, -5 }, 10)]
        [TestCase(new int[] { 11, 2, -9, 3, -5 }, 11)]
        [TestCase(new int[] { 1, 2, -9, 3, 15 }, 15)]
        [TestCase(new int[] { 2, 2, 2 }, 2)]
        public void GetMaxTest(int[] array, int result)
        {
            lst.Init(array);
            Assert.AreEqual(result, lst.Max());
        }

        [Test]
        public void GetMaxCatchTest()
        {
            lst.Init(new int[] { });
            Assert.That(() => lst.Max(), Throws.Exception);
        }

        [Test]
        public void GetMaxCatchTest2()
        {
            Assert.That(() => lst.Max(), Throws.Exception);
        }

        //IndexMin
        [TestCase(new int[] { 2 }, 0)]
        [TestCase(new int[] { 2, 1 }, 1)]
        [TestCase(new int[] { 1, 2, -9, 3, -5 }, 2)]
        [TestCase(new int[] { -10, 2, -9, 3, -5 }, 0)]
        [TestCase(new int[] { 1, 2, -9, 3, -15 }, 4)]
        [TestCase(new int[] { 2, 2, 2 }, 0)]
        public void GetIndexMinTest(int[] array, int result)
        {
            lst.Init(array);
            Assert.AreEqual(result, lst.IndMin());
        }

        [Test]
        public void GetIndexMinCatchTest()
        {
            Assert.That(() => lst.IndMin(), Throws.Exception);
        }

        //IndexMax
        [TestCase(new int[] { 2 }, 0)]
        [TestCase(new int[] { 2, 1 }, 0)]
        [TestCase(new int[] { 1, 2, 10, 3, -5 }, 2)]
        [TestCase(new int[] { 11, 2, -9, 3, -5 }, 0)]
        [TestCase(new int[] { 1, 2, -9, 3, 15 }, 4)]
        [TestCase(new int[] { 2, 2, 2 }, 0)]
        public void GetIndexMaxTest(int[] array, int result)
        {
            lst.Init(array);
            Assert.AreEqual(result, lst.IndMax());
        }

        [Test]
        public void GetIndexMaxCatchTest()
        {
            lst.Init(new int[] { });
            Assert.That(() => lst.IndMax(), Throws.Exception);
        }
        [Test]
        public void GetIndexMaxCatchTest2()
        {
            Assert.That(() => lst.IndMax(), Throws.Exception);
        }

        //Sort
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { -1, 0, 3, 3, 5, 7, 8 }, new int[] { -1, 0, 3, 3, 5, 7, 8 })]
        public void SortTest(int[] array, int[] result)
        {
            lst.Init(array);
            lst.Sort();
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        [Test]
        public void SelectSortCatchTest()
        {
            lst.Init(new int[] { });
            Assert.That(() => lst.Sort(), Throws.Exception);
        }

        [Test]
        public void SelectSortCatchTest2()
        {
            //lst.Init(null);
            Assert.That(() => lst.Sort(), Throws.Exception);
        }

        //ToString
        [TestCase(new int[] { }, "")]
        [TestCase(new int[] { 3 }, "3 ")]
        [TestCase(new int[] { 3, 5 }, "3 5 ")]
        [TestCase(new int[] { -1, 0, 3, 3, 5, 7, 8 }, "-1 0 3 3 5 7 8 ")]
        public void ToStringTest(int[] array, string result)
        {
            lst.Init(array);
            Assert.AreEqual(result, lst.ToString());
        }

       // Size
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 3 }, 1)]
        [TestCase(new int[] { 3, 5 }, 2)]
        [TestCase(new int[] { -1, 0, 3, 3, 5, 7, 8 }, 7)]
        public void SizeTest(int[] array, int result)
        {
            lst.Init(array);
            Assert.AreEqual(result, lst.Size());
        }

        //Clear
        [TestCase(new int[] { })]
        [TestCase(new int[] { 3 })]
        [TestCase(new int[] { 3, 5 })]
        [TestCase(new int[] { -1, 0, 3, 3, 5, 7, 8 })]
        public void ClearTest(int[] array)
        {
            lst.Init(array);
            lst.Clear();
            Assert.AreEqual(new int[]{}, lst.ToArray());
            Assert.AreEqual(0, lst.Size());
        }

        //Init
        [TestCase(new int[] { })]
        [TestCase(new int[] { 3 })]
        [TestCase(new int[] { 3, 5 })]
        [TestCase(new int[] { -1, 0, 3, 3, 5, 7, 8 })]
        public void InitTest(int[] array)
        {
            lst.Init(array);
            Assert.AreEqual(array, lst.ToArray());
            Assert.AreEqual(array.Length, lst.Size());
        }

        //AddStart
        [TestCase(new int[] { 2 }, new int[] { }, 2)]
        [TestCase(new int[] { 2, 1 }, new int[] { 1 }, 2)]
        [TestCase(new int[] { 3, 7, 9 }, new int[] { 7, 9 }, 3)]
        [TestCase(new int[] { 1, 2, 10, 3, -5, 4, 5, 6 }, new int[] { 2, 10, 3, -5, 4, 5, 6 }, 1)]

        public void AddStartTest(int[] result, int[] array, int val)
        {
            lst.Init(array);
            lst.AddStart(val);
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        //AddEnd
        [TestCase(new int[] { 2 }, new int[] { }, 2)]
        [TestCase(new int[] { 2, 1 }, new int[] { 2 }, 1)]
        [TestCase(new int[] { 2, 7, 9 }, new int[] { 2, 7 }, 9)]
        [TestCase(new int[] { 1, 2, 10, 3, -5, 4, 5, 6 }, new int[] { 1, 2, 10, 3, -5, 4, 5 }, 6)]

        public void AddEndTest(int[] result, int[] array, int val)
        {
            lst.Init(array);
            lst.AddEnd(val);
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        //AddPos
        [TestCase(new int[] { 1, 2 }, new int[] { 2 }, 0, 1)]
        [TestCase(new int[] { 2, 9, 7 }, new int[] { 2, 7 }, 1, 9)]
        [TestCase(new int[] { 1, 2, 10, 3, -5, 4, 5, 6 }, new int[] { 1, 2, 10, -5, 4, 5, 6 }, 3, 3)]

        public void AddPosTest(int[] result, int[] array, int pos, int val)
        {
            lst.Init(array);
            lst.AddPos(pos, val);

            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        [Test]
        public void AddPosCatchTest()
        {
            lst.Init(new int[] { 5, 8 });
            Assert.That(() => lst.AddPos(89, 5), Throws.Exception);
        }

        [Test]
        public void AddPosCatchTest2()
        {
            lst.Init(new int[] { 5, 8 });
            Assert.That(() => lst.AddPos(-2, 5), Throws.Exception);
        }

        //DelStart
        [TestCase(new int[] { 2 }, new int[] { })]
        [TestCase(new int[] { 2, 1 }, new int[] { 1 })]
        [TestCase(new int[] { 2, 7, 9 }, new int[] { 7, 9 })]
        [TestCase(new int[] { 1, 2, 10, 3, -5, 4, 5, 6 }, new int[] { 2, 10, 3, -5, 4, 5, 6 })]

        public void DelStartTest(int[] array, int[] result)
        {
            lst.Init(array);
            int s0 = lst.DelStart();
            Assert.AreEqual(s0, array[0]);
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        [Test]
        public void DelStartTest()
        {
            TList lst = new TList();
            lst.Init(new int[] { });
            Assert.That(() => lst.DelStart(), Throws.Exception);
        }

        //DelEnd
        [TestCase(new int[] { 2 }, new int[] { })]
        [TestCase(new int[] { 2, 1 }, new int[] { 2 })]
        [TestCase(new int[] { 2, 7, 9 }, new int[] { 2, 7 })]
        [TestCase(new int[] { 1, 2, 10, 3, -5, 4, 5, 6 }, new int[] { 1, 2, 10, 3, -5, 4, 5 })]

        public void DelEndTest(int[] array, int[] result)
        {
            lst.Init(array);
            int s = lst.DelEnd();
            Assert.AreEqual(s, array[array.Length - 1]);
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        [Test]
        public void DelEndTest()
        {
            lst.Init(new int[] { });
            Assert.That(() => lst.DelEnd(), Throws.Exception);
        }

        //DelPos
        [TestCase(new int[] { 2 }, new int[] { }, 0)]
        [TestCase(new int[] { 2, 1 }, new int[] { 2 }, 1)]
        [TestCase(new int[] { 2, 7, 9 }, new int[] { 2, 7 }, 2)]
        [TestCase(new int[] { 1, 2, 10, 3, -5, 4, 5, 6 }, new int[] { 1, 2, 10, -5, 4, 5, 6 }, 3)]

        public void DelPosTest(int[] array, int[] result, int pos)
        {
            lst.Init(array);
            int s = lst.DelPos(pos);
            Assert.AreEqual(s, array[pos]);
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        [Test]
        public void DelPosCatchTest()
        {
            lst.Init(new int[] { });
            Assert.That(() => lst.DelPos(8), Throws.Exception);
        }

        [Test]
        public void DelPosCatchTest2()
        {
            lst.Init(new int[] { 5, 8, 7 });
            Assert.That(() => lst.DelPos(8), Throws.Exception);
        }

        public void DelPosCatchTest3()
        {
            lst.Init(new int[] { 5, 8, 7 });
            Assert.That(() => lst.DelPos(-8), Throws.Exception);
        }
    
        //Set
        [TestCase(new int[] { 6 }, new int[] { 3 }, 0, 3)]
        [TestCase(new int[] { 6, 8 }, new int[] { 6, 3 }, 1, 3)]
        [TestCase(new int[] { -1, 0, 3, 3, 5, 7, 8 }, new int[] { -1, 0, 3, 3, 5, 22, 8 }, 5, 22)]
        [TestCase(new int[] { -1, 0, 3, 3, 5, 7, 8 }, new int[] { 22, 0, 3, 3, 5, 7, 8 }, 0, 22)]
        [TestCase(new int[] { -1, 0, 3, 3, 5, 7, 8 }, new int[] { -1, 0, 3, 3, 5, 7, 22 }, 6, 22)]
        public void SetTest(int[] array, int[] result, int pos, int val)
        {
            lst.Init(array);
            lst.Set(pos, val);
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        [Test]
        public void SetCatchTest()
        {
            lst.Init(new int[] { 5, 8, 7 });
            Assert.That(() => lst.Set(8, 1), Throws.Exception);
        }

        [Test]
        public void SetCatchTest2()
        {
            lst.Init(new int[] { 5, 8, 7 });
            Assert.That(() => lst.Set(-8, 1), Throws.Exception);
        }

        //Get
        [TestCase(new int[] { 6 }, 6, 0)]
        [TestCase(new int[] { 6, 8 }, 8, 1)]
        [TestCase(new int[] { -1, 0, 3, 3, 5, 7, 8 }, 7, 5)]
        [TestCase(new int[] { -1, 0, 3, 3, 5, 7, 8 }, -1, 0)]
        [TestCase(new int[] { -1, 0, 3, 3, 5, 7, 8 }, 8, 6)]
        public void GetTest(int[] array, int result, int pos)
        {
            lst.Init(array);
            int s = lst.Get(pos);
            Assert.AreEqual(s, result);
            Assert.AreEqual(array, lst.ToArray());
            Assert.AreEqual(array.Length, lst.Size());
        }

        [Test]
        public void GetCatchTest()
        {
            lst.Init(new int[] { 5, 8, 7 });
            Assert.That(() => lst.Get(-8), Throws.Exception);
        }

        [Test]
        public void GetCatchTest2()
        {
            lst.Init(new int[] { 5, 8, 7 });
            Assert.That(() => lst.Get(8), Throws.Exception);
        }

        //Reverse
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 3, 5, 8, 7 }, new int[] { 7, 8, 5, 3 })]
        public void ReverseTest(int[] array, int[] result)
        {
            lst.Init(array);
            lst.Reverse();
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        //ReverseHalfs
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        [TestCase(new int[] { 7, 8, 5, 3 }, new int[] { 5, 3, 7, 8 })]
        [TestCase(new int[] { 7, 2, 8, 5, 3 }, new int[] { 5, 3, 8, 7, 2 })]
        public void ReverseHalfsTest(int[] array, int[] result)
        {
            lst.Init(array);
            lst.HalfReverse();
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }
    }
}
