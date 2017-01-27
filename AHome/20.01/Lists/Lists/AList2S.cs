using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class AList2S
    {
        object[] ar = new object[10];
        int start = 5;
        int end = 5;
        Type type = null;

        public void Resize()
        {
            if (start != 0 && end != ar.Length)
            {
                return;
            }
            object[] a = ToArray();
            ar = new object[(int)(ar.Length * 0.3 + ar.Length)];
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
            ar = new object[10];
            type = null;
        }

        public void Init(object a)
        {
            if (a == null)
            {
                return;
            }
            Clear();
            Array o = null;
            if (a is Int32[])
            {
                type = typeof(Int32);
                o = a as int[];
            }
            else if (a is string[])
            {
                type = typeof(string);
                o = a as string[];
            }

            start -= o.GetLength(0) / 2;
            for (int i = 0; i < o.GetLength(0); i++)
            {
                ar[i + start] = o.GetValue(i);
            }
            end = start + o.GetLength(0);
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

        public object[] ToArray()
        {
            object[] res = new object[Size()];
            for (int i = 0; i < Size(); i++)
            {
                res[i] = ar[i + start];
            }
            return res;
        }

        public void AddStart(object val)
        {
            if (val.GetType() != type)
            {
                throw new Exception();
            }

            Resize();
            ar[start - 1] = val;
            start--;          
        }

        public void AddEnd(object val)
        {
            if (val.GetType() != type)
            {
                throw new Exception();
            }      
                     
            Resize();
            ar[end] = val;
            end++;            
        }

        public void AddPos(int pos, object val)
        {
            if (pos < 0 || pos > Size())
            {
                throw new Exception();
            }
            if (val.GetType() != type)
            {
                throw new Exception();
            }

            Resize();
               
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
            ar[pos + start] = val;
        }
        

        public object DelStart()
        {
            if (Size() == 0 || ar == null)
            {
                throw new Exception();
            }

            object res = ar[start];

            for (int i = start; i < end; i++)
            {
                ar[i] = ar[i + 1];
            }

            end--;
            return res;
        }

        public object DelEnd()
        {
            if (Size() == 0)
            {
                throw new Exception();
            }
            object res = ar[end - 1];
            end--;
            return res;
        }

        public object DelPos(int pos)
        {
            if (pos < 0 || pos > Size() || Size() == 0)
            {
                throw new Exception();
            }

            object res = ar[pos + start];
            for (int i = pos + start; i < end; i++)
            {
                ar[i] = ar[i + 1];
            }
            end--;
            return res;
        }

        public void Set(int pos, object val)
        {
            if (pos < 0 || pos > Size())
            {
                throw new Exception();
            }

            if (val.GetType() != type)
            {
                throw new Exception();
            }

            ar[pos + start] = val;
        }

        public object Get(int pos)
        {
            if (pos < 0 || pos > Size())
            {
                throw new Exception();
            }
            return ar[pos + start];
        }

        public object Min()
        {
            return ar[IndMin() + start];
        }

        public object Max()
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

        private bool Comp(int i, int j)
        {
            if (type == typeof(Int32))
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
            if (type == typeof(string))
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
        public int IndMax()
        {
            if (ar == null || Size() == 0)
            {
                throw new ArgumentException();
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

        public void HalfReverse()
        {
            int dx = (Size() % 2 == 0) ? 0 : 1;
            for (int i = 0; i < Size() / 2; i++)
            {
                object tmp = ar[i + start];
                ar[i + start] = ar[Size() / 2 + dx + i + start];
                ar[Size() / 2 + dx + i + start] = tmp;
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Size() / 2; i++)
            {
                object tmp = ar[i + start];
                ar[i + start] = ar[Size() - 1 - i + start];
                ar[Size() - 1 - i + start] = tmp;
            }
        }

        public void Sort()
        {
            if (Size() == 0)
            {
                throw new Exception();
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
                object tmpElement = ar[minElementIndex];
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
