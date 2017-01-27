using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Lists;
using System.Reflection;

namespace NUTest
{
    public static class SecretFind_AList2
    {
        public static int[] GetAr(this AList2 keeper)
        {
            FieldInfo fieldInfo = typeof(AList2).GetField("ar", BindingFlags.Instance | BindingFlags.NonPublic);
            int[] result = (int[])fieldInfo.GetValue(keeper);
            return result;
        }
    }

    [TestFixture]
    class List2Resize
    {
        AList2 lst = new AList2();

        [Test]
        public void ResizeEndTest()
        {
            int[] exp = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] result = new int[] { 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            lst.Init(exp);
            lst.AddEnd(10);
            lst.AddEnd(11);
            int[] a = lst.GetAr();
            Assert.AreEqual(result, a);
        }

        [Test]
        public void ResizeStartTest()
        {
            int[] exp = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] result = new int[] { 0, 0, 12, 11, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 0 };
            lst.Init(exp);
            lst.AddStart(10);
            lst.AddStart(11);
            lst.AddStart(12);
            int[] a = lst.GetAr();
            Assert.AreEqual(result, a);
        }

        [Test]
        public void ResizeFullTest()
        {
            int[] exp = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] result = new int[] {0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0 };
            lst.Init(exp);
            lst.AddEnd(10);
            int[] a = lst.GetAr();
            Assert.AreEqual(result, a);
        }

    }
}
