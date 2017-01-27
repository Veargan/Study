using System;
using NUnit.Framework;
using HashTable;

namespace UnitTests
{
    [TestFixture]
    public class UT_ChainedHashTable_WhiteBox
    {
        ChainedHashTable ht;

        [SetUp]
        protected void SetUp()
        {
            ht = new ChainedHashTable();
        }

        [TearDown]
        protected void Clear()
        {
            ht.Clear();
        }

        #region Add
        [TestCase(7, TestName = "Add Width Shift")]
        public void Test_Add_LinearShift(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person p = new Person(4, "Kasya2", "Babkin", 44);
            ht.Add(p);
            int expectedPos = p.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(p);
            bool res = p.Equals(ht.Get(p));

            Assert.AreEqual(expectedPos, actualPos);
            Assert.IsTrue(res);
        }
        #endregion

        #region Get
        [TestCase(7, TestName = "GetByPerson Width Shift")]
        public void Test_GetByPerson_LinearShift(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(4, "Kasya", "Babkin", 44);
            Person p = ht.Get(ini);
            Assert.IsTrue(ini.Equals(p));
        }

        [TestCase(7, TestName = "GetByHashCode Width Shift")]
        public void Test_GetByHashCode_LinearShift(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(4, "Kasya", "Babkin", 44);
            Person p = ht.Get(ini.GetHashCode());
            Assert.IsTrue(ini.Equals(p));
        }
        #endregion

        #region GetPosition
        [TestCase(7, TestName = "GetPositionByPerson Width Shift")]
        public void Test_GetPositionByPerson_LinearShift(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(4, "Kasya2", "Babkin", 44);
            int expectedPos = ini.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(ini);

            Assert.AreEqual(expectedPos, actualPos);
        }

        [TestCase(7, TestName = "GetPositionByHashCode Width Shift")]
        public void Test_GetPositionByHashCode_LinearShift(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(4, "Kasya2", "Babkin", 44);
            int expectedPos = ini.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(ini.GetHashCode());

            Assert.AreEqual(expectedPos, actualPos);
        }
        #endregion

        #region Delete
        [TestCase(7, TestName = "Delete Width Shift")]
        public void Test_Delete_LinearShift(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            ChainedHashTable ini = ht;
            Person p = new Person(3, "Vasya2", "Papkin3", 43);
            ht.Add(p);
            int expectedPos = p.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(p);
            ht.Delete(p);
            bool res = ini.Equals(ht);

            Assert.AreEqual(expectedPos, actualPos);
            Assert.IsTrue(res);
        }
        #endregion

    }
}
