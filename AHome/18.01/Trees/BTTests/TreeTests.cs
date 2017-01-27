using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace BTTests
{
    //[TestFixture(typeof(BsTree))]
   // [TestFixture(typeof(BsTreeVis))]
    //[TestFixture(typeof(BsTreeLink))]
   // [TestFixture(typeof(RbTree))]
    [TestFixture(typeof(AvlTree))]
    public class TestClass<TTree> where TTree : ITrees, new()
    {      
        [Test]
        public void InitTestNull()
        {
            ITrees bt = new TTree();
            int[] ar = null;
            Assert.Throws<NullReferenceException>(() => bt.Init(ar));
        }

        [Test]
        [TestCase(new int[] { }, new int[] { }, 0, TestName = "InitTestZero")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, 1, TestName = "InitTestOne")]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, 2, TestName = "InitTestTwo")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 7, 11, 25, 27, 30, 40, 50, 80, 90, 110 }, 10, TestName = "InitTestMany")]
        public void InitTest(int[] ar, int[] act, int length)
        {
            ITrees bt = new TTree();
            bt.Init(ar);
            Assert.AreEqual(length, bt.Size());
            CollectionAssert.AreEqual(act, bt.ToArray());
        }

        [Test]
        [TestCase(new int[] { }, new int[] { }, 0,  TestName = "SizeTestZero")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, 1,  TestName = "SizeTestOne")]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, 2,  TestName = "SizeTestTwo")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 7, 11, 25, 27, 30, 40, 50, 80, 90, 110 }, 10, TestName = "SizeTestMany")]
        public void SizeTest(int[] ar, int[] act, int length)
        {
            ITrees bt = new TTree();
            bt.Init(ar);
            int res = bt.Size();
            Assert.AreEqual(length, res);
            CollectionAssert.AreEqual(act, bt.ToArray());
        }

        [Test]
        [TestCase(new int[] { }, "", 0, TestName = "ToStringTestZero")]
        [TestCase(new int[] { 1 }, "1, ", 1, TestName = "ToStringTestOne")]
        [TestCase(new int[] { 1, 2 }, "1, 2, ", 2, TestName = "ToStringTestTwo")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, "7, 11, 25, 27, 30, 40, 50, 80, 90, 110, ", 10, TestName = "ToStringTestMany")]
        public void ToStringTest(int[] ar, string act, int length)
        {
            ITrees bt = new TTree();
            bt.Init(ar);
            Assert.AreEqual(length, bt.Size());
            Assert.AreEqual(act, bt.ToString());
        }

        [Test]
        [TestCase(new int[] { }, new int[] { 10 }, 10, 1, TestName = "AddStartTestZero")]
        [TestCase(new int[] { 1 }, new int[] { 1, 10 }, 10, 2, TestName = "AddStartTestOne")]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 10 }, 10, 3, TestName = "AddStartTestTwo")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 7, 10, 11, 25, 27, 30, 40, 50, 80, 90, 110 }, 10, 11, TestName = "AddStartTestMany")]
        public void AddTest(int[] ar, int[] act, int val, int length)
        {
            ITrees bt = new TTree();
            bt.Init(ar);
            bt.Add(val);
            Assert.AreEqual(length, bt.Size());
            CollectionAssert.AreEqual(act, bt.ToArray());
        }

        [Test]
        [TestCase(new int[] { }, new int[] { }, 0, 0, TestName = "NodesTestZero")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, 1, 0, TestName = "NodesTestOne")]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, 2, 1, TestName = "NodesTestTwo")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 7, 11, 25, 27, 30, 40, 50, 80, 90, 110 }, 10, 5, TestName = "NodesTestMany")]
        public void NodesTest(int[] ar, int[] act, int length, int count)
        {
            ITrees bt = new TTree();
            bt.Init(ar);
            int res = bt.Nodes();
            Assert.AreEqual(length, bt.Size());
            Assert.AreEqual(count, res);
            CollectionAssert.AreEqual(act, bt.ToArray());
        }

        [Test]
        [TestCase(new int[] { }, new int[] { }, 0, 0, TestName = "LeavesTestZero")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, 1, 1, TestName = "LeavesTestOne")]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, 2, 1, TestName = "LeavesTestTwo")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 7, 11, 25, 27, 30, 40, 50, 80, 90, 110 }, 10, 5, TestName = "LeavesTestMany")]
        public void LeavesTest(int[] ar, int[] act, int length, int count)
        {
            ITrees bt = new TTree();
            bt.Init(ar);
            int res = bt.Leaves();
            Assert.AreEqual(length, bt.Size());
            Assert.AreEqual(count, res);
            CollectionAssert.AreEqual(act, bt.ToArray());
        }

        [Test]
        [TestCase(new int[] { }, new int[] { }, 0, 0, TestName = "HeightTestZero")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, 1, 1, TestName = "HeightTestOne")]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, 2, 2, TestName = "HeightTestTwo")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 7, 11, 25, 27, 30, 40, 50, 80, 90, 110 }, 10, 4, TestName = "HeightTestMany")]
        public void HeightTest(int[] ar, int[] act, int length, int count)
        {
            ITrees bt = new TTree();
            bt.Init(ar);
            int res = bt.Height();
            Assert.AreEqual(length, bt.Size());
            Assert.AreEqual(count, res);
            CollectionAssert.AreEqual(act, bt.ToArray());
        }

        [Test]
        [TestCase(new int[] { 1 }, new int[] { 1 }, 1, 1, TestName = "WidthTestOne")]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, 2, 1, TestName = "WidthTestTwo")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 7, 11, 25, 27, 30, 40, 50, 80, 90, 110 }, 10, 4, TestName = "WidthTestMany")]
        public void WidthTest(int[] ar, int[] act, int length, int count)
        {
            ITrees bt = new TTree();
            bt.Init(ar);
            int res = bt.Width();
            Assert.AreEqual(length, bt.Size());
            Assert.AreEqual(count, res);
            CollectionAssert.AreEqual(act, bt.ToArray());
        }

        public void WidthTestZero()
        {
            ITrees bt = new TTree();
            int[] ar = { };
            bt.Init(ar);
            Assert.Throws<IndexOutOfRangeException>(() => bt.Width());
        }

        [Test]
        [TestCase(new int[] { }, new int[] { }, 0, TestName = "ReverseTestZero")]
        [TestCase(new int[] { 1 }, new int[] { 1 }, 1, TestName = "ReverseTestOne")]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 }, 2, TestName = "ReverseTestTwo")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 110, 90, 80, 50, 40, 30, 27, 25, 11, 7 }, 10, TestName = "ReverseTestMany")]
        public void ReverseTest(int[] ar, int[] act, int length)
        {
            ITrees bt = new TTree();
            bt.Init(ar);
            bt.Reverse();
            Assert.AreEqual(length, bt.Size());
            CollectionAssert.AreEqual(act, bt.ToArray());
        }

        [Test]
        [TestCase(new int[] { 1 }, new int[] { }, 1, 0, TestName = "DelTestOne")]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 }, 2, 1, TestName = "DelTestTwo")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 7, 25, 27, 30, 40, 50, 80, 90, 110 }, 11, 9, TestName = "DelTestMany")]
        public void Del(int[] ar, int[] act, int val, int length)
        {
            ITrees bt = new TTree();
            bt.Init(ar);
            bt.Del(val);
            Assert.AreEqual(length, bt.Size());
            CollectionAssert.AreEqual(act, bt.ToArray());
        }

        [Test]
        [TestCase(new int[] { }, new int[] { }, 1, 0, TestName = "EnumTestZero")]
        [TestCase(new int[] { 1 }, new int[] { }, 1, 0, TestName = "EnumTestOne")]
        [TestCase(new int[] { 1, 2 }, new int[] { 2 }, 1, 1, TestName = "EnumTestTwo")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 7, 11, 25, 27, 30, 40, 50, 80, 90, 110 }, 11, 9, TestName = "EnumTestMany")]
        public void Enum(int[] ar, int[] act, int val, int length)
        {
            BsTree bt = new BsTree();
            bt.Init(ar);
            int[] res = new int[ar.Length];
            int i = 0;
            foreach(var v in bt)
            {
                res[i++] = (int)v;
            }
            CollectionAssert.AreEqual(res, bt.ToArray());
        }
    }
}
