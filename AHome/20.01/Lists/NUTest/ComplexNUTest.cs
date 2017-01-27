using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Lists;

namespace NUTest
{
    [TestFixture(typeof(AList2))]
    public class ComplexNUTest<TList> where TList : IList, new()
    {
        private TList lst = new TList();

        [TestCase(new int[] { }, new int[] { 6, 7, 4, 8 })]
        [TestCase(new int[] { 3 }, new int[] { 6, 7, 4, 3, 8})]
        [TestCase(new int[] { 2, 1 }, new int[] { 6, 7, 4, 1, 2, 8 })]
        [TestCase(new int[] { 1, 2, 10, 3 }, new int[] { 6, 7, 4, 3, 10, 2, 1, 8 })]
        public void Test1(int[] array, int[] result)
        {
            lst.Init(array);
            lst.AddEnd(4);
            lst.AddStart(2);
            lst.AddEnd(7);
            lst.AddPos(1, 8);
            lst.DelStart();
            lst.Reverse();
            lst.AddStart(6); 

            Assert.AreEqual(result.Length, lst.Size());
            Assert.AreEqual(result, lst.ToArray());
        }

        [TestCase(new int[] { }, new int[] { 2, 1, 1 })]
        [TestCase(new int[] { 6 }, new int[] { 2, 8, 1, 1 })]
        [TestCase(new int[] { 9, 8 }, new int[] { 8, 9, 2, 1, 1 })]
        [TestCase(new int[] { 7, 8, 10, 5 }, new int[] { 8, 8, 10, 7, 1, 1, 2 })]
        public void Test2(int[] array, int[] result)
        {
            lst.Init(array);
            lst.AddStart(1);
            lst.AddStart(8);
            lst.AddStart(2);
            lst.AddStart(1);
            lst.Sort();
            lst.DelPos(3);
            lst.HalfReverse();

            Assert.AreEqual(result.Length, lst.Size());
            Assert.AreEqual(result, lst.ToArray());
        }
    }
}
