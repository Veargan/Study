using System;

namespace List.Core
{
    public class AList0 : IList
    {
        private int[] array = null;

        public void Init(int [] ar)
        {
            if (ar == null) ar = new int[0];

            array = new int[ar.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ar[i];
            }
        }

        public void Clear()
        {
            array = new int[0];
        }

        public int[] ToArray()
        {
            int[] ar = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                ar[i] = array[i];
            }

            return ar;
        }

        public int Size()
        {
            return array.Length;
        }

        public void AddStart(int val)
        {
            int[] a = new int[array.Length + 1];

            for (int i = 1; i < a.Length; i++)
            {
                a[i] = array[i - 1];
            }

            a[0] = val;
            array = a;
        }

        public void AddEnd(int val)
        {
            int[] a = new int[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                a[i] = array[i];
            }

            a[a.Length-1] = val;
            array = a;
        }

        public void AddPos(int pos, int val)
        {
            int[] a = new int[array.Length + 1];

            for (int i = 0; i < a.Length; i++)
            {
                if (i < pos)
                {
                    a[i] = array[i];
                }
                else if (i == pos)
                {
                    a[i] = val;
                }
                else if (i > pos)
                {
                    a[i] = array[i - 1];
                }
            }

            array = a;
        }

        public int DelStart()
        {
            if (array.Length == 0) throw new NullReferenceException();

            int[] rt = new int[array.Length - 1];
            int value = array[0];

            for (int i = 0; i < rt.Length; i++)
            {
                rt[i] = array[i + 1];
            }
            array = rt;

            return value;
        }

        public int DelEnd()
        {
            if (array.Length == 0) throw new NullReferenceException();

            int dd = array[array.Length - 1];

            int[] tmp = new int[array.Length - 1];

            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = array[i];
            }

            array = tmp;

            return dd;
        }

        public int DelPos(int pos)
        {
            if (pos < 0 || pos >= array.Length) throw new NullReferenceException();

            int dd = array[pos];
            int[] tmp = new int[array.Length - 1];

            for (int i = 0; i < pos; i++)
            {
                tmp[i] = array[i];
            }

            for (int i = pos + 1; i < array.Length; i++)
            {
                tmp[i - 1] = array[i];
            }

            array = tmp;

            return dd;
        }

        public void Set(int pos, int val)
        {
            array[pos] = val;
        }

        public int Get(int pos)
        {
            return array[pos];
        }

        public int Max()
        {
            if (array.Length == 0) throw new NullReferenceException();

            int m = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > m)
                {
                    m = array[i];
                }
            }

            return m;
        }

        public int Min()
        {
            if (array.Length == 0) throw new NullReferenceException();

            int m = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < m)
                {
                    m = array[i];
                }
            }

            return m;
        }

        public int IndMax()
        {
            if (array.Length == 0) throw new NullReferenceException();

            int i = 0;

            for (int j = 1; j < array.Length; j++)
            {
                if (array[j] > array[i])
                {
                    i = j;
                }
            }

            return i;
        }

        public int IndMin()
        {
            if (array.Length == 0) throw new NullReferenceException();

            int i = 0;

            for (int j = 1; j < array.Length; j++)
            {
                if (array[j] < array[i])
                {
                    i = j;
                }
            }

            return i;
        }

        public void Reverse()
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                int tmp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = tmp;
            }
        }

        public void HalfReverse()
        {
            int j = (array.Length % 2 == 0) ? 0 : 1;

            for (int i = 0; i < array.Length / 2; i++)
            {
                int tmp = array[i];
                array[i] = array[array.Length / 2 + i + j];
                array[array.Length / 2 + i + j] = tmp;
            }
        }

        public void Sort()
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (array[i] > array[j])
                    {
                        int tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }
        }

        public override string ToString()
        {
            string res = "";

            for (int i = 0; i < array.Length; i++)
            {
                res += array[i] + " ";
            }

            return res;
        }

        
    }
}