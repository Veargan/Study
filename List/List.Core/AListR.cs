using System;

namespace List.Core
{
    public class AListR : IList
    {
        public const int MaxLength = 10;
        public int[] array = new int[MaxLength];
        public int start = MaxLength / 2;
        public int end = MaxLength / 2;
        public bool flag = false;

        public void Init(int[] ar)
        {
            if (ar == null) ar = new int[0];

            start = start - (ar.Length / 2);
            for (int i = 0; i < ar.Length; i++)
            {
                array[start + i] = ar[i];
            }
            end = start + ar.Length;
        }

        public void Clear()
        {
            start = MaxLength / 2;
            end = MaxLength / 2;
            flag = false;
        }

        public int[] ToArray()
        {
            int[] result = new int[Size()];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = array[start + i - ((start + i) / array.Length) * array.Length];
            }
            return result;
        }

        public int Size()
        {
            if (flag)
            {
                return array.Length - start + end;
            }
            else
            {
                return end - start;
            }
        }
        
        public void Set(int pos, int value)
        {
            if (pos > Size() - 1) throw new IndexOutOfRangeException();

            array[start + pos - ((start + pos) / array.Length) * array.Length] = value;
        }

        public int Get(int pos)
        {
            if (pos > Size() - 1) throw new IndexOutOfRangeException();

            return array[start + pos - ((start + pos) / array.Length) * array.Length];
        }

        public void AddStart(int value)
        {
            if (end == start) Resize();

            if (start > 0)
            {
                array[--start] = value;
            }
            else
            {
                flag = true;
                start = array.Length - 1;
                array[start] = value;
            }
        }
        public void AddEnd(int value)
        {
            if (end == start) Resize();

            if (end < array.Length)
            {
                array[end] = value;
                end++;
            }
            else
            {
                flag = true;
                end = 1;
                array[end - 1] = value;
            }
        }
        public void AddPos(int pos, int value)
        {
            if (pos < 0 || pos > Size()) throw new IndexOutOfRangeException();
            if (end >= array.Length) end -= array.Length;
            if (end == start) Resize();

            if (flag)
            {
                if (end > array.Length - start)
                {
                    for (int i = end + array.Length; i > start + pos; i--)
                    {
                        array[i - ((i / array.Length) * array.Length)] = array[i - 1 - (((i - 1) / array.Length) * array.Length)];
                    }
                    end++;
                    array[start + pos - ((start + pos) / array.Length) * array.Length] = value;
                }
                else
                {
                    for (int i = start; i < start + pos; i++)
                    {
                        array[i - 1 - (((i - 1) / array.Length) * array.Length)] = array[i - ((i / array.Length) * array.Length)];
                    }
                    start--;
                    array[start + pos - ((start + pos) / array.Length) * array.Length] = value;
                }
            }
            else
            {
                if (start >= array.Length - end)
                {
                    for (int i = start; i < start + pos; i++)
                    {
                        array[i - 1] = array[i];
                    }
                    start--;
                    array[start + pos] = value;
                }
                else
                {
                    for (int i = end; i > start + pos; i--)
                    {
                        array[i] = array[i - 1];
                    }
                    end++;
                    array[start + pos] = value;
                }
            }
        }

        public int DelStart()
        {
            if (start == 0) throw new NullReferenceException();

            int deleted = array[start];

            if (start < array.Length - 1)
            {
                array[start++] = 0;
            }
            else
            {
                array[start] = 0;
                start = 0;
                flag = false;
            }
            return deleted;
        }
        
        public int DelEnd()
        {
            if (end == 0) throw new NullReferenceException();

            int deleted = array[end - 1];

            if (end > 1)
            {
                array[--end] = 0;
            }
            else
            {
                array[end - 1] = 0;
                end = array.Length;
                flag = false;
            }
            return deleted;
        }

        public int DelPos(int pos)
        {
            if (pos > Size() - 1) throw new NullReferenceException();

            int deleted = array[start + pos - ((start + pos) / array.Length) * array.Length];
            if (flag)
            {
                if (end > array.Length - start)
                {
                    for (int i = start + pos; i > start; i--)
                    {
                        array[i - ((i / array.Length) * array.Length)] = array[i - 1 - (((i - 1) / array.Length) * array.Length)];
                    }
                    array[start] = 0;
                    if (start < array.Length - 1)
                    {
                        start++;
                    }
                    else
                    {
                        start = 0;
                        flag = false;
                    }
                }
                else
                {
                    for (int i = start + pos; i < end + array.Length - 1; i++)
                    {
                        array[i - ((i / array.Length) * array.Length)] = array[i + 1 - (((i + 1) / array.Length) * array.Length)];
                    }

                    array[end - 1] = 0;

                    if (end > 1)
                    {
                        end--;
                    }
                    else
                    {
                        end = array.Length;
                        flag = false;
                    }
                }
            }
            else
            {
                if (start >= MaxLength - end)
                {
                    for (int i = pos; i < Size() - 1; i++)
                    {
                        array[start + i] = array[start + i + 1];
                    }

                    array[--end] = 0;
                }
                else
                {
                    for (int i = pos; i > 0; i--)
                    {
                        array[start + i] = array[start + i - 1];
                    }

                    array[start++] = 0;
                }
            }
            return deleted;
        }

        public int Max()
        {
            if (Size() == 0) throw new NullReferenceException();

            int Max = array[start];

            for (int i = 0; i < Size(); i++)
            {
                if (array[start + i - ((start + i) / array.Length) * array.Length] > Max)
                {
                    Max = array[start + i - ((start + i) / array.Length) * array.Length];
                }
            }
            return Max;
        }

        public int Min()
        {
            if (Size() == 0) throw new NullReferenceException();

            int Min = array[start];
            for (int i = 0; i < Size(); i++)
            {
                if (array[start + i - ((start + i) / array.Length) * array.Length] < Min)
                {
                    Min = array[start + i - ((start + i) / array.Length) * array.Length];
                }
            }
            return Min;
        }

        public int IndMax()
        {
            if (Size() == 0) throw new NullReferenceException();

            int indMax = start;
            for (int i = 0; i < Size(); i++)
            {
                if (array[start + i - ((start + i) / array.Length) * array.Length] > array[indMax])
                {
                    indMax = start + i - ((start + i) / array.Length) * array.Length;
                }
            }
            return start > indMax ? indMax + array.Length - start : indMax - start;
        }

        public int IndMin()
        {
            if (Size() == 0) throw new NullReferenceException();

            int indMin = start;
            for (int i = 0; i < Size(); i++)
            {
                if (array[start + i - ((start + i) / array.Length) * array.Length] < array[indMin])
                {
                    indMin = start + i - ((start + i) / array.Length) * array.Length;
                }
            }
            return start > indMin ? indMin + array.Length - start : indMin - start;
        }

        public void Reverse()
        {
            for (int i = 0; i < Size() / 2; i++)
            {
                int temporary = array[start + i - ((start + i) / array.Length) * array.Length];
                array[start + i - ((start + i) / array.Length) * array.Length] = array[end - i - 1 - ((end - i - 1) / array.Length) * array.Length];
                array[end - i - 1 - ((end - i - 1) / array.Length) * array.Length] = temporary;
            }
        }

        public void HalfReverse()
        {
            int step = Size() / 2 + Size() % 2;

            for (int i = 0; i < Size() / 2; i++)
            {
                int temporary = array[start + i - ((start + i) / array.Length) * array.Length];
                array[start + i - ((start + i) / array.Length) * array.Length] = array[start + step + i - ((start + step + i) / array.Length) * array.Length];
                array[start + step + i - ((start + step + i) / array.Length) * array.Length] = temporary;
            }
        }

        public void Sort()
        {
            for (int i = 0; i < Size(); i++)
            {
                for (int j = i + 1; j < Size(); j++)
                {
                    if (array[start + i - ((start + i) / array.Length) * array.Length] > array[start + j - ((start + j) / array.Length) * array.Length])
                    {
                        int temporary = array[start + i - ((start + i) / array.Length) * array.Length];
                        array[start + i - ((start + i) / array.Length) * array.Length] = array[start + j - ((start + j) / array.Length) * array.Length];
                        array[start + j - ((start + j) / array.Length) * array.Length] = temporary;
                    }
                }
            }
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
            int len = Convert.ToInt32(array.Length * 1.3);
            int[] a = ToArray();
            array = new int[len];
            Init(a);
        }
    }
}
