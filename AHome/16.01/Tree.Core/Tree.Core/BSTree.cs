using System;
using System.Collections;
using System.Collections.Generic;

namespace Tree.Core
{
    public class BSTree : ITree, IEnumerator, IEnumerable
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;

            public Node(int val)
            {
                this.val = val;
            }
        }

        private Node root = null;
        private int index = -1;

        public object Current
        {
            get
            {
                int result = 0;
                int inIndex = 0;

                NodeToEnumerator(root, ref result, ref inIndex, index);

                return result;
            }
        }

        private void NodeToEnumerator(Node node, ref int result, ref int index, int compareTo)
        {
            if (node == null)
                return;

            NodeToEnumerator(node.left, ref result, ref index, compareTo);

            if (index == compareTo)
            {
                index++;
                result = node.val;
                return;
            }

            index++;
            NodeToEnumerator(node.right, ref result, ref index, compareTo);
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
            return Size(root);
        }

        private int Size(Node p)
        {
            int res = 0;

            if (p == null)
                return res;

            res += Size(p.left);
            res++;
            res += Size(p.right);

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
            list = ToArray(p.left, list);
            list = ToArray(p.right, list);

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
                return;
            }

            AddNode(root, val);
        }

        private void AddNode(Node p, int val)
        {
            if (val < p.val)
            {
                if (p.left == null)
                {
                    p.left = new Node(val);
                    return;
                }
                AddNode(p.left, val);
            }
            else
            {
                if (p.right == null)
                {
                    p.right = new Node(val);
                    return;
                }
                AddNode(p.right, val);
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

            NodeS(p.left, ref res);
            if (p.left != null || p.right != null)
                res++;
            NodeS(p.right, ref res);

            return res;
        }

        public int Leaves()
        {
            return Leaves(root);
        }

        private int Leaves(Node p)
        {
            if (p == null)
                return 0;

            int res = 0;
            res += Leaves(p.left);
            if (p.left == null && p.right == null)
                res++;
            res += Leaves(p.right);
        
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

            Width(p.left, ar, i + 1);
            ar[i]++;
            Width(p.right, ar, i + 1);
        }

        private int Max(int[] ar)
        {
            if (ar.Length == 0)
                return 0;

            int max = ar[0];
            for (int i = 1; i < ar.Length; i++)
            {
                if (ar[i] > max)
                    max = ar[i];
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

            return Math.Max(Height(p.left), Height(p.right)) + 1;
        }

        public void Reverse()
        {
            Reverse(root);
        }
        private void Reverse(Node p)
        {
            if (p == null)
                return;

            Node tmp = p.right;
            p.right = p.left;
            p.left = tmp;
            Reverse(p.left);
            Reverse(p.right);
        }

        public void Print()
        {
            PrintNode(root);
        }

        private void PrintNode(Node p)
        {
            if (p == null)
                return;

            PrintNode(p.left);
            PrintNode(p.right);
            Console.Write(p.val + " ");
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
                p.left = Del(p.left, val);
            }
            else if (val > p.val)
            {
                p.right = Del(p.right, val);
            }
            else
            {
                if (p.left == null)
                {
                    return p.right;
                }
                else if (p.right == null)
                {
                    return p.left;
                }
                p.val = Min(p.right);
                p.right = Del(p.right, p.val);
            }
            return p;
        }

        private int Min(Node p)
        {
            int minv = p.val;
            while (p.left != null)
            {
                minv = p.left.val;
                p = p.left;
            }
            return minv;
        }

        public bool MoveNext()
        {
            if (index == Size() - 1)
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

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}