using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class LinearHashTable : IHashTable
    {
        public LinearHashTable()
        {
            Capacity = 11;
            personArray = new Person[Capacity];
        }


        private Person[] personArray;
        private int _iterator = -1;
        public int Capacity { get; }

        #region Enumerator
        public object Current
        {
            get
            {
                return personArray[_iterator];
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
                _iterator++;

                if (personArray[_iterator] == null)
                {
                    return MoveNext();
                }

                res = true;
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

            int k = p.GetHashCode();
            int i = k % Capacity;
            int j = 0;

            for ( ; personArray[i] != null && j < Capacity; j++)
            {
                if (i + 1 == Capacity)
                {
                    i = 0;
                }
                i++;
            }

            if (j == Capacity)
            {
                throw new ArgumentOutOfRangeException();
            }

            personArray[i] = p;

        }

        public Person Get(int hashCode)
        {
            int i = hashCode % Capacity;
            if (personArray[i] == null)
            {
                throw new NullReferenceException();
            }
            if (personArray[i].GetHashCode() != hashCode)
            {
                for (int j = 0; personArray[i] != null && j < Capacity; j++)
                {
                    if (i + 1 == Capacity)
                    {
                        i = 0;
                    }

                    if (personArray[i].GetHashCode() == hashCode)
                    {
                        break;
                    }

                    i++;
                }
            }
            return personArray[i];
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
            if (personArray[i].GetHashCode() != hashCode)
            {
                for (int j = 0; personArray[i] != null && j < Capacity; j++)
                {
                    if (i + 1 == Capacity)
                    {
                        i = 0;
                    }

                    if (personArray[i].GetHashCode() == hashCode)
                    {
                        break;
                    }

                    i++;
                }
            }
            return personArray[i];
        }

        public int GetPosition(int hashCode)
        {
            int i = hashCode % Capacity;
            if (personArray[i] == null)
            {
                throw new NullReferenceException();
            }
            if (!personArray[i].Equals(Get(hashCode)))
            {
                for (int j = 0; personArray[i] != null && j < Capacity; j++)
                {
                    if (i + 1 == Capacity)
                    {
                        i = 0;
                    }

                    if (personArray[i].GetHashCode() == hashCode)
                    {
                        break;
                    }

                    i++;
                }
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
            if (!personArray[i].Equals(Get(hashCode)))
            {
                for (int j = 0; personArray[i] != null && j < Capacity; j++)
                {
                    if (i + 1 == Capacity)
                    {
                        i = 0;
                    }

                    if (personArray[i].GetHashCode() == hashCode)
                    {
                        break;
                    }

                    i++;
                }
            }
            return i;
        }

        public void Delete(Person p)
        {
            if (p == null || Size() == 0)
            {
                throw new NullReferenceException();
            }

            int hashCode = p.GetHashCode();
            int i = hashCode % Capacity;

            if (!personArray[i].Equals(Get(hashCode)))
            {
                for (int j = 0; personArray[i] != null && j < Capacity; j++)
                {
                    if (i + 1 == Capacity)
                    {
                        i = 0;
                    }

                    if (personArray[i].Equals(Get(hashCode)))
                    {
                        break;
                    }

                    i++;
                }
            }
            
            personArray[i] = null;
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
                    size++;
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

            foreach (var item in personArray)
            {
                if (item != null)
                {
                    personList.Add(item);
                }
            }

            return personList.ToArray();
        }

        public override bool Equals(object obj)
        {
            bool res = true;
            LinearHashTable ht = obj as LinearHashTable;

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