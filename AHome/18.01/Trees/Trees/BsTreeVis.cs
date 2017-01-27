using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class BsTreeVis : ITrees
    {
        class Node
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
                    p.left = new Node(val);
                else
                    AddNode(p.left, val);
            }
            else
            {
                if (p.right == null)
                    p.right = new Node(val);
                else
                    AddNode(p.right, val);

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
            public int nodes = 0;
            public void Action(Node p)
            {
                if (p.left != null || p.right != null)
                    nodes++;
            }
        }
        private class VLeaves : Visitor
        {
            public int leaves = 0;
            public void Action(Node p)
            {
                if (p.left == null && p.right == null)
                    leaves++;
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

        private class VWidth : Visitor
        {
            public int[] dat = null;
            int i = 0;
            public VWidth(int size)
            {
                dat = new int[size];
            }
            public void Action(Node p)
            {
                dat[++i]++;
                
            }           
        }

        

        public void Del(int val)
        {
            DelNode(root, val);
        }

        private void DelNode(Node p, int val)
        {
            Node move, back, temp;

            if (p == null)
            {
                return;
            }
            else
            {
                move = p;
                back = move;

                while (move.val != val)
                {
                    back = move;

                    if (val < move.val)
                    {
                        move = move.left;
                    }
                    else
                    {
                        move = move.right;
                    }
                }

                if (move.left != null && move.right != null)
                {

                    temp = move.right;

                    while (temp.left != null)
                    {
                        back = temp;
                        temp = temp.left;
                    }

                    move.val = temp.val;
                    move = temp;
                }

                if (move.left == null && move.right == null)
                {
                    if (back.right == move)
                    {
                        back.right = null;
                    }
                    else
                    {
                        back.left = null;
                    }


                    return;
                }

                if (move.left == null && move.right != null)
                {
                    if (back.left == move)
                    {
                        back.left = move.right;
                    }
                    else
                    {
                        back.right = move.right;
                    }


                    return;
                }

                if (move.left != null && move.right == null)
                {
                    if (back.left == move)
                    {
                        back.left = move.left;
                    }
                    else
                    {
                        back.right = move.left;
                    }


                    return;
                }
            }
        }

        public int Height()
        {
            return HeightNode(root);
        }

        private int HeightNode(Node p)
        {
            if (p == null)
                return 0;
            int l = HeightNode(p.left) + 1;
            int r = HeightNode(p.right) + 1;
            if (l > r)
            {
                return l;
            }
            else
            {
                return r;
            }
        }

        public void Init(int[] ini)
        {
            for (int i = 0; i < ini.Length; i++)
            {
                Add(ini[i]);
            }
        }

        public int Leaves()
        {
            VLeaves vv = new VLeaves();
            Visit(root, vv);
            return vv.leaves;
        }

        public int Nodes()
        {
            VNodes vv = new VNodes();
            Visit(root, vv);
            return vv.nodes;
        }

        public void Reverse()
        {
            ReverseNode(root);
        }
        private void ReverseNode(Node p)
        {
            if (p == null)
                return;
            Node tmp = p.right;
            p.right = p.left;
            p.left = tmp;
            ReverseNode(p.left);
            ReverseNode(p.right);
        }

        public int Size()
        {
            VSize vv = new VSize();
            Visit(root, vv);
            return vv.size;
        }

        public int[] ToArray()
        {
            VArray vv = new VArray(Size());
            Visit(root, vv);
            return vv.dat;
        }

        public int Width()
        {
            int[] dat = new int[Height()];
            WidthNode(root, dat, 0);
            return Max(dat);
        }

        private void WidthNode(Node p, int[] dat, int i)
        {
            if (p == null)
                return;

            WidthNode(p.left, dat, i + 1);
            dat[i]++;
            WidthNode(p.right, dat, i + 1);
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

        override public string ToString()
        {
            VString vv = new VString();
            Visit(root, vv);
            return vv.str;
        }
    }
}
