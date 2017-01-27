using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace BTTests
{
    class BsTreeEqualsTests
    {
        BsTree bs = null;
        [SetUp]
        public void Clear_al()
        {
            bs = new BsTree();
        }
        [TestCase(new int[] { 10, 2, 30, 4, 0 }, new int[] { 10, 2, 30, 4, 0 }, 5, TestName = "EqualsAddTest1")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, 10, TestName = "EqualsAddTest2")]
        public void TestEqualsAdd(int[] ar, int[] at, int res)
        {
            bs.Init(ar);
            BsTree act = new BsTree();
            act.Init(at);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));
            
        }

        [TestCase(new int[] { 10, 2, 30, 4, 0 }, new int[] { 10, 30, 4, 0 }, 2, 4, TestName = "EqualsDelTest")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 50, 25, 11, 30, 27, 40, 90, 80, 110 }, 7, 9, TestName = "EqualsDelTestLeft")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 50, 27, 11, 7, 30, 40, 90, 80, 110 }, 25, 9, TestName = "EqualsDelTestBoth")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 40, 90, 80, 110 }, new int[] { 50, 25, 11, 7, 40, 90, 80, 110 }, 30, 8, TestName = "EqualsDelTestRight")]
        [TestCase(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 }, new int[] { 80, 90, 110, 25, 11, 7, 30, 27, 40 }, 50, 9, TestName = "EqualsDelTestRoot")]
        public void TestEqualsDel(int[] ar, int[] at, int val, int res)
        {
            bs.Init(ar);
            BsTree act = new BsTree();
            act.Init(at);
            bs.Del(val);
            Assert.AreEqual(res, bs.Size());
            Assert.IsTrue(bs.Equals(act));
           
        }
    }
}
