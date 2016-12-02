using System;
using System.Text;

namespace List.Core
{
    public class LList2 : IList
    {
        private class Node
        {
            public int val;
            public Node next;
            public Node prev;

            public Node(int val)
            {
                this.val = val;
                this.next = null;
                this.prev = null;
            }
        }

        private Node start = null;
        private Node end = null;
        private int size = 0;

        public void Init(int[] ar)
        {
            Clear();
            if (ar == null || ar.Length == 0)
                ar = new int[0];

            for (int i = 0; i < ar.Length; i++)
            {
                AddEnd(ar[i]);
            }
        }

        public void Clear()
        {
            start = null;
            end = null;
        }

        public int[] ToArray()
        {
            int[] res = new int[Size()];
            int i = 0;
            Node node = start;
            while (node != null)
            {
                res[i++] = node.val;
                node = node.next;
            }

            return res;
        }

        public int Size()
        {
            int res = 0;

            Node node = start;
            while (node != null)
            {
                node = node.next;
                res++;
            }

            return res;
        }

        public void Set(int pos, int val)
        {
            if (pos >= Size() || pos < 0)
                throw new IndexOutOfRangeException();

            Node node = start;
            for (int i = 1; i <= pos; i++)
            {
                node = node.next;
            }
            node.val = val;
        }

        public int Get(int pos)
        {
            if (pos >= Size() || pos < 0)
                throw new IndexOutOfRangeException();

            int res = 0;
            Node node = start;
            for (int i = 1; i <= pos; i++)
            {
                node = node.next;
            }
            res = node.val;

            return res;
        }

        public void AddStart(int val)
        {
            if (start == null)
            {
                start = new Node(val);
                return;
            }
            Node node = new Node(val);
            node.next = start;
            node.prev = node;
            start = node;
        }

        public void AddEnd(int val)
        {
            if (start == null)
            {
                AddStart(val);
                return;
            }
            Node node = start;
            while (node.next != null)
            {
                node = node.next;
            }
            Node tmp = new Node(val);
            node.next = tmp;
            tmp.prev = node;
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
            Node node = start;
            for (int i = 1; i < pos; i++)
            {
                node = node.next;
            }
            Node tmp = new Node(val);
            tmp.next = node.next;
            tmp.prev = node;
            node.next = tmp;
        }

        public int DelStart()
        {
            if (start == null)
                throw new NullReferenceException();

            int res = start.val;
            start = start.next;

            return res;
        }

        public int DelEnd()
        {

            if (start == null)
                throw new NullReferenceException();
            int res = 0;
            if (Size() == 1)
            {
                Clear();
                return res;
            }

            Node node = start;
            int i = 0;
            while (i != Size() - 2)
            {
                node = node.next;
                i++;
            }
            res = node.next.val;
            node.next = null;

            return res;
        }

        public int DelPos(int pos)
        {
            if (start == null || pos < 0 || pos >= Size())
                throw new NullReferenceException();

            int res = 0;
            if (pos == 0)
            {
                res = DelStart();
                return res;
            }

            Node node = start;
            int i = 0;
            while (i + 1 != pos)
            {
                node = node.next;
                i++;
            }
            res = node.next.val;
            if (node.next.next != null)
            {
                node.next = node.next.next;
                node.next.prev = node;
            }
            else
            {
                node.next = null;
            }

            return res;
        }

        public int Max()
        {
            if (start == null)
                throw new NullReferenceException();

            int max = 0;
            Node node = start;
            max = node.val;
            for (int i = 1; i < Size(); i++)
            {
                if (max < node.next.val)
                {
                    max = node.next.val;
                }
                node = node.next;
            }

            return max;
        }

        public int Min()
        {
            if (start == null)
                throw new NullReferenceException();

            int min = 0;
            Node node = start;
            min = node.val;
            for (int i = 1; i < Size(); i++)
            {
                if (min > node.next.val)
                {
                    min = node.next.val;
                }
                node = node.next;
            }

            return min;
        }

        public int IndMax()
        {
            if (start == null)
                throw new NullReferenceException();

            int index = 0;
            Node node = start;
            int min = node.val;
            for (int i = 0; i < Size(); i++)
            {
                if (node.val == Max())
                {
                    index = i;
                }
                node = node.next;
            }

            return index;
        }

        public int IndMin()
        {
            if (start == null)
                throw new NullReferenceException();

            int index = 0;
            Node node = start;
            for (int i = 0; i < Size(); i++)
            {
                if (node.val == Min())
                {
                    index = i;
                }
                node = node.next;
            }

            return index;
        }

        public void Reverse()
        {
            if (start == null)
                return;

            Node node = start;
            start = null;
            while (node != null)
            {
                AddStart(node.val);
                node = node.next;
            }
        }

        public void HalfReverse()
        {
            if (start == null || start.next == null)
                return;

            Node node;
            Node tmp = start;
            int i = 0;
            int size = Size();
            while (i != ((size / 2) - 1))
            {
                i++;
                tmp = tmp.next;
            }
            node = tmp;
            tmp = tmp.next;
            node.next = null;
            tmp.prev = null;
            end = node;
            if (size % 2 > 0)
            {
                node = tmp;
                tmp = tmp.next;
                node.next = start;
                start.prev = node;
                start = node;
            }
            node = tmp;
            node.prev = null;
            while (tmp.next != null)
            {
                tmp = tmp.next;
            }
            tmp.next = start;
            start.prev = tmp;
            start = node;
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

        override public string ToString()
        {
            StringBuilder str = new StringBuilder(Size() * 2);
            Node node = start;
            for (int i = 0; i < Size(); i++)
            {
                str.Append(node.val + " ");
                node = node.next;
            }

            return str.ToString();
        }
    }
}
