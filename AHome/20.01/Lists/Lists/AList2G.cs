using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class AList2G<T> 
    {
        T[] ar = new T[10];
        int start = 5;
        int end = 5;

        public void Resize()
        {
            if (start != 0 && end != ar.Length)
            {
                return;
            }
            T[] a = ToArray();
            ar = new T[(int)(ar.Length * 0.3 + ar.Length)];
            Init(a);

        }
        public int Size()
        {
            return end - start;
        }

        public void Clear()
        {
            start = ar.Length / 2;
            end = ar.Length / 2;
        }

        public void Init(T[] a)
        {
            if (a == null)
            {
                return;
            }
            Clear();
            start -= a.Length / 2;
            for (int i = 0; i < a.Length; i++)
            {
                ar[i + start] = a[i];
            }
            end = start + a.Length;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = start; i <= end - 1; i++)
            {
                str += ar[i];
                str += " ";
            }
            return str;
        }

        public T[] ToArray()
        {
            T[] res = new T[Size()];
            for (int i = 0; i < Size(); i++)
            {
                res[i] = ar[i + start];
            }
            return res;
        }

        public void AddStart(T val)
        {
            Resize();
            ar[start - 1] = val;
            start--;
        }

        public void AddEnd(T val)
        {
            Resize();
            ar[end] = val;
            end++;
        }

        public void AddPos(int pos, T value)
        {
            Resize();
            if (pos < 0 || pos > Size())
            {
                throw new Exception();
            }
            if (start <= ar.Length - end - 1)
            {
                for (int i = end; i > pos + start; i--)
                {
                    ar[i] = ar[i - 1];
                }
                end++;
            }
            else
            {
                for (int i = start; i < start + pos + 1; i++)
                {
                    ar[i - 1] = ar[i];
                }
                start--;
            }
            ar[pos + start] = value;
        }

        public T DelStart()
        {
            if (Size() == 0 || ar == null)
            {
                throw new Exception("Empty array");
            }

            T res = ar[start];

            for (int i = start; i < end; i++)
            {
                ar[i] = ar[i + 1];
            }

            end--;
            return res;
        }

        public T DelEnd()
        {
            if (Size() == 0)
            {
                throw new Exception("Empty array");
            }
            T res = ar[end - 1];
            end--;
            return res;
        }

        public T DelPos(int pos)
        {
            if (pos < 0 || pos > Size() || Size() == 0)
            {
                throw new Exception();
            }

            T res = ar[pos + start];
            for (int i = pos + start; i < end; i++)
            {
                ar[i] = ar[i + 1];
            }
            end--;
            return res;
        }

        public void Set(int pos, T val)
        {
            if (pos < 0 || pos > Size())
            {
                throw new Exception();
            }
            ar[pos + start] = val;
        }

        public T Get(int pos)
        {
            if (pos < 0 || pos > Size())
            {
                throw new Exception();
            }
            return ar[pos + start];
        }

        public T Min()
        {
            return ar[IndMin() + start];
        }

        public T Max()
        {
            return ar[IndMax() + start];
        }

        public int IndMin()
        {
            if (ar == null || Size() == 0)
            {
                throw new Exception();
            }

            int ind = 0;

            for (int i = 1; i < Size(); i++)
            {
                if (Comp(i + start, ind + start))
                {
                    ind = i;
                }
            }
            return ind;
        }

        public int IndMax()
        {
            if (ar == null || Size() == 0)
            {
                throw new Exception();
            }

            int ind = 0;

            for (int i = 1; i < Size(); i++)
            {
                if (Comp(ind + start, i + start))
                {
                    ind = i;
                }
            }
            return ind;
        }

        private bool Comp(int i, int j)
        {
            if (typeof(T) == typeof(int))
            {
                if (Convert.ToInt32(ar[i]) < Convert.ToInt32(ar[j]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (typeof(T) == typeof(string))
            {
                if (Convert.ToString(ar[i]).CompareTo(Convert.ToString(ar[j])) == -1)
                {
                    return true;
                }
                else if (Convert.ToString(ar[i]).CompareTo(Convert.ToString(ar[j])) == 1)
                {
                    return false;
                }
            }
            return false;
        }

        public void HalfReverse()
        {
            int dx = (Size() % 2 == 0) ? 0 : 1;
            for (int i = 0; i < Size() / 2; i++)
            {
                T tmp = ar[i + start];
                ar[i + start] = ar[Size() / 2 + dx + i + start];
                ar[Size() / 2 + dx + i + start] = tmp;
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Size() / 2; i++)
            {
                T tmp = ar[i + start];
                ar[i + start] = ar[Size() - 1 - i + start];
                ar[Size() - 1 - i + start] = tmp;
            }
        }

        public void Sort()
        {
            if (Size() == 0)
            {
                throw new Exception("Invalid array");
            }
            for (int i = start; i < end; i++)
            {
                int minElementIndex = i;
                for (int j = i; j < end; j++)
                {
                    if (Comp(j, minElementIndex))
                    {
                        minElementIndex = j;
                    }
                }
                T tmpElement = ar[minElementIndex];
                ar[minElementIndex] = ar[i];
                ar[i] = tmpElement;
            }
        }

        public void Print()
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(ar[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
