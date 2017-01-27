using System;
using NUnit.Framework;
using HashTable;

namespace UnitTests
{
    [TestFixture]
    public class UT_LinearHashTable_WhiteBox
    {
        LinearHashTable ht;

        [SetUp]
        protected void SetUp()
        {
            ht = new LinearHashTable();
        }

        [TearDown]
        protected void Clear()
        {
            ht.Clear();
        }

        #region Add
        [TestCase(7, TestName = "Add Linear Shift")]
        public void Test_Add_LinearShift(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person p = new Person(4, "Kasya2", "Babkin", 44);
            ht.Add(p);
            int expectedPos = p.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(p);

            Assert.AreNotEqual(expectedPos, actualPos);
        }

        [TestCase(7, TestName = "Add Ovarlapped")]
        public void Test_Add_Ovarlapped(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person p = new Person(6, "Figasya2", "Lupkin", 46);
            ht.Add(p);
            int expectedPos = p.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(p);

            Assert.Less(actualPos, expectedPos);
            Assert.AreNotEqual(expectedPos, actualPos);
        }
        #endregion

        #region Get
        [TestCase(7, TestName = "GetByPerson Linear Shift")]
        public void Test_GetByPerson_LinearShift(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(4, "Kasya", "Babkin", 44);
            Person p = ht.Get(ini);
            Assert.IsTrue(ini.Equals(p));
        }

        [TestCase(7, TestName = "GetByHashCode Linear Shift")]
        public void Test_GetByHashCode_LinearShift(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(4, "Kasya", "Babkin", 44);
            Person p = ht.Get(ini.GetHashCode());
            Assert.IsTrue(ini.Equals(p));
        }

        [TestCase(7, TestName = "GetByPerson Ovarlapped")]
        public void Test_GetByPerson_Ovarlapped(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(7, "Pupasya", "Lurkin", 47);
            Person p = ht.Get(ini);
            Assert.IsTrue(ini.Equals(p));
        }

        [TestCase(7, TestName = "GetByHashCode Ovarlapped")]
        public void Test_GetByHashCode_Ovarlapped(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(7, "Pupasya", "Lurkin", 47);
            Person p = ht.Get(ini.GetHashCode());
            Assert.IsTrue(ini.Equals(p));
        }
        #endregion

        #region GetPosition
        [TestCase(7, TestName = "GetPositionByPerson Linear Shift")]
        public void Test_GetPositionByPerson_LinearShift(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(4, "Kasya2", "Babkin", 44);
            int expectedPos = ini.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(ini);

            Assert.Greater(actualPos, expectedPos);
            Assert.AreNotEqual(expectedPos, actualPos);
        }

        [TestCase(7, TestName = "GetPositionByHashCode Linear Shift")]
        public void Test_GetPositionByHashCode_LinearShift(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(4, "Kasya2", "Babkin", 44);
            int expectedPos = ini.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(ini.GetHashCode());

            Assert.Greater(actualPos, expectedPos);
            Assert.AreNotEqual(expectedPos, actualPos);
        }

        [TestCase(7, TestName = "GetPositionByPerson Ovarlapped")]
        public void Test_GetPositionByPerson_Ovarlapped(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(6, "Figasya2", "Lupkin", 46);
            ht.Add(ini);

            int expectedPos = ini.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(ini);

            Assert.Less(actualPos, expectedPos);
            Assert.AreNotEqual(expectedPos, actualPos);
        }

        [TestCase(7, TestName = "GetPositionByHashCode Ovarlapped")]
        public void Test_GetPositionByHashCode_Ovarlapped(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(6, "Figasya2", "Lupkin", 46);
            ht.Add(ini);

            int expectedPos = ini.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(ini.GetHashCode());

            Assert.Less(actualPos, expectedPos);
            Assert.AreNotEqual(expectedPos, actualPos);
        }
        #endregion

        #region Delete
        [TestCase(7, TestName = "Delete Linear Shift")]
        public void Test_Delete_LinearShift(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            LinearHashTable ini = ht;
            Person p = new Person(3, "Vasya2", "Papkin3", 43);
            ht.Add(p);
            int expectedPos = p.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(p);
            ht.Delete(p);
            bool res = ini.Equals(ht);

            Assert.AreNotEqual(expectedPos, actualPos);
            Assert.IsTrue(res);
        }

        [TestCase(7, TestName = "Delete Ovarlapped")]
        public void Test_Delete_Ovarlapped(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            LinearHashTable ini = ht;
            Person p = new Person(2, "Vasya2", "Pupkin2", 42);
            ht.Add(p);
            int expectedPos = p.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(p);
            ht.Delete(p);
            bool res = ini.Equals(ht);

            Assert.AreNotEqual(expectedPos, actualPos);
            Assert.IsTrue(res);
        }
        #endregion

    }
}
