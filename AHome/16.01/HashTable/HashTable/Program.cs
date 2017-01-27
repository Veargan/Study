using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            LinearHashTable ht = new LinearHashTable();
            Person[] arr = ht.ToArray();
            //ChainedHashTable ht = new ChainedHashTable();
            ht.Add(new Person(1, "Uasya", "Pipirkin", 41));
            ht.Add(new Person(2, "Vasya", "Pupkin", 42));
            ht.Add(new Person(3, "Vasya", "Papkin", 43));
            ht.Add(new Person(4, "Kasya", "Babkin", 44));
            ht.Add(new Person(5, "Masya", "Lapkin", 45));

            Console.WriteLine(new Person(1, "Uasya2", "Pipirkin3", 41).GetHashCode() % 11);
            Console.WriteLine(new Person(2, "Vasya2", "Pupkin3", 42).GetHashCode() % 11);
            Console.WriteLine(new Person(3, "Vasya2", "Papkin3", 43).GetHashCode() % 11);
            Console.WriteLine(new Person(4, "Kasya2", "Babkin3", 44).GetHashCode() % 11);
            Console.WriteLine(new Person(5, "Masya2", "Lapkin3", 45).GetHashCode() % 11);

            //ht.Delete(new Person(5, "Masya", "Lapkin", 45));
            Console.WriteLine(ht.Get(new Person(4, "Kasya", "Babkin", 44).GetHashCode()));

            foreach (var item in ht)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }
}
