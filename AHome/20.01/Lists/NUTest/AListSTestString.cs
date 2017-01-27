using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Lists;

namespace NUTest
{
    class AListSTestString
    {
        private AList2S lst = new AList2S();

        //Min
        [TestCase(new string[] { "2" }, "2", TestName = "One elem")]
        [TestCase(new string[] { "2", "1" }, "1", TestName = "Two elems")]
        [TestCase(new string[] { "1", "2", "0", "3", "5" }, "0", TestName = "Aver elem")]
        [TestCase(new string[] { "1", "2", "9", "3", "5" }, "1", TestName = "First elem")]
        [TestCase(new string[] { "5", "2", "9", "3", "1" }, "1", TestName = "Last elem")]
        [TestCase(new string[] { "2", "2", "2" }, "2", TestName = "Same elems")]
        public void GetMinTest(string[] array, string result)
        {
            lst.Init(array);
            Assert.AreEqual(result, lst.Min());
        }

        [Test]
        public void GetMinCatchTest()
        {
            lst.Init(new string[] { });
            Assert.That(() => lst.Min(), Throws.Exception);
        }

        [Test]
        public void GetMinCatchTest2()
        {
            Assert.That(() => lst.Min(), Throws.Exception);
        }

        //Max
        [TestCase(new string[] { "2" }, "2", TestName = "One elem")]
        [TestCase(new string[] { "2", "1" }, "2", TestName = "Two elems")]
        [TestCase(new string[] { "1", "2", "9", "3", "5" }, "9", TestName = "Aver elem")]
        [TestCase(new string[] { "9", "2", "8", "3", "5" }, "9", TestName = "First elem")]
        [TestCase(new string[] { "1", "2", "8", "3", "9" }, "9", TestName = "Last elem")]
        [TestCase(new string[] { "2", "2", "2" }, "2", TestName = "Same elems")]
        public void GetMaxTest(string[] array, string result)
        {
            lst.Init(array);
            Assert.AreEqual(result, lst.Max());
        }

        [Test]
        public void GetMaxCatchTest()
        {
            lst.Init(new string[] { });
            Assert.That(() => lst.Max(), Throws.Exception);
        }

        [Test]
        public void GetMaxCatchTest2()
        {
            Assert.That(() => lst.Max(), Throws.Exception);
        }

        //IndexMin
        [TestCase(new string[] { "2" }, 0, TestName = "One elem")]
        [TestCase(new string[] { "2", "1" }, 1, TestName = "Two elems")]
        [TestCase(new string[] { "1", "2", "0", "3", "5" }, 2, TestName = "Aver elem")]
        [TestCase(new string[] { "1", "2", "9", "3", "5" }, 0, TestName = "First elem")]
        [TestCase(new string[] { "5", "2", "9", "3", "1" }, 4, TestName = "Last elem")]
        [TestCase(new string[] { "2", "2", "2" }, 0, TestName = "Same elems")]
        public void GetIndexMinTest(string[] array, int result)
        {
            lst.Init(array);
            Assert.AreEqual(result, lst.IndMin());
        }
        [Test]
        public void GetIndexMinCatchTest()
        {
            lst.Init(new string[] { });
            Assert.That(() => lst.IndMin(), Throws.Exception);
        }
        [Test]
        public void GetIndexMinCatchTest2()
        {
            Assert.That(() => lst.IndMin(), Throws.Exception);
        }

        //IndexMax
        [TestCase(new string[] { "2" }, 0, TestName = "One elem")]
        [TestCase(new string[] { "2", "1" }, 0, TestName = "Two elems")]
        [TestCase(new string[] { "1", "2", "9", "3", "5" }, 2, TestName = "Aver elem")]
        [TestCase(new string[] { "9", "2", "8", "3", "5" }, 0, TestName = "First elem")]
        [TestCase(new string[] { "1", "2", "8", "3", "9" }, 4, TestName = "Last elem")]
        [TestCase(new string[] { "2", "2", "2" }, 0, TestName = "Same elems")]
        public void GetIndexMaxTest(string[] array, int result)
        {
            lst.Init(array);
            Assert.AreEqual(result, lst.IndMax());
        }

        [Test]
        public void GetIndexMaxCatchTest()
        {
            lst.Init(new string[] { });
            Assert.That(() => lst.IndMax(), Throws.Exception);
        }
        [Test]
        public void GetIndexMaxCatchTest2()
        {
            Assert.That(() => lst.IndMax(), Throws.Exception);
        }

        //Sort
        [TestCase(new string[] { "0" }, new string[] { "0" })]
        [TestCase(new string[] { "1", "2" }, new string[] { "1", "2" })]
        [TestCase(new string[] { "1", "9", "3", "3", "5", "7", "8" }, new string[] { "1", "3", "3", "5", "7", "8", "9" })]
        public void SortTest(string[] array, string[] result)
        {
            lst.Init(array);
            lst.Sort();
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        [Test]
        public void SelectSortCatchTest()
        {
            lst.Init(new string[] { });
            Assert.That(() => lst.Sort(), Throws.Exception);
        }

        [Test]
        public void SelectSortCatchTest2()
        {
            //lst.Init(null);
            Assert.That(() => lst.Sort(), Throws.Exception);
        }

        //ToString
        [TestCase(new string[] { }, "")]
        [TestCase(new string[] { "3" }, "3 ")]
        [TestCase(new string[] { "3", "5" }, "3 5 ")]
        [TestCase(new string[] { "-1", "0", "3", "3", "5", "7", "8" }, "-1 0 3 3 5 7 8 ")]
        public void ToStringTest(string[] array, string result)
        {
            lst.Init(array);
            Assert.AreEqual(result, lst.ToString());
        }

        // Size
        [TestCase(new string[] { }, 0)]
        [TestCase(new string[] { "3" }, 1)]
        [TestCase(new string[] { "3", "5" }, 2)]
        [TestCase(new string[] { "-1", "0", "3", "3", "5", "7", "8" }, 7)]
        public void SizeTest(string[] array, int result)
        {
            lst.Init(array);
            Assert.AreEqual(result, lst.Size());
        }

        //Clear
        [TestCase(new string[] { }, "")]
        [TestCase(new string[] { "3" }, "")]
        [TestCase(new string[] { "3", "5" }, "")]
        [TestCase(new string[] { "-1", "0", "3", "3", "5", "7", "8" }, "")]
        public void ClearTest(string[] array, string d)
        {
            lst.Init(array);
            lst.Clear();
            Assert.AreEqual(new int[] { }, lst.ToArray());
            Assert.AreEqual(0, lst.Size());
        }

        //Init
        [TestCase(new string[] { }, "")]
        [TestCase(new string[] { "3" }, "")]
        [TestCase(new string[] { "3", "5" }, "")]
        [TestCase(new string[] { "-1", "0", "3", "3", "5", "7", "8" }, "")]
        public void InitTest(string[] array, string h)
        {
            lst.Init(array);
            Assert.AreEqual(array, lst.ToArray());
            Assert.AreEqual(array.Length, lst.Size());
        }

        //AddStart
        [TestCase(new string[] { "2" }, new string[] { }, "2")]
        [TestCase(new string[] { "2", "1" }, new string[] { "1" }, "2")]
        [TestCase(new string[] { "3", "7", "9" }, new string[] { "7", "9" }, "3")]
        [TestCase(new string[] { "1", "2", "10", "3", "-5", "4", "5", "6" },
            new string[] { "2", "10", "3", "-5", "4", "5", "6" }, "1")]

        public void AddStartTest(string[] result, string[] array, string val)
        {
            lst.Init(array);
            lst.AddStart(val);
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        //AddEnd
        [TestCase(new string[] { "2" }, new string[] { }, "2")]
        [TestCase(new string[] { "1", "2" }, new string[] { "1" }, "2")]
        [TestCase(new string[] { "7", "9", "3" }, new string[] { "7", "9" }, "3")]
        [TestCase(new string[] { "2", "10", "3", "-5", "4", "5", "6", "1" },
            new string[] { "2", "10", "3", "-5", "4", "5", "6" }, "1")]

        public void AddEndTest(string[] result, string[] array, string val)
        {
            lst.Init(array);
            lst.AddEnd(val);
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        //AddPos
        [TestCase(new string[] { "3", "2", "5" }, new string[] { "2", "5" }, 0, "3")]
        [TestCase(new string[] { "7", "3", "9" }, new string[] { "7", "9" }, 1, "3")]
        [TestCase(new string[] { "2", "10", "3", "-5", "4", "5", "6", "1" },
            new string[] { "2", "10", "3", "-5", "4", "5", "6" }, 7, "1")]

        public void AddPosTest(string[] result, string[] array, int pos, string val)
        {
            lst.Init(array);
            lst.AddPos(pos, val);

            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        [Test]
        public void AddPosCatchTest()
        {
            lst.Init(new string[] { "5", "8" });
            Assert.That(() => lst.AddPos(89, "5"), Throws.Exception);
        }

        [Test]
        public void AddPosCatchTest2()
        {
            lst.Init(new string[] { "5", "8" });
            Assert.That(() => lst.AddPos(-2, "5"), Throws.Exception);
        }

        //DelStart
        [TestCase(new string[] { "2" }, new string[] { })]
        [TestCase(new string[] { "2", "1" }, new string[] { "1" })]
        [TestCase(new string[] { "3", "7", "9" }, new string[] { "7", "9" })]
        [TestCase(new string[] { "1", "2", "10", "3", "-5", "4", "5", "6" },
            new string[] { "2", "10", "3", "-5", "4", "5", "6" })]

        public void DelStartTest(string[] array, string[] result)
        {
            lst.Init(array);
            object s0 = lst.DelStart();
            Assert.AreEqual(s0, array[0]);
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        [Test]
        public void DelStartTest()
        {
            AList2G<int> lst = new AList2G<int>();
            lst.Init(new int[] { });
            Assert.That(() => lst.DelStart(), Throws.Exception);
        }

        //DelEnd
        [TestCase(new string[] { "2" }, new string[] { })]
        [TestCase(new string[] { "1", "2" }, new string[] { "1" })]
        [TestCase(new string[] { "7", "9", "3" }, new string[] { "7", "9" })]
        [TestCase(new string[] { "2", "10", "3", "-5", "4", "5", "6", "1" },
            new string[] { "2", "10", "3", "-5", "4", "5", "6" })]
        public void DelEndTest(string[] array, string[] result)
        {
            lst.Init(array);
            object s = lst.DelEnd();
            Assert.AreEqual(s, array[array.Length - 1]);
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        [Test]
        public void DelEndTest()
        {
            lst.Init(new string[] { });
            Assert.That(() => lst.DelEnd(), Throws.Exception);
        }

        //DelPos
        [TestCase(new string[] { "3", "2" }, new string[] { "2" }, 0)]
        [TestCase(new string[] { "3", "2", "5" }, new string[] { "2", "5" }, 0)]
        [TestCase(new string[] { "7", "3", "9" }, new string[] { "7", "9" }, 1)]
        [TestCase(new string[] { "2", "10", "3", "-5", "4", "5", "6", "1" },
            new string[] { "2", "10", "3", "-5", "4", "5", "6" }, 7)]
        public void DelPosTest(string[] array, string[] result, int pos)
        {
            lst.Init(array);
            object s = lst.DelPos(pos);
            Assert.AreEqual(s, array[pos]);
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        [Test]
        public void DelPosCatchTest()
        {
            lst.Init(new string[] { });
            Assert.That(() => lst.DelPos(8), Throws.Exception);
        }

        [Test]
        public void DelPosCatchTest2()
        {
            lst.Init(new string[] { "2", "5" });
            Assert.That(() => lst.DelPos(8), Throws.Exception);
        }

        public void DelPosCatchTest3()
        {
            lst.Init(new string[] { "2", "5" });
            Assert.That(() => lst.DelPos(-8), Throws.Exception);
        }

        //Set
        [TestCase(new string[] { "6" }, new string[] { "3" }, 0, "3")]
        [TestCase(new string[] { "6", "8" }, new string[] { "6", "3" }, 1, "3")]
        [TestCase(new string[] { "-1", "0", "3", "3", "5", "7", "8" }, new string[] { "-1", "0", "3", "3", "5", "22", "8" }, 5, "22")]
        [TestCase(new string[] { "-1", "0", "3", "3", "5", "7", "8" }, new string[] { "22", "0", "3", "3", "5", "7", "8" }, 0, "22")]
        [TestCase(new string[] { "-1", "0", "3", "3", "5", "7", "8" }, new string[] { "-1", "0", "3", "3", "5", "7", "22" }, 6, "22")]
        public void SetTest(string[] array, string[] result, int pos, string val)
        {
            lst.Init(array);
            lst.Set(pos, val);
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        [Test]
        public void SetCatchTest()
        {
            lst.Init(new string[] { "6", "8" });
            Assert.That(() => lst.Set(8, "1"), Throws.Exception);
        }

        [Test]
        public void SetCatchTest2()
        {
            lst.Init(new string[] { "6", "8" });
            Assert.That(() => lst.Set(-8, "1"), Throws.Exception);
        }

        //Get
        [TestCase(new string[] { "6" }, "6", 0)]
        [TestCase(new string[] { "6", "8" }, "8", 1)]
        [TestCase(new string[] { "-1", "0", "3", "3", "5", "7", "8" }, "7", 5)]
        [TestCase(new string[] { "-1", "0", "3", "3", "5", "7", "8" }, "-1", 0)]
        [TestCase(new string[] { "-1", "0", "3", "3", "5", "7", "8" }, "8", 6)]
        public void GetTest(string[] array, string result, int pos)
        {
            lst.Init(array);
            object s = lst.Get(pos);
            Assert.AreEqual(s, result);
            Assert.AreEqual(array, lst.ToArray());
            Assert.AreEqual(array.Length, lst.Size());
        }

        [Test]
        public void GetCatchTest()
        {
            lst.Init(new string[] { "6", "8" });
            Assert.That(() => lst.Get(-8), Throws.Exception);
        }

        [Test]
        public void GetCatchTest2()
        {
            lst.Init(new string[] { "6", "8" });
            Assert.That(() => lst.Get(8), Throws.Exception);
        }

        //Reverse
        [TestCase(new string[] { "0" }, new string[] { "0" })]
        [TestCase(new string[] { "1", "2", "3" }, new string[] { "3", "2", "1" })]
        [TestCase(new string[] { "3", "5", "8", "7" }, new string[] { "7", "8", "5", "3" })]
        public void ReverseTest(string[] array, string[] result)
        {
            lst.Init(array);
            lst.Reverse();
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }

        //ReverseHalfs
        [TestCase(new string[] { "0" }, new string[] { "0" })]
        [TestCase(new string[] { "1", "2" }, new string[] { "2", "1" })]
        [TestCase(new string[] { "7", "8", "5", "3" }, new string[] { "5", "3", "7", "8" })]
        [TestCase(new string[] { "7", "2", "8", "5", "3" }, new string[] { "5", "3", "8", "7", "2" })]
        public void ReverseHalfsTest(string[] array, string[] result)
        {
            lst.Init(array);
            lst.HalfReverse();
            Assert.AreEqual(result, lst.ToArray());
            Assert.AreEqual(result.Length, lst.Size());
        }
    }
}
