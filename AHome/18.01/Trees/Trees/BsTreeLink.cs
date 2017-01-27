using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Trees
{
    public class BsTreeLink : ITrees, IEnumerable, IEnumerator
    {
        class Link
        {
            public Node next;
            public Node prev;
            public Link()
            {
                next = null;
                prev = null;
            }
        }

        class Node
        {
            public int val;
            public Link left;
            public Link right;
            public Link prev;
            public Node(int val)
            {
                this.val = val;
            }
        }

        Node root = null;
        int index = -1;

        public object Current
        {
            get
            {
                int res = 0;
                int inIndex = 0;
                NodeToEnumerator(root, ref res, ref inIndex, index);
                return res;
            }
        }

        private void NodeToEnumerator(Node node, ref int res, ref int index, int comp)
        {
            if (node == null)
            {
                return;
            }

            NodeToEnumerator(node.left.next, ref res, ref index, comp);
            if (index == comp)
            {
                index++;
                res = node.val;
                return;
            }
            index++;
            NodeToEnumerator(node.right.next, ref res, ref index, comp);
        }

        public void Init(int[] ini)
        {
            for (int i = 0; i < ini.Length; i++)
            {
                Add(ini[i]);
            }
        }

        public void Print()
        {
            PrintNode(root);
        }

        private void PrintNode(Node p)
        {
            if (p == null)
                return;

            PrintNode(p.left.next);
            Console.Write(p.val + ", ");
            PrintNode(p.right.next);
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
            AddNode(root, val);
        }

        private void AddNode(Node p, int val)
        {
            if (val < p.val)
            {
                if (p.left.next == null)
                {
                    p.left.next = new Node(val);
                    p.left.next.prev = p.left;
                    p.left.prev = p;
                    p.left.next.left = new Link();
                    p.left.next.right= new Link();

                }
                else
                    AddNode(p.left.next, val);
            }
            else
            {
                if (p.right.next == null)
                {
                    p.right.next = new Node(val);
                    p.right.next.prev = p.left;
                    p.right.prev = p;
                    p.right.next.left = new Link();
                    p.right.next.right = new Link();
                }
                else
                    AddNode(p.right.next, val);
            }
        }


        public int Size()
        {
            return SizeNode(root);
        }

        private int SizeNode(Node p)
        {

            if (p == null)
                return 0;
            int res = 0;
            res += SizeNode(p.left.next);
            res++;
            res += SizeNode(p.right.next);
            return res;
        }

        override public string ToString()
        {
            return ToStringNode(root);
        }

        private string ToStringNode(Node p)
        {
            if (p == null)
                return "";
            string res = "";
            res += ToStringNode(p.left.next);
            res += p.val + ", ";
            res += ToStringNode(p.right.next);
            return res;
        }

        public int[] ToArray()
        {
            int[] res = new int[Size()];
            int ind = 0;
            ArrayNode(root, res, ref ind);
            return res;
        }

        private void ArrayNode(Node p, int[] arr, ref int ind)
        {
            if (p == null)
                return;

            ArrayNode(p.left.next, arr, ref ind);
            arr[ind] = p.val;
            ind++;
            ArrayNode(p.right.next, arr, ref ind);
        }

        public int Nodes()
        {
            return NodesNode(root);
        }

        private int NodesNode(Node p)
        {
            if (p == null)
                return 0;
            int res = 0;
            if (p.left.next != null || p.right.next != null)
            {
                res++;
            }
            res += NodesNode(p.left.next);
            res += NodesNode(p.right.next);
            return res;
        }


        public int Leaves()
        {
            return LeavesNode(root);
        }

        private int LeavesNode(Node p)
        {
            if (p == null)
                return 0;
            int res = 0;
            if (p.left.next == null && p.right.next == null)
            {
                res++;
            }
            res += LeavesNode(p.left.next);
            res += LeavesNode(p.right.next);
            return res;
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

            WidthNode(p.left.next, dat, i + 1);
            dat[i]++;
            WidthNode(p.right.next, dat, i + 1);
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
            return HeightNode(root);
        }

        private int HeightNode(Node p)
        {
            if (p == null)
                return 0;
            int l = HeightNode(p.left.next) + 1;
            int r = HeightNode(p.right.next) + 1;
            if (l > r)
            {
                return l;
            }
            else
            {
                return r;
            }
        }
        public void Reverse()
        {
            ReverseNode(root);
        }
        private void ReverseNode(Node p)
        {
            if (p == null)
                return;
            Node tmp = p.right.next;
            p.right.next = p.left.next;
            p.left.next = tmp;
            ReverseNode(p.left.next);
            ReverseNode(p.right.next);
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
                        move = move.left.next;
                    }
                    else
                    {
                        move = move.right.next;
                    }
                }

                if (move.left.next != null && move.right.next != null)
                {

                    temp = move.right.next;

                    while (temp.left.next != null)
                    {
                        back = temp;
                        temp = temp.left.next;
                    }

                    move.val = temp.val;
                    move = temp;
                }

                if (move.left == null && move.right == null)
                {
                    if (back.right.next == move)
                    {
                        back.right.next = null;
                    }
                    else
                    {
                        back.left.next = null;
                    }

                    return;
                }

                if (move.left.next == null && move.right.next != null)
                {
                    if (back.left.next == move)
                    {
                        back.left.next = move.right.next;
                    }
                    else
                    {
                        back.right.next = move.right.next;
                    }


                    return;
                }

                if (move.left.next != null && move.right.next == null)
                {
                    if (back.left.next == move)
                    {
                        back.left.next = move.left.next;
                    }
                    else
                    {
                        back.right.next = move.left.next;
                    }


                    return;
                }
            }
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
            index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}
