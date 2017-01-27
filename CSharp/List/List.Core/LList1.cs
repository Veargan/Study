using System;
using System.Text;

namespace List.Core
{
    public class LList1 : IList
    {
        private class Node
        {
            public int val;
            public Node next;

            public Node(int val)
            {
                this.val = val;
                this.next = null;
            }
        }

        private Node root = null;

        public LList1()
        {
            this.root = null;
        }

        public void Init(int[] ar)
        {
            if (ar == null || ar.Length == 0)
                ar = new int[0];

            Clear();

            for (int i = 0; i < ar.Length; i++)
            {
                AddEnd(ar[i]);
            }
        }

        public void Clear()
        {
            root = null;
        }

        public int[] ToArray()
        {
            int[] res = new int[Size()];
            int i = 0;
            Node tmp = root;
            while (tmp != null)
            {
                res[i++] = tmp.val;
                tmp = tmp.next;
            }
            return res;
        }

        public int Size()
        {
            int res = 0;

            Node tmp = root;
            while (tmp != null)
            {
                res++;
                tmp = tmp.next;
            }
            return res;
        }

        public void Set(int pos, int val)
        {
            if (pos >= Size() || pos < 0)
                throw new IndexOutOfRangeException();

            Node tmp = root;
            Node etmp = new Node(val);
            for (int i = 1; i <= pos; i++)
            {
                tmp = tmp.next;
            }
            tmp.val = etmp.val;
        }

        public int Get(int pos)
        {
            if (pos >= Size() || pos < 0)
                throw new IndexOutOfRangeException();

            int res = 0;
            Node tmp = root;
            for (int i = 1; i <= pos; i++)
            {
                tmp = tmp.next;
            }
            res = tmp.val;

            return res;
        }

        public void AddStart(int val)
        {
            Node tmp = new Node(val);
            tmp.next = root;
            root = tmp;
        }

        public void AddEnd(int val)
        {
            if (root == null)
            {
                AddStart(val);
                return;
            }

            Node tmp = root;
            while (tmp.next != null)
            {
                tmp = tmp.next;
            }
            tmp.next = new Node(val);
        }

        public void AddPos(int pos, int val)
        {
            if (pos < 0 || pos > Size())
                throw new IndexOutOfRangeException();

            if (pos == 0)
            {
                AddStart(val);
                return;
            }
            Node tmp = root;
            Node etmp = new Node(val);
            for (int i = 1; i < pos; i++)
            {
                tmp = tmp.next;
            }
            etmp.next = tmp.next;
            tmp.next = etmp;
        }

        public int DelStart()
        {
            if (root == null)
                throw new NullReferenceException();

            int res = 0;
            res = root.val;
            root = root.next;

            return res;
        }

        public int DelEnd()
        {
            if (root == null)
                throw new NullReferenceException();

            int res = 0;

            if (root.next == null)
            {
                res = root.val;
                root = null;

                return res;
            }
            Node tmp = root;
            for (int i = 1; i < Size() - 1; i++)
            {
                tmp = tmp.next;
            }
            res = tmp.next.val;
            tmp.next = null;

            return res;
        }

        public int DelPos(int pos)
        {
            if (pos < 0 || pos >= Size())
                throw new NullReferenceException();

            int res = 0;

            if (pos == 0)
            {
                res = root.val;
                root.next = null;
                root = root.next;

                return res;
            }
            Node tmp = root;
            for (int i = 1; i < pos; i++)
            {
                tmp = tmp.next;
            }
            res = tmp.next.val;
            tmp.next = tmp.next.next;
            tmp = null;

            return res;
        }

        public int Max()
        {
            if (root == null)
                throw new NullReferenceException();

            int max = 0;
            Node tmp = root;
            max = tmp.val;
            for (int i = 1; i < Size(); i++)
            {
                if (max < tmp.next.val)
                {
                    max = tmp.next.val;
                }
                tmp = tmp.next;
            }

            return max;
        }

        public int Min()
        {
            if (root == null)
                throw new NullReferenceException();

            int min = 0;
            Node tmp = root;
            min = tmp.val;
            for (int i = 1; i < Size(); i++)
            {
                if (min > tmp.next.val)
                {
                    min = tmp.next.val;
                }
                tmp = tmp.next;
            }

            return min;
        }

        public int IndMax()
        {
            if (root == null)
                throw new NullReferenceException();

            int index = 0;
            Node tmp = root;
            for (int i = 0; i < Size(); i++)
            {
                if (tmp.val == Max())
                {
                    index = i;
                }
                tmp = tmp.next;
            }

            return index;
        }

        public int IndMin()
        {
            if (root == null)
                throw new NullReferenceException();

            int index = 0;
            Node tmp = root;
            for (int i = 0; i < Size(); i++)
            {
                if (tmp.val == Min())
                {
                    index = i;
                }
                tmp = tmp.next;
            }

            return index;
        }

        public void Reverse()
        {
            if (root == null)
                return;

            Node tmp = root;
            root = null;
            while (tmp != null)
            {
                AddStart(tmp.val);
                tmp = tmp.next;
            }
        }

        public void HalfReverse()
        {
            for (int i = 1; i <= Size() / 2; i++)
            {
                AddEnd(DelStart());
            }
            if (Size() % 2 != 0)
            {
                AddPos(Size() / 2, DelStart());
            }
        }

        public void Sort()
        {
            for (int i = Size() - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Get(j) > Get(j + 1))
                    {
                        int temp = Get(j);
                        Set(j, Get(j + 1));
                        Set(j + 1, temp);
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder(Size() * 2);
            Node temp = root;
            for (int i = 0; i < Size(); i++)
            {
                str.Append(temp.val + " ");
                temp = temp.next;
            }

            return str.ToString();
        }
    }
}