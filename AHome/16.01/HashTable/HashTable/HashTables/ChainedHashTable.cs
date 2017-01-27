using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class ChainedHashTable : IHashTable
    {
        public ChainedHashTable()
        {
            Capacity = 11;
            personArray = new List<Person>[Capacity];
        }

        private List<Person>[] personArray;
        public int Capacity { get; }
        private int _iterator = -1;
        private int _listIterator = -1;
        private bool iteratorTrigger = true;

        #region Enumerator
        public object Current
        {
            get
            {
                Person p = personArray[_iterator][_listIterator];
                if (iteratorTrigger == true)
                {
                    _listIterator = -1;
                }
                return p;
            }
        }

        public bool MoveNext()
        {
            bool res;
            if (_iterator == Capacity - 1)
            {
                Reset();
                res = false;
            }
            else
            {
                int delta = (iteratorTrigger == false) ? 0 : 1;

                if (personArray[_iterator + delta] == null)
                {
                    _iterator++;
                    return MoveNext();
                }

                if (personArray[_iterator + delta].Count > _listIterator)
                {
                    _listIterator++;
                    if (iteratorTrigger)
                    {
                        _iterator++;
                    }
                    res = true;

                    if (personArray[_iterator].Count > 1 && personArray[_iterator].Count != _listIterator + 1)
                    {
                        iteratorTrigger = false;
                    }
                    if (personArray[_iterator].Count == _listIterator + 1)
                    {
                        iteratorTrigger = true;
                    }
                }
                else
                {
                    _listIterator = -1;
                    res = false;
                }
            }

            return res;
        }

        public void Reset()
        {
            _iterator = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
        #endregion

        public void Add(Person p)
        {
            if (p == null)
            {
                throw new NullReferenceException();
            }
            if (Size() == Capacity)
            {
                throw new ArgumentOutOfRangeException();
            }

            int k = p.GetHashCode();
            int i = k % Capacity;

            if (personArray[i] == null)
            {
                personArray[i] = new List<Person>();
            }

            personArray[i].Add(p);
        }

        public Person Get(int hashCode)
        {
            int i = hashCode % Capacity;
            if (personArray[i] == null)
            {
                throw new NullReferenceException();
            }

            Person p = null;
            for (int j = 0; j < personArray[i].Count; j++)
            {
                if (hashCode == personArray[i][j].GetHashCode())
                {
                    p = personArray[i][j];
                    break;
                }
            }
            if (p == null)
            {
                throw new NullReferenceException();
            }

            return p;
        }

        public Person Get(Person p)
        {
            if (p == null)
            {
                throw new NullReferenceException();
            }

            int hashCode = p.GetHashCode();
            int i = hashCode % Capacity;
            if (personArray[i] == null)
            {
                throw new NullReferenceException();
            }

            Person person = null;
            for (int j = 0; j < personArray[i].Count; j++)
            {
                if (p.Equals(personArray[i][j]))
                {
                    person = personArray[i][j];
                    break;
                }
            }
            if (person == null)
            {
                throw new NullReferenceException();
            }

            return person;
        }

        public int GetPosition(int hashCode)
        {
            int i = hashCode % Capacity;
            if (personArray[i] == null)
            {
                throw new NullReferenceException();
            }

            Person p = null;
            for (int j = 0; j < personArray[i].Count; j++)
            {
                if (hashCode == personArray[i][j].GetHashCode())
                {
                    p = personArray[i][j];
                    break;
                }
            }
            if (p == null)
            {
                throw new NullReferenceException();
            }

            return i;
        }

        public int GetPosition(Person p)
        {
            if (p == null)
            {
                throw new NullReferenceException();
            }

            int hashCode = p.GetHashCode();
            int i = hashCode % Capacity;
            if (personArray[i] == null)
            {
                throw new NullReferenceException();
            }

            Person res = null;
            for (int j = 0; j < personArray[i].Count; j++)
            {
                if (hashCode == personArray[i][j].GetHashCode())
                {
                    res = personArray[i][j];
                    break;
                }
            }
            if (res == null)
            {
                throw new NullReferenceException();
            }

            return i;
        }

        public void Delete(Person p)
        {
            if (p == null)
            {
                throw new NullReferenceException();
            }

            int hashCode = p.GetHashCode();
            int i = hashCode % Capacity;

            if (personArray[i] == null)
            {
                throw new NullReferenceException();
            }

            personArray[i].Remove(p);
            if (personArray[i].Count == 0)
            {
                personArray[i] = null;
            }
        }

        public double GetKP()
        {
            double size = Size();
            return Math.Round(size / Capacity, 2);
        }

        public int Size()
        {
            int size = 0;

            for (int i = 0; i < Capacity; i++)
            {
                if (personArray[i] != null)
                {
                    for (int j = 0; j < personArray[i].Count; j++)
                    {
                        size++;
                    }
                }
            }

            return size;
        }

        public void Clear()
        {
            for (int i = 0; i < Capacity; i++)
            {
                personArray[i] = null;
            }
        }

        public Person[] ToArray()
        {
            List<Person> personList = new List<Person>();

            foreach (var list in personArray)
            {
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        personList.Add(item);
                    }
                }
            }

            return personList.ToArray();
        }

        public override bool Equals(object obj)
        {
            bool res = true;
            ChainedHashTable ht = obj as ChainedHashTable;

            if (ht.Size() != Size())
            {
                res = false;
            }
            else
            {
                Person[] personArray1 = ToArray();
                Person[] personArray2 = ht.ToArray();

                for (int i = 0; i < personArray1.Length; i++)
                {
                    if (!personArray1[i].Equals(personArray2[i]))
                    {
                        res = false;
                        break;
                    }
                    else
                    {
                        res = true;
                    }
                }
            }

            return res;
        }

    }
}