using System;

namespace List.Core
{
    public class AList1 : IList
    {
        public int[] array = new int[10];
        public int top = 0;

        public void Init(int[] ar)
        {
            if (ar == null) ar = new int[0];

            Clear();
            top = ar.Length;

            if (array.Length <= ar.Length)
            {
                array = new int[ar.Length + ar.Length / 2];
            }

            for (int i = 0; i < ar.Length; i++)
            {
                array[i] = ar[i];
            }
            top = ar.Length;
        }

        public void Clear()
        {
            top = 0;
        }

        public int[] ToArray()
        {
            int[] ar = new int[top];
            for (int i = 0; i < top; i++)
            {
                ar[i] = array[i];
            }
            return ar;
        }

        public int Size()
        {
            if (array == null || top > array.Length || top < 0) throw new NullReferenceException();

            return top;
        }

        public void Set(int pos, int val)
        {
            if (pos > top || top == 0) throw new IndexOutOfRangeException();

            array[pos] = val;
        }
        public int Get(int pos)
        {
            if (pos > top || top == 0) throw new IndexOutOfRangeException();

            return array[pos];
        }
        
        public void AddStart(int val)
        {
            Resize();
            for (int i = top++; i > 0; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = val;
        }
        public void AddEnd(int val)
        {
            Resize();
            array[top++] = val;
        }
        public void AddPos(int pos, int value)
        {
            Resize();
            if (pos > top) throw new IndexOutOfRangeException();

            top++;
            for (int i = top; i > pos; i--)
            {
                array[i] = array[i - 1];
            }
            array[pos] = value;
        }
        public int DelStart()
        {
            if (top == 0) throw new NullReferenceException();

            int res = array[0];
            for (int i = 0; i < top; i++)
            {
                array[i] = array[i + 1];
            }
            top--;
            return res;
        }
        public int DelEnd()
        {
            if (top == 0) throw new NullReferenceException();

            int a = array[top - 1];
            top--;
            return a;
        }
        public int DelPos(int pos)
        {
            if (pos >= top) throw new NullReferenceException();

            int res = array[pos];
            for (int i = pos; i < top; i++)
            {
                array[i] = array[i + 1];
            }
            top--;
            return res;
        }

        public int Max()
        {
            if (top == 0) throw new NullReferenceException();

            int m = array[0];
            for (int i = 1; i < top; i++)
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
            if (top == 0) throw new NullReferenceException();

            int m = array[0];
            for (int i = 1; i < top; i++)
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
            if (top == 0) throw new NullReferenceException();

            int i = 0;
            for (int j = 1; j < top; j++)
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
            if (top == 0) throw new NullReferenceException();

            int i = 0;
            for (int j = 1; j < top; j++)
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
            for (int i = 0; i < top / 2; i++)
            {
                int tmp = array[i];
                array[i] = array[top - i - 1];
                array[top - i - 1] = tmp;
            }
        }
        public void HalfReverse()
        {
            int j = (top % 2 == 0) ? 0 : 1;
            for (int i = 0; i < top / 2; i++)
            {
                int tmp = array[i];
                array[i] = array[top / 2 + i + j];
                array[top / 2 + i + j] = tmp;
            }
        }
        
        public void Sort()
        {
            for (int i = 0; i < top; i++)
            {
                for (int j = top - 1; j > i; j--)
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
        
        public void Print()
        {
            for (int i = 0; i < top; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        override public string ToString()
        {
            string ar = "";
            for (int i = 0; i < top; i++)
            {
                ar += array[i] + " ";
            }
            return ar;
        }

        private void Resize()
        {
            int[] a = ToArray();

            if (Size() == array.Length)
            {
                array = new int[(int)(array.Length + (array.Length * 0.3))];
            }
            Init(a);
        }
    }
}