using System;

namespace List.Core
{
    public class AList1
    {
        private int[] arr = new int[10];
        private int index = 0;

        public void SetArray(int[] a)
        {
            Init(a);
        }


        public int Size()
        {
            return index;
        }


        public void Init(int[] arr)
        {
            if (arr == null) throw new NullReferenceException();

            Clear();
            for (int i = 0; i < arr.Length; i++)
            {
                this.arr[i] = arr[i];
            }
            index = arr.Length;
        }


        public void AddEnd(int val)
        {
            arr[index++] = val;
        }


        public int[] GetArray()
        {
            int[] temp = new int[index];

            for (int i = 0; i < index; i++)
            {
                temp[i] = arr[i];
            }

            return temp;
        }

        public int Max()
        {
            if (index == 0) throw new IndexOutOfRangeException();

            int chMax = arr[0];

            for (int i = 0; i < index; i++)
            {
                if (arr[i] > chMax)
                {
                    chMax = arr[i];
                }
            }

            return chMax;
        }

        public int Min()
        {
            if (index == 0) throw new IndexOutOfRangeException();

            int chMax = arr[0];

            for (int i = 0; i < index; i++)
            {
                if (arr[i] < chMax)
                {
                    chMax = arr[i];
                }
            }

            return chMax;
        }

        public int MaxIndex()
        {
            if (index == 0) throw new IndexOutOfRangeException();

            int indexRes = 0;
            int chMax = arr[0];

            for (int i = 1; i < index; i++)
            {
                if (arr[i] > chMax)
                {
                    chMax = arr[i];
                    indexRes = i;
                }
            }

            return indexRes;
        }

        public int MinIndex()
        {
            if (index == 0) throw new IndexOutOfRangeException();

            int indexRes = 0;
            int chMin = arr[0];

            for (int i = 1; i < index; i++)
            {
                if (arr[i] < chMin)
                {
                    indexRes = i;
                    chMin = arr[i];
                }
            }

            return indexRes;
        }

        public void Reverse()
        {
            int[] resArr = new int[arr.Length];
            int j = 0;

            for (int i = index - 1; i >= 0; i--)
            {
                resArr[j] = arr[i];
                j++;
            }
            arr = resArr;
        }

        public void HalfReverse()
        {
            int[] resArr = new int[arr.Length];
            int j = 0;

            for (int i = index/2; i >= 0; i--)
            {
                resArr[j] = arr[i];
                j++;
            }
            arr = resArr;
        }

        public void Sort()
        {
            for (int i = index - 1; i >= 1; i--)
            {
                bool sorted = true;
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        sorted = false;
                    }
                }
                if (sorted)
                {
                    break;
                }
            }
        }


        public int DelEnd()
        {
            if (index == 0) throw new IndexOutOfRangeException();

            int delEnd = arr[arr.Length - 1];
            index--;

            return delEnd;
        }


        public void AddStart(int val)
        {
            index++;
            int[] tmp = new int[arr.Length];
            for (int i = 1; i < Size(); i++)
            {
                tmp[i] = arr[i - 1];
            }
            tmp[0] = val;
            arr = tmp;
        }


        public int DelStart()
        {
            if (index == 0) throw new IndexOutOfRangeException();

            index--;
            int delRes = arr[0];
            int[] tmp = new int[arr.Length];

            for (int i = 0; i < Size(); i++)
            {
                tmp[i] = arr[i + 1];
            }
            arr = tmp;

            return delRes;
        }


        public void AddPos(int pos, int val)
        {
            index++;

            int[] temp = new int[arr.Length];
            for (int i = 0; i < Size(); i++)
                if (i < pos)
                {
                    temp[i] = arr[i];
                }
                else if (i == pos)
                {
                    temp[pos] = val;
                }
                else
                {
                    temp[i] = arr[i - 1];
                }
            arr = temp;
        }


        public int DelPos(int pos)
        {
            if (pos >= index) throw new IndexOutOfRangeException();

            int delRes = arr[pos];

            for (int i = pos; i < index; i++)
            {
                arr[i] = arr[i + 1];
            }
            index--;

            return delRes;
        }


        public void Set(int pos, int val)
        {
            if (pos >= index) throw new IndexOutOfRangeException();

            arr[pos] = val;
        }


        public int Get(int pos)
        {
            if (pos >= index) throw new IndexOutOfRangeException();

            return arr[pos];
        }


        public void Clear()
        {
            index = 0;
        }


        public int[] ToArray()
        {
            int[] temp = new int[index];

            for (int i = 0; i < index; i++)
            {
                temp[i] = arr[i];
            }

            return temp;
        }
    }
}