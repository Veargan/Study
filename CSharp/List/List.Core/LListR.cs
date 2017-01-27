using System;

namespace List.Core
{
    public class LListR : IList
    {
        private class Node
        {
            public int val;
            public Node next;
            public Node prev;
            public Node(int val)
            {
                this.val = val;
            }
        }

        private Node root = null;

        public void Init(int[] ini)
        {
            Clear();
            if (ini == null || ini.Length == 0)
            {
                return;
            }

            for (int i = ini.Length - 1; i >= 0; i--)
            {
                AddStart(ini[i]);
            }
        }

        public void Clear()
        {
            root = null;
        }

        public int[] ToArray()
        {
            Node p = root;
            int[] res = new int[Size()];
            int i = 0;
            if (root != null)
            {
                do
                {
                    res[i++] = p.val;
                    p = p.next;
                }
                while (p != root);
            }

            return res;
        }

        public int Size()
        {
            int size = 0;
            Node p = root;
            if (root != null)
            {
                do
                {
                    size++;
                    p = p.next;
                }
                while (p != root);
            }

            return size;
        }

        public void Set(int pos, int n)
        {
            if (pos >= Size() || pos < 0)
                throw new IndexOutOfRangeException();

            Node node = root;
            for (int i = 1; i <= pos; i++)
            {
                node = node.next;
            }
            node.val = n;
        }

        public int Get(int pos)
        {
            if (pos >= Size() || pos < 0)
                throw new IndexOutOfRangeException();

            int res = 0;
            Node node = root;
            for (int i = 1; i <= pos; i++)
            {
                node = node.next;
            }
            res = node.val;

            return res;
        }

        public void AddStart(int val)
        {
            if (root == null)
            {
                root = new Node(val);
                root.next = root;
                root.prev = root;
                return;
            }

            if (root.prev == root)
            {
                Node p = new Node(val);
                p.prev = root.prev;
                p.next = root;
                root.prev = p;
                root.next = p;
                root = p;
            }
            else
            {
                Node p = new Node(val);
                p.prev = root.prev;
                p.next = root;
                root.prev.next = p;
                root.prev = p;
                root = p;
            }
        }

        public void AddEnd(int n)
        {
            if (root == null)
            {
                root = new Node(n);

                root.next = root;
                root.prev = root;
                return;
            }

            if (root.next == root)
            {
                Node p = new Node(n);
                p.prev = root.prev;
                p.next = root;
                root.prev = p;
                root.next = p;
            }
            else
            {
                Node p = new Node(n);
                p.prev = root.prev;
                p.next = root;

                root.prev.next = p;
                root.prev = p;
            }
        }

        public void AddPos(int pos, int n)
        {
            if (pos < 0 || pos > Size())
                throw new IndexOutOfRangeException();

            if (pos == 0)
            {
                AddStart(n);
                return;
            }
            if (pos == Size())
            {
                AddEnd(n);
                return;
            }

            Node tmp = root;
            Node p = new Node(n);
            int i = 1;
            while (i != pos)
            {
                tmp = tmp.next;
                i++;
            }

            p.next = tmp.next;
            p.prev = tmp;
            tmp.next.prev = p;
            tmp.next = p;
        }

        public int DelStart()
        {
            if (root == null)
                throw new NullReferenceException();

            int res = 0;
            if (root.next == root)
            {
                res = root.val;
                root = null;
                return res;
            }

            res = root.val;
            root.prev.next = root.next;
            root.next.prev = root.prev;
            root = root.next;

            return res;
        }

        public int DelEnd()
        {
            if (root == null)
                throw new NullReferenceException();

            int res = 0;
            if (root.next == root)
            {
                res = root.val;
                root = null;
                return res;
            }

            res = root.prev.val;
            root.prev.prev.next = root;
            root.prev = root.prev.prev;
            return res;
        }

        public int DelPos(int pos)
        {
            if (root == null)
                throw new NullReferenceException();
            int res = 0;
            if (pos == 0)
            {
                res = DelStart();
                return res;
            }

            if (pos == Size() - 1)
            {
                res = DelEnd();
                return res;
            }

            Node tmp = root;
            int i = 1;
            while (i != pos)
            {
                tmp = tmp.next;
                i++;
            }
            res = tmp.next.val;
            tmp.next = tmp.next.next;
            tmp.next.prev = tmp;

            return res;
        }

        public int Max()
        {
            if (root == null)
            {
                throw new NullReferenceException();
            }
            Node p = root;
            int max = root.val;

            do
            {
                if (root.val > max)
                {
                    max = root.val;
                }
                root = root.next;
            }
            while (root != p);
            root = p;
            return max;
        }

        public int Min()
        {
            if (root == null)
            {
                throw new NullReferenceException();
            }
            Node p = root;
            int min = root.val;

            do
            {
                if (root.val < min)
                {
                    min = root.val;
                }
                root = root.next;
            }
            while (root != p);
            root = p;
            return min;
        }

        public int IndMax()
        {
            if (root == null)
            {
                throw new NullReferenceException();
            }
            Node p = root;
            int max = root.val;
            int index = 0;
            int i = 0;
            do
            {
                if (root.val > max)
                {
                    max = root.val;
                    index = i;
                }
                i++;
                root = root.next;
            }
            while (root != p);
            root = p;
            return index;
        }

        public int IndMin()
        {
            if (root == null)
            {
                throw new NullReferenceException();
            }
            Node p = root;
            int min = root.val;
            int index = 0;
            int i = 0;
            do
            {
                if (root.val < min)
                {
                    min = root.val;
                    index = i;
                }
                i++;
                root = root.next;
            }
            while (root != p);
            root = p;
            return index;
        }

        public void Reverse()
        {
            //if (root == null)
            //{
            //    throw new NullReferenceException();
            //}
            //if (root.next == root)
            //{
            //    return;
            //}
            //Node p = null;
            //do
            //{
            //    Node tmp = root.next;
            //    root.next = p;
            //    p = root;
            //    root = tmp;
            //}
            //while (p != root);
            //root = p;
        }

        public void HalfReverse()
        {
            //if (root == null)
            //{
            //    throw new NullReferenceException();
            //}
            //if (root.next == root)
            //{
            //    return;
            //}
            //int mSize = Size();
            //Node tmp = root;
            //Node mid = null;
            //int i = 0;
            //do
            //{
            //    i++;
            //    if (i == mSize / 2)
            //    {
            //        mid = tmp;
            //    }
            //    tmp = tmp.next;
            //}
            //while (tmp.next != root);

            //if (mSize % 2 != 0)
            //{
            //    Node x = mid.next;
            //    mid.next = mid.next.next;
            //    x.next = root;
            //    root = x;
            //}
            //tmp.next = root;
            //root = mid.next;
            //mid.next = null;
        }
        public void Sort()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string str = "";
            if (root != null)
            {
                Node p = root;
                do
                {
                    str += p.val;
                    str += " ";
                    p = p.next;
                }
                while (p != root);
            }

            return str;
        }
    }
}
