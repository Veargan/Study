using HashTable;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal static class TestFabrics
    {
        public static void HashTableAddAssert(int personCount, IHashTable ht)
        {
            bool result = false;
            IHashTable localHT = null;

            if (ht.GetType() == typeof(LinearHashTable))
            {
                localHT = new LinearHashTable();
            }
            else if(ht.GetType() == typeof(ChainedHashTable))
            {
                localHT = new ChainedHashTable();
            }

            Init(personCount, localHT);
            localHT.Add(new Person(5, "Sasya", "Lapkin", 45));
            result = localHT.Equals(ht);

            Assert.IsTrue(result);
        }

        public static void HashTableDeleteAssert(int personCount, IHashTable ht)
        {
            bool result = false;
            IHashTable localHT = null;

            if (ht.GetType() == typeof(LinearHashTable))
            {
                localHT = new LinearHashTable();
            }
            else if (ht.GetType() == typeof(ChainedHashTable))
            {
                localHT = new ChainedHashTable();
            }

            switch (personCount)
            {
                case 2:
                    localHT.Add(new Person(2, "Vasya", "Pupkin", 42));
                    break;
                case 7:
                    localHT.Add(new Person(2, "Vasya", "Pupkin", 42));
                    localHT.Add(new Person(3, "Vasya", "Papkin", 43));
                    localHT.Add(new Person(4, "Kasya", "Babkin", 44));
                    localHT.Add(new Person(5, "Masya", "Lapkin", 45));
                    localHT.Add(new Person(6, "Figasya", "Lupkin", 46));
                    localHT.Add(new Person(7, "Pupasya", "Lurkin", 47));
                    break;

                default:
                    break;
            }
            result = localHT.Equals(ht);

            Assert.IsTrue(result);
        }

        public static void HashTableToArrayAssert(int personCount, IHashTable ht)
        {
            Person[] expected = GetExpectedPersons(personCount);
            Person[] actual = ht.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        public static void HashTableEnumeratorAssert(int personCount, IHashTable ht)
        {
            Person[] expected = GetExpectedPersons(personCount);
            List<Person> actual = new List<Person>();

            foreach (Person item in ht)
            {
                actual.Add(item);
            }

            CollectionAssert.AreEqual(expected, actual.ToArray());
        }

        private static Person[] GetExpectedPersons(int personCount)
        {
            Person[] expected;

            switch (personCount)
            {
                case 1:
                    expected = new Person[1] {
                        new Person(1, "Uasya", "Pipirkin", 41)
                    };
                    break;
                case 2:
                    expected = new Person[2] {
                        new Person(1, "Uasya", "Pipirkin", 41),
                        new Person(2, "Vasya", "Pupkin", 42)
                    };
                    break;
                case 7:
                    expected = new Person[7] {
                        new Person(1, "Uasya", "Pipirkin", 41),
                        new Person(7, "Pupasya", "Lurkin", 47),
                        new Person(2, "Vasya", "Pupkin", 42),
                        new Person(4, "Kasya", "Babkin", 44),
                        new Person(3, "Vasya", "Papkin", 43),
                        new Person(5, "Masya", "Lapkin", 45),
                        new Person(6, "Figasya", "Lupkin", 46)
                    };
                    break;

                default:
                    expected = new Person[0];
                    break;
            }

            return expected;
        }

        public static void Init(int personCount, IHashTable ht)
        {
            switch (personCount)
            {
                case 1:
                    ht.Add(new Person(1, "Uasya", "Pipirkin", 41));
                    break;
                case 2:
                    ht.Add(new Person(1, "Uasya", "Pipirkin", 41));
                    ht.Add(new Person(2, "Vasya", "Pupkin", 42));
                    break;
                case 7:
                    ht.Add(new Person(1, "Uasya", "Pipirkin", 41));
                    ht.Add(new Person(2, "Vasya", "Pupkin", 42));
                    ht.Add(new Person(3, "Vasya", "Papkin", 43));
                    ht.Add(new Person(4, "Kasya", "Babkin", 44));
                    ht.Add(new Person(5, "Masya", "Lapkin", 45));
                    ht.Add(new Person(6, "Figasya", "Lupkin", 46));
                    ht.Add(new Person(7, "Pupasya", "Lurkin", 47));
                    break;

                default:
                    break;
            }
        }

    }
}
