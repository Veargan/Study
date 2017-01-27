using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree.Core;

namespace Tree.Core
{
    [Flags]
    public enum Color
    {
        black = 0,
        red = 1
    }
    public class RBTree : ITree
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Color color = Color.red;
            public Node(int val)
            {
                this.val = val;
            }
        }
        public Node root = null;
        #region help methods
        private bool isRed(Node x)
        {
            if (x == null) return false;
            return x.color == Color.red;
        }
        public bool isEmpty()
        {
            return root == null;
        }
        #endregion

        #region rotate and balance
        private Node rotateRight(Node h)
        {
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            x.color = x.right.color;
            x.right.color = Color.red;
            return x;
        }

        private Node rotateLeft(Node h)
        {
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            x.color = x.left.color;
            x.left.color = Color.red;
            return x;
        }
        private void flipColors(Node h)
        {
            h.color = ~h.color;
            h.left.color = ~h.left.color;
            h.right.color = ~h.right.color;
        }
        private Node moveRedLeft(Node h)
        {
            flipColors(h);
            if (isRed(h.right.left))
            {
                h.right = rotateRight(h.right);
                h = rotateLeft(h);
                flipColors(h);
            }
            return h;
        }
        private Node moveRedRight(Node h)
        {
            flipColors(h);
            if (isRed(h.left.left))
            {
                h = rotateRight(h);
                flipColors(h);
            }
            return h;
        }
        private Node balance(Node h)
        {
            if (isRed(h.right)) h = rotateLeft(h);
            if (isRed(h.left) && isRed(h.left.left)) h = rotateRight(h);
            if (isRed(h.left) && isRed(h.right)) flipColors(h);
            return h;
        }
        #endregion

        public void Init(int[] ini)
        {
            if (ini == null)
                return;
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
            PrintNode(p.left);

            Console.Write(p.val + ", ");
            PrintNode(p.right);
        }

        public void Add(int val)
        {
            root = AddNode(root, val);
            root.color = Color.black;
        }

        private Node AddNode(Node h, int val)
        {
            if (h == null) return new Node(val);

            if (val < h.val) h.left = AddNode(h.left, val);
            else h.right = AddNode(h.right, val);


            return balance(h);
        }
        public void Reverse()
        {
            ReverseNode(root);
        }
        void ReverseNode(Node r)
        {
            if (r == null)
                return;

            Node tmp = r.right;
            r.right = r.left;
            r.left = tmp;
            ReverseNode(r.left);
            ReverseNode(r.right);
        }
        public int Leaves()
        {
            return LeavesNode(root);
        }
        private int LeavesNode(Node p)
        {
            if (p == null)
                return 0;
            if (p.left == null && p.right == null)
                return 1;
            else
                return LeavesNode(p.left) + LeavesNode(p.right);
        }
        public int NodeS()
        {
            int res = 0;
            NodeNodes(root, ref res);
            return res;
        }
        void NodeNodes(Node p, ref int res)
        {
            if (p == null)
                return;
            if (p.left != null || p.right != null)
                res++;
            NodeNodes(p.left, ref res);
            NodeNodes(p.right, ref res);
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
        public int Size()
        {
            int i = 0;
            SizeNode(root, ref i);
            return i;
        }

        private void SizeNode(Node p, ref int i)
        {
            if (p == null)
                return;
            i++;
            SizeNode(p.left, ref i);
            SizeNode(p.right, ref i);
        }
        public int[] ToArray()
        {
            int[] res = new int[Size()];
            int i = 0;
            ArrayNode(root, ref res, ref i);
            return res;
        }
        void ArrayNode(Node p, ref int[] arr, ref int ind)
        {
            if (p == null)
                return;

            ArrayNode(p.left, ref arr, ref ind);
            arr[ind] = p.val;
            ind++;
            ArrayNode(p.right, ref arr, ref ind);
        }
        public override string ToString()
        {
            string res = "";
            NodeToString(root, ref res);
            return res;
        }
        void NodeToString(Node p, ref string res)
        {
            if (p == null)
                return;
            NodeToString(p.left, ref res);
            res += p.val + " ";
            NodeToString(p.right, ref res);
        }

        public void Del(int val)
        {
            if (root == null)
                throw new NullReferenceException();
            root = delete(root, val);
            if (!isEmpty()) root.color = Color.black;
        }
        private Node delete(Node h, int val)
        {
            if (val < h.val)
            {
                if (!isRed(h.left) && !isRed(h.left.left))
                {
                    // root.color = Color.red;
                    h = moveRedLeft(h);
                }

                h.left = delete(h.left, val);
            }
            else
            {
                if (isRed(h.left))
                    h = rotateRight(h);
                if (val == h.val && (h.right == null))
                    return null;
                if (!isRed(h.right) && !isRed(h.right.left))
                    h = moveRedRight(h);
                if (val == h.val)
                {
                    Node x = min(h.right);
                    h.val = x.val;
                    h.right = deleteMin(h.right);
                }
                else h.right = delete(h.right, val);
            }
            return balance(h);
        }

        private Node deleteMin(Node h)
        {
            if (h.left == null)
                return null;

            if (!isRed(h.left) && !isRed(h.left.left))
                h = moveRedLeft(h);

            h.left = deleteMin(h.left);
            return balance(h);
        }

        private Node min(Node h)
        {
            if (h.left == null) return h;
            else return min(h.left);
        }
    }
}
