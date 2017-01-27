using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Core
{
    public class BSTreeLink : ITree, IEnumerable, IEnumerator
    {
        private class Node
        {
            public bool passed;
            public int val;
            public Link left;
            public Link right;

            public Node(int val)
            {
                this.val = val;
                this.left = null;
                this.right = null;
                this.passed = false;
            }
        }

        private class Link
        {
            public Node back;
            public Node next;

            public Link()
            {
                this.back = null;
                this.next = null;
            }
        }

        private Node root;
        private int index = -1;

        public BSTreeLink()
        {
            this.root = null;
        }

        public object Current
        {
            get
            {
                return this[index];
            }
        }

        public void Init(int[] ini)
        {
            if (ini.Length == 0 || ini == null)
                ini = new int[0];

            for (int i = 0; i < ini.Length; i++)
            {
                Add(ini[i]);
            }
        }

        public int Size()
        {
            int res = 0;
            return Size(root, ref res);
        }

        private int Size(Node p, ref int res)
        {
            if (p == null)
                return 0;

            Size(p.left.next, ref res);
            res++;
            Size(p.right.next, ref res);

            return res;
        }

        public int[] ToArray()
        {
            if (root == null || Size() == 0)
                return new int[0];

            List<int> list = new List<int>();
            list = ToArray(root, list);
            int i = 0;
            int[] arr = new int[Size()];
            foreach (int val in list)
            {
                arr[i] = val;
                i++;
            }

            return arr;
        }

        private List<int> ToArray(Node p, List<int> list)
        {
            if (p == null)
                return list;

            list.Add(p.val);
            list = ToArray(p.left.next, list);
            list = ToArray(p.right.next, list);

            return list;
        }

        override public string ToString()
        {
            int[] arr = ToArray();
            string res = "";
            foreach (int val in arr)
            {
                res += val + " ";
            }

            return res;
        }

        public void Add(int val)
        {
            if (root == null)
            {
                root = new Node(val);
                root.left = new Link();
                root.right = new Link();
                return;
            }
            Add(root, val);
        }

        private void Add(Node p, int val)
        {
            if (val < p.val)
            {
                if (p.left.next == null)
                {
                    p.left.next = new Node(val);
                    p.left.back = p;
                    p.left.next.left = new Link();
                    p.left.next.left.back = p.left.next;
                    p.left.next.right = new Link();
                    p.left.next.right.back = p.left.next;
                }
                else
                {
                    Add(p.left.next, val);
                }
            }
            else
            {
                if (p.right.next == null)
                {
                    p.right.next = new Node(val);
                    p.right.back = p;
                    p.right.next.left = new Link();
                    p.right.next.left.back = p.right.next;
                    p.right.next.right = new Link();
                    p.right.next.right.back = p.right.next;
                }
                else
                {
                    Add(p.right.next, val);
                }
            }
        }

        public int NodeS()
        {
            int res = 0;
            return NodeS(root, ref res);
        }

        private int NodeS(Node p, ref int res)
        {
            if (p == null)
                return 0;

            if (p.left.next != null && p.right.next == null)
            {
                res++;
                NodeS(p.left.next, ref res);
            }

            if (p.right.next != null && p.left.next == null)
            {
                res++;
                NodeS(p.right.next, ref res);
            }

            if (p.left.next != null && p.right.next != null)
            {
                res++;
                NodeS(p.left.next, ref res);
                NodeS(p.right.next, ref res);
            }

            return res;
        }

        public int Leaves()
        {
            int res = 0;
            return Leaves(root, ref res);
        }

        private int Leaves(Node p, ref int res)
        {
            if (p == null)
                return 0;

            if(p.left.next == null && p.right.next == null)
            {
                res++;
            }

            if(p.left.next == null && p.right.next != null)
            {
                Leaves(p.right.next, ref res);
            }

            if(p.right.next == null && p.left.next != null)
            {
                Leaves(p.left.next, ref res);
            }

            if (p.left.next != null && p.right.next != null)
            {
                Leaves(p.left.next, ref res);
                Leaves(p.right.next, ref res);
            }

            return res;
        }

        public int Width()
        {
            int[] ar = new int[Height()];
            Width(root, ar, 0);
            return Max(ar);
        }

        private void Width(Node p, int[] ar, int i)
        {
            if (p == null)
                return;

            Width(p.left.next, ar, i + 1);
            ar[i]++;
            Width(p.right.next, ar, i + 1);
        }

        private int Max(int [] ar)
        {
            if (ar == null || ar.Length == 0)
                return 0;

            int max = ar[0];
            for (int i = 1; i < ar.Length; i++)
            {
                if (max < ar[i])
                {
                    max = ar[i];
                }
            }

            return max;
        }

        public int Height()
        {
            return Height(root);
        }

        private int Height(Node p)
        {
            if (p == null)
                return 0;

            return Math.Max(Height(p.left.next), Height(p.right.next)) + 1;
        }

        public void Reverse()
        {
            Reverse(root);
        }

        private void Reverse(Node p)
        {
            if (p == null)
                return;

            Node tmp = p.left.next;
            p.left.next = p.right.next;
            p.right.next = tmp;
            Reverse(p.left.next);
            Reverse(p.right.next);
        }

        public void Del(int val)
        {
            root = Del(root, val);
            var tmp = root;
        }

        private Node Del(Node p, int val)
        {
            if (p == null)
            {
                return p;
            }
            if (val < p.val)
            {
                p.left.next = Del(p.left.next, val);
            }
            else if (val > p.val)
            {
                p.right.next = Del(p.right.next, val);
            }
            else
            {
                if (p.left.next == null)
                {
                    return p.right.next;
                }
                else if (p.right.next == null)
                {
                    return p.left.next;
                }
                p.val = Min(p.right.next);
                p.right.next = Del(p.right.next, p.val);
            }
            return p;
        }

        private int Min(Node p)
        {
            int minv = p.val;
            while (p.left.next != null)
            {
                minv = p.left.next.val;
                p = p.left.next;
            }
            return minv;
        }

        public void Print()
        {
            Print(root);
        }

        private void Print(Node p)
        {
            if (p == null)
                return;

            Console.Write(p.val + " ");
            Print(p.left.next);
            Print(p.right.next);
        }

        private int this[int index]
        {
            get
            {
                return ToArray()[index];
            }
        }

        private int NodeToEnumerator(Node p, int index)
        {
            if (p == null)
            {
                throw new NullReferenceException();
            }
            if (index == 0)
            {
                return p.val;
            }

            int result = 0;
            int localIndex = 0;
            Node tmp = p;

            while (true)
            {
                if (localIndex == index)
                {
                    result = tmp.val;
                    break;
                }
                tmp.passed = true;

                if (tmp.left.next == null && tmp.right.next == null)
                {
                    tmp = tmp.left.back;
                    continue;
                }
                if (tmp.left.next != null)
                {
                    if (tmp.left.next.passed != true)
                    {
                        localIndex++;
                        tmp = tmp.left.next;
                        continue;
                    }
                    if (tmp.right.next != null)
                    {
                        if (tmp.right.next.passed == true)
                        {
                            tmp = tmp.left.back;
                            continue;
                        }
                    }
                }
                if (tmp.right.next != null)
                {
                    if (tmp.right.next.passed != true)
                    {
                        localIndex++;
                        tmp = tmp.right.next;
                        continue;
                    }
                    if (tmp.left.next != null)
                    {
                        if (tmp.left.next.passed == true)
                        {
                            tmp = tmp.left.back;
                            continue;
                        }
                    }
                }

            }

            SetNodesToDefault(p);
            return result;
        }

        private void SetNodesToDefault(Node node)
        {
            if (node == null)
            {
                return;
            }

            node.passed = false;
            SetNodesToDefault(node.left.next);
            SetNodesToDefault(node.right.next);
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (index >= Size() - 1)
            {
                Reset();
                return false;
            }

            index++;
            return true;
        }

        public void Reset()
        {
            this.index = -1;
        }
    }
}