using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public interface IHashTable : IEnumerator, IEnumerable
    {
        int Capacity { get; }
        void Add(Person p);
        Person Get(Person p);
        Person Get(int hashCode);
        int GetPosition(Person p);
        int GetPosition(int hashCode);
        void Delete(Person p);
        double GetKP();
        int Size();
        void Clear();
        Person[] ToArray();
    }
}