using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class AList2 : IList
    {
        int[] ar = new int[10];
        int start = 5;
        int end = 5;

        public void Resize()
        {
            if (start != 0 && end != ar.Length)
            {
                return;
            }
            int [] a = ToArray();
            ar = new int[(int)(ar.Length * 0.3 + ar.Length)];
            Init(a);

        }
        public int Size()
        {
            return end - start;
        }

        public void Clear()
        {
            start = ar.Length/2;
            end = ar.Length/2;
        }

        public void Init(int[] a)
        {
            if (a == null)
            {
                return;
            }
            Clear();
            start -= a.Length / 2;
            for (int i = 0; i < a.Length; i++)
            {
                ar[i+start] = a[i];
            }
            end = start+a.Length;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = start; i <= end-1; i++)
            {
                str += ar[i];
                str += " ";
            }
            return str;
        }

        public int[] ToArray()
        {
            int[] res = new int[Size()];
            for (int i = 0; i < Size(); i++)
            {
                res[i] = ar[i+start];
            }
            return res;
        }

        public void AddStart(int val)
        {
            Resize();
            ar[start-1] = val;
            start--;
        }

        public void AddEnd(int val)
        {
            Resize();
            ar[end] = val;
            end++;
        }

        public void AddPos(int pos, int value)
        {
            Resize();
            if (pos < 0 || pos > Size())
            {
                throw new Exception();
            }
            if (start <= ar.Length - end-1)
            {
                for (int i = end; i > pos+start; i--)
                {
                    ar[i] = ar[i - 1];
                }
                end++;
            }
            else
            {
                for (int i = start; i < start+pos+1; i++)
                {
                    ar[i-1] = ar[i];
                }
                start--;
            }
            ar[pos+start] = value;
        }

        public int DelStart()
        {
            if (Size() == 0 || ar == null)
            {
                throw new Exception("Empty array");
            }

            int res = ar[start];

            for (int i = start; i < end; i++)
            {
                ar[i] = ar[i + 1];
            }

            end--;
            return res;
        }

        public int DelEnd()
        {
            if (Size() == 0)
            {
                throw new Exception("Empty array");
            }
            int res = ar[end-1];
            end--;
            return res;
        }

        public int DelPos(int pos)
        {
            if (pos < 0 || pos > Size() || Size() == 0)
            {
                throw new Exception();
            }

            int res = ar[pos+start];
            for (int i = pos+start; i < end; i++)
            {
                ar[i] = ar[i + 1];
            }
            end--;
            return res;
        }

        public void Set(int pos, int val)
        {
            if (pos < 0 || pos > Size())
            {
                throw new Exception();
            }
            ar[pos+start] = val;
        }

        public int Get(int pos)
        {
            if (pos < 0 || pos > Size())
            {
                throw new Exception();
            }
            return ar[pos+start];
        }

        public int Min()
        {
            return ar[IndMin()+start];
        }

        public int Max()
        {
            return ar[IndMax()+start];
        }

        public int IndMin()
        {
            if (ar == null || Size() == 0)
            {
                throw new ArgumentException("Invalid array");
            }

            int ind = 0;

            for (int i = 1; i < Size(); i++)
            {
                if (ar[i+start] < ar[ind+start])
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
                throw new ArgumentException("Invalid array");
            }

            int ind = 0;

            for (int i = 1; i < Size(); i++)
            {
                if (ar[i+start] > ar[ind+start])
                {
                    ind = i;
                }
            }
            return ind;
        }
        
        public void HalfReverse()
        {
            int dx = (Size() % 2 == 0) ? 0 : 1;
            for (int i = 0; i < Size() / 2; i++)
            {
                int tmp = ar[i + start];
                ar[i + start] = ar[Size() / 2 + dx + i + start];
                ar[Size() / 2 + dx + i + start] = tmp;
            } 
        }

        public void Reverse()
        {
            for (int i = 0; i < Size() / 2; i++)
            {
                int tmp = ar[i + start];
                ar[i + start] = ar[Size() - 1 - i + start];
                ar[Size() - 1 - i + start] = tmp;
            } 
        }

        public void Sort()
        {
            if (Size() == 0)
            {
                throw new ArgumentException("Invalid array");
            }
            for (int i = start; i < end; i++)
            {
                int minElementIndex = i;
                for (int j = i; j < end; j++)
                {
                    if (ar[minElementIndex] > ar[j])
                    {
                        minElementIndex = j;
                    }
                }
                int tmpElement = ar[minElementIndex];
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
