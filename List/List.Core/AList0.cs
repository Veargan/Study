using System;

namespace List.Core
{
    public class AList0
    {
        private int[] a;

        private static void Main(string[] args)
        {
        }

        public void Init(int[] arr)
        {
            a = new int[arr.Length];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = arr[i];
            }
        }

        public int Size()
        {
            return a.Length;
        }

        public void Clear()
        {
            a = new int[0];
        }

        public int[] ToArray()
        {
            return a;
        }

        override
            public string ToString()
        {
            string res = "";

            for (int i = 0; i < a.Length; i++)
            {
                res += a[i] + " ";
            }

            return res;
        }

        public void AddStart(int n)
        {
            int[] temp = new int[a.Length + 1];

            for (int i = 0; i < a.Length; i++)
            {
                temp[i + 1] = a[i];
            }
            temp[0] = n;
            a = temp;
        }

        public void AddEnd(int n)
        {
            int[] temp = new int[a.Length + 1];

            for (int i = 0; i < a.Length; i++)
            {
                temp[i] = a[i];
            }
            temp[temp.Length - 1] = n;
            a = temp;
        }

        public void AddPos(int pos, int n)
        {
            int[] temp = new int[a.Length + 1];

            for (int i = 0; i < a.Length; i++)
            {
                if (i < pos - 1)
                {
                    temp[i] = a[i];
                }
                else if (i >= pos - 1)
                {
                    temp[i + 1] = a[i];
                }
            }
            temp[pos - 1] = n;
            a = temp;
        }

        public int DelStart()
        {
            int res = a[0];
            int[] temp = new int[a.Length - 1];

            for (int i = 0; i < a.Length - 1; i++)
            {
                temp[i] = a[i + 1];
            }
            a = temp;

            return res;
        }

        public int DelEnd()
        {
            int res = a[a.Length - 1];
            int[] temp = new int[a.Length - 1];

            for (int i = 0; i < a.Length - 1; i++)
            {
                temp[i] = a[i];
            }
            a = temp;

            return res;
        }

        public int DelPos(int pos)
        {
            int res = a[pos - 1];
            int[] temp = new int[a.Length - 1];

            for (int i = 0; i < a.Length; i++)
            {
                if (i < pos - 1)
                {
                    temp[i] = a[i];
                }
                else if (i >= pos)
                {
                    temp[i - 1] = a[i];
                }
            }
            a = temp;

            return res;
        }

        public void Set(int pos, int n)
        {
            a[pos - 1] = n;
        }

        public int Get(int pos)
        {
            return a[pos - 1];
        }

        public int[] Reverse()
        {
            int[] arr = new int[a.Length];

            for (int i = (a.Length - 1); i >= 0; i--)
            {
                arr[a.Length - i - 1] = a[i];
            }

            return arr;
        }

        public int[] HalfReverse()
        {
            int centr = a.Length/2 + a.Length%2;

            for (int i = 0; i < (a.Length/2); i++)
            {
                int t = a[i];
                a[i] = a[centr + i];
                a[centr + i] = t;
            }

            return a;
        }

        public int Min()
        {
            int min = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }

            return min;
        }

        public int Max()
        {
            int max = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }

            return max;
        }

        public int IndMin()
        {
            int index = 0;

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < a[index])
                {
                    index = i;
                }
            }

            return index;
        }

        public int IndMax()
        {
            int index = 0;

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > a[index])
                {
                    index = i;
                }
            }

            return index;
        }

        public int[] Sort()
        {
            int[] res = a;

            for (int i = 0; i < res.Length; i++)
            {
                for (int j = 0; j < res.Length - i - 1; j++)
                {
                    if (res[j] > res[j + 1])
                    {
                        int tmp = res[j];
                        res[j] = res[j + 1];
                        res[j + 1] = tmp;
                    }
                }
            }

            return res;
        }

        public void Print()
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
}