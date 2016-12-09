using System;
using System.Collections;

namespace Tree.Core
{
    public class BSTreeVis : ITree, IEnumerator, IEnumerable
    {
        private class Node
        {
            public int val;
            public Node left;
            public Node right;

            public Node(int val)
            {
                this.val = val;
            }
        }

        Node root = null;
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
            for (int i = 0; i < ini.Length; i++)
            {
                Add(ini[i]);
            }
        }

        public void Add(int val)
        {
            AddNode(ref root, val);
        }

        private void AddNode(ref Node p, int val)
        {
            if (p == null)
            {
                p = new Node(val);
                return;
            }

            if (val < p.val)
            {
                AddNode(ref p.left, val);
            }
            else
            {
                AddNode(ref p.right, val);
            }
        }

        private interface Visitor
        {
            void Action(Node p);
        }

        private void Visit(Node p, Visitor v)
        {
            if (p == null)
                return;

            v.Action(p);
            Visit(p.left, v);
            Visit(p.right, v);
        }

        private class VSize : Visitor
        {
            public int size = 0;
            public void Action(Node p)
            {
                size++;
            }
        }
        private class VNodes : Visitor
        {
            public int size = 0;
            public void Action(Node p)
            {
                if (p.left != null || p.right != null)
                    size++;
            }
        }
        private class VLeaves : Visitor
        {
            public int size = 0;
            public void Action(Node p)
            {
                if (p.left == null && p.right == null)
                    size++;
            }
        }
        private class VString : Visitor
        {
            public String str = "";
            public void Action(Node p)
            {
                str += p.val + " ";
            }
        }
        private class VArray : Visitor
        {
            public int[] dat = null;
            int i = 0;
            public VArray(int size)
            {
                dat = new int[size];
            }
            public void Action(Node p)
            {
                dat[i++] = p.val;
            }
        }
        public int Size()
        {
            VSize vv = new VSize();
            Visit(root, vv);
            return vv.size;
        }

        public int NodeS()
        {
            VNodes vv = new VNodes();
            Visit(root, vv);
            return vv.size;
        }

        public int Leaves()
        {
            VLeaves vv = new VLeaves();
            Visit(root, vv);
            return vv.size;
        }

        public int Height()
        {
            return HeightNode(root);
        }

        private int HeightNode(Node p)
        {
            if (p == null)
                return 0;

            return 1 + Math.Max(HeightNode(p.left), HeightNode(p.right));
        }

        override public String ToString()
        {
            VString vv = new VString();
            Visit(root, vv);
            return vv.str;
        }

        public int[] ToArray()
        {
            VArray vv = new VArray(Size());
            Visit(root, vv);
            return vv.dat;
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
