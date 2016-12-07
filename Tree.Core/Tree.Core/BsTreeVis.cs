using System;

namespace Tree.Core
{
    public class BsTreeVis : ITree
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

            Visit(p.left, v);
            v.Action(p);
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
                str += p.val + ", ";
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
            throw new NotImplementedException();
        }

        public void DelNode(int val)
        {
            throw new NotImplementedException();
        }

        public int Width()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
