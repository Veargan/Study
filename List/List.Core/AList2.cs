using System;

namespace List.Core
{
    public class AList2 : IList
    {
        public int[] array = new int[30];
        public int start = 15;
        public int end = 15;

        public void Init(int[] ar)
        {
            if (ar == null) ar = new int[0];

            Clear();
            start = start - array.Length / 2;
            for (int i = 0; i < ar.Length; i++)
            {
                this.array[start + i] = ar[i];
            }
            end = start + ar.Length;
        }

        public void Clear()
        {
            start = end = array.Length / 2;
        }

        public int[] ToArray()
        {
            int[] ar = new int[end - start];
            for (int i = start; i < end; i++)
            {
                ar[i] = array[i];
            }

            return ar;
        }

        public int Size()
        {
            if (array == null || end > array.Length || end < 0 || start > array.Length || start < 0) throw new NullReferenceException();

            return end - start;
        }
        
        public void AddStart(int val)
        {
            if (Size() == array.Length || start == 0 || end == array.Length - 1)
            {
                Resize();
            }
            for (int i = end++; i > 0; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = val;
        }

        public void AddEnd(int val)
        {
            if (Size() == array.Length || start == 0 || end == array.Length - 1)
            {
                Resize();
            }
            array[end++] = val;
        }

        public void AddPos(int pos, int value)
        {
            if (pos > end) throw new IndexOutOfRangeException();

            if (Size() == array.Length || start == 0 || end == array.Length - 1)
            {
                Resize();
            }

            end++;
            for (int i = end; i > pos; i--)
            {
                array[i] = array[i - 1];
            }
            array[pos] = value;
        }

        public int DelStart()
        {
            if (end == 0) throw new NullReferenceException();

            int res = array[0];
            for (int i = start; i < end; i++)
            {
                array[i] = array[i + 1];
            }
            end--;

            return res;
        }

        public int DelEnd()
        {
            if (end == 0) throw new NullReferenceException();

            return array[--end];
        }

        public int DelPos(int pos)
        {
            if (pos >= end) throw new NullReferenceException();

            int res = array[pos];
            for (int i = pos; i < end; i++)
            {
                array[i] = array[i + 1];
            }
            end--;

            return res;
        }
        
        public void Set(int pos, int val)
        {
            if (pos > end || end == 0) throw new IndexOutOfRangeException();

            array[start + pos] = val;
        }
        public int Get(int pos)
        {
            if (pos > end || end == 0) throw new IndexOutOfRangeException();

            return array[pos];
        }

        public int Max()
        {
            if (end == 0) throw new NullReferenceException();

            int m = array[0];
            for (int i = start; i < end; i++)
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
            if (end == 0) throw new NullReferenceException();

            int m = array[0];
            for (int i = start; i < end; i++)
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
            if (end == 0) throw new NullReferenceException();

            int i = 0;
            for (int j = start; j < end; j++)
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
            if (end == 0) throw new NullReferenceException();

            int i = 0;
            for (int j = start; j < end; j++)
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
            for (int i = start; i < end / 2; i++)
            {
                int tmp = array[i];
                array[i] = array[end - i - 1];
                array[end - i - 1] = tmp;
            }
        }

        public void HalfReverse()
        {
            int j = (end % 2 == 0) ? 0 : 1;
            for (int i = 0; i < end / 2; i++)
            {
                int tmp = array[i];
                array[i] = array[end / 2 + i + j];
                array[end / 2 + i + j] = tmp;
            }
        }

        public void Sort()
        {
            for (int i = start; i < end; i++)
            {
                for (int j = end - 1; j > i; j--)
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
            for (int i = start; i < end; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            string ar = "";

            for (int i = start; i < end; i++)
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
