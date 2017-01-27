using System;
using NUnit.Framework;
using HashTable;

namespace UnitTests
{
    [TestFixture(typeof(LinearHashTable))]
    [TestFixture(typeof(ChainedHashTable))]
    public class UT_HashTable_BlackBox<HashTable> where HashTable : class, new()
    {
        IHashTable ht;

        [SetUp]
        protected void SetUp()
        {
            ht = (IHashTable)new HashTable();
        }

        [TearDown]
        protected void Clear()
        {
            ht.Clear();
        }

        #region Add
        [TestCase(TestName = "Add ArgOutOfRange Exc")]
        public void Test_Add_ArgOutOfRange_Exc()
        {
            TestFabrics.Init(7, ht);
            ht.Add(new Person(8, "name", "surname", 48));
            ht.Add(new Person(9, "name", "surname", 49));
            ht.Add(new Person(10, "name", "surname", 50));
            ht.Add(new Person(11, "name", "surname", 51));
            Assert.Throws<ArgumentOutOfRangeException>(() => ht.Add(new Person(5, "Sasya", "Lapkin", 45)));
        }

        [TestCase(TestName = "Add NullRef Exc")]
        public void Test_Add_NullRef_Exc()
        {
            Assert.Throws<NullReferenceException>(() => ht.Add(null));
        }

        [TestCase(0, TestName = "Add 0")]
        [TestCase(1, TestName = "Add 1")]
        [TestCase(2, TestName = "Add 2")]
        [TestCase(7, TestName = "Add Many")]
        public void Test_Add(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            ht.Add(new Person(5, "Sasya", "Lapkin", 45));
            TestFabrics.HashTableAddAssert(personCount, ht);
        }
        #endregion

        #region Get
        [TestCase(TestName = "GetByPerson Null NullRef Exc")]
        public void Test_GetByPerson_Null_NullRef_Exc()
        {
            Assert.Throws<NullReferenceException>(() => ht.Get(null));
        }

        [TestCase(TestName = "GetByPerson 0 NullRef Exc")]
        public void Test_GetByPerson_0_NullRef_Exc()
        {
            Assert.Throws<NullReferenceException>(() => ht.Get(new Person(5, "Sasya", "Lapkin", 45)));
        }

        [TestCase(TestName = "GetByHashCode 0 NullRef Exc")]
        public void Test_GetByHashCode_0_NullRef_Exc()
        {
            Assert.Throws<NullReferenceException>(() => ht.Get(new Person(5, "Sasya", "Lapkin", 45).GetHashCode()));
        }

        [TestCase(1, TestName = "GetByPerson 1")]
        [TestCase(2, TestName = "GetByPerson 2")]
        [TestCase(7, TestName = "GetByPerson Many")]
        public void Test_GetByPerson(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(1, "Uasya", "Pipirkin", 41);
            Person p = ht.Get(ini);
            Assert.IsTrue(ini.Equals(p));
        }

        [TestCase(1, TestName = "GetByHashCode 1")]
        [TestCase(2, TestName = "GetByHashCode 2")]
        [TestCase(7, TestName = "GetByHashCode Many")]
        public void Test_GetByHashCode(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(1, "Uasya", "Pipirkin", 41);
            Person p = ht.Get(ini.GetHashCode());
            Assert.IsTrue(ini.Equals(p));
        }
        #endregion

        #region GetPosition
        [TestCase(TestName = "GetPositionByPerson Null NullRef Exc")]
        public void Test_GetPositionByPerson_Null_NullRef_Exc()
        {
            Assert.Throws<NullReferenceException>(() => ht.GetPosition(null));
        }

        [TestCase(TestName = "GetPositionByPerson 0 NullRef Exc")]
        public void Test_GetPositionByPerson_0_NullRef_Exc()
        {
            Assert.Throws<NullReferenceException>(() => ht.GetPosition(new Person(5, "Sasya", "Lapkin", 45)));
        }

        [TestCase(TestName = "GetPositionByHashCode 0 NullRef Exc")]
        public void Test_GetPositionByHashCode_0_NullRef_Exc()
        {
            Assert.Throws<NullReferenceException>(() => ht.GetPosition(new Person(5, "Sasya", "Lapkin", 45).GetHashCode()));
        }

        [TestCase(1, TestName = "GetPositionByPerson 1")]
        [TestCase(2, TestName = "GetPositionByPerson 2")]
        [TestCase(7, TestName = "GetPositionByPerson Many")]
        public void Test_GetPositionByPerson(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(1, "Uasya", "Pipirkin", 41);
            int expectedPos = ini.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(ini);
            Assert.AreEqual(expectedPos, actualPos);
        }

        [TestCase(1, TestName = "GetPositionByHashCode 1")]
        [TestCase(2, TestName = "GetPositionByHashCode 2")]
        [TestCase(7, TestName = "GetPositionByHashCode Many")]
        public void Test_GetPositionByHashCode(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            Person ini = new Person(1, "Uasya", "Pipirkin", 41);
            int expectedPos = ini.GetHashCode() % ht.Capacity;
            int actualPos = ht.GetPosition(ini.GetHashCode());
            Assert.AreEqual(expectedPos, actualPos);
        }
        #endregion

        #region Size
        [TestCase(0, TestName = "Size 0")]
        [TestCase(1, TestName = "Size 1")]
        [TestCase(2, TestName = "Size 2")]
        [TestCase(7, TestName = "Size Many")]
        public void Test_Size(int expPersonCount)
        {
            TestFabrics.Init(expPersonCount, ht);
            int actual = ht.Size();
            Assert.AreEqual(expPersonCount, actual);
        }
        #endregion

        #region GetKP
        [TestCase(0, 0.0, TestName = "GetKP 0")]
        [TestCase(1, 0.09, TestName = "GetKP 1")]
        [TestCase(2, 0.18, TestName = "GetKP 2")]
        [TestCase(7, 0.64, TestName = "GetKP Many")]
        public void Test_GetKP(int personCount, double expected)
        {
            TestFabrics.Init(personCount, ht);
            double actual = ht.GetKP();
            Assert.AreEqual(Math.Round(expected, 2), actual);
        }
        #endregion

        #region Clear
        [TestCase(0, TestName = "Clear 0")]
        [TestCase(1, TestName = "Clear 1")]
        [TestCase(2, TestName = "Clear 2")]
        [TestCase(7, TestName = "Clear Many")]
        public void Test_Clear(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            ht.Clear();
            float actual = ht.Size();
            Assert.AreEqual(0, actual);
        }
        #endregion

        #region ToArray
        [TestCase(0, TestName = "ToArray 0")]
        [TestCase(1, TestName = "ToArray 1")]
        [TestCase(2, TestName = "ToArray 2")]
        [TestCase(7, TestName = "ToArray Many")]
        public void Test_ToArray(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            TestFabrics.HashTableToArrayAssert(personCount, ht);
        }
        #endregion

        #region Delete
        [TestCase(TestName = "Delete Null NullRef Exc")]
        public void Test_Delete_Null_NullRef_Exc()
        {
            Assert.Throws<NullReferenceException>(() => ht.Delete(null));
        }

        [TestCase(TestName = "Delete 0 NullRef Exc")]
        public void Test_Delete_0_NullRef_Exc()
        {
            Assert.Throws<NullReferenceException>(() => ht.Delete(new Person(1, "Uasya", "Pipirkin", 41)));
        }

        [TestCase(1, TestName = "Delete 1")]
        [TestCase(2, TestName = "Delete 2")]
        [TestCase(7, TestName = "Delete Many")]
        public void Test_Delete(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            ht.Delete(new Person(1, "Uasya", "Pipirkin", 41));
            TestFabrics.HashTableDeleteAssert(personCount, ht);
        }
        #endregion

        #region Enumerator
        [TestCase(0, TestName = "Enumerator 0")]
        [TestCase(1, TestName = "Enumerator 1")]
        [TestCase(2, TestName = "Enumerator 2")]
        [TestCase(7, TestName = "Enumerator Many")]
        public void Test_Enumerator(int personCount)
        {
            TestFabrics.Init(personCount, ht);
            TestFabrics.HashTableEnumeratorAssert(personCount, ht);
        }
        #endregion

    }
}
