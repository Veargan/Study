using System;
using System.Collections;
using System.Drawing;

namespace DrawTree
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

    public class BsTree : ITree, IEnumerable, IEnumerator
    {
        public Node root = null;
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

        private void NodeToEnumerator(Node node, ref int result, ref int index, int compareToIndex)
        {
            if (node == null)
            {
                return;
            }

            NodeToEnumerator(node.left, ref result, ref index, compareToIndex);
            if (index == compareToIndex)
            {
                index++;
                result = node.val;
                return;
            }
            index++;
            NodeToEnumerator(node.right, ref result, ref index, compareToIndex);
        }

        public void Init(int[] ini)
        {
            if (ini == null || ini.Length == 0)
            {
                return;
            }

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
            Console.Write(p.val + " ");
            PrintNode(p.right);
        }

        public void Clear()
        {
            root = null;
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

        public int Size()
        {
            if (root == null)
            {
                return 0;
            }
            return SizeNode(root);
        }

        private int SizeNode(Node p)
        {
            if (p == null)
                return 0;
            int res = 0;
            res += SizeNode(p.left);
            res++;
            res += SizeNode(p.right);
            return res;
        }

        public override string ToString()
        {
            return ToStringNode(root);
        }

        private string ToStringNode(Node p)
        {
            if (p == null)
                return "";
            string res = "";
            res += ToStringNode(p.left);
            res += p.val + " ";
            res += ToStringNode(p.right);
            return res;
        }

        public int[] ToArray()
        {
            if (root == null || Size() == 0)
            {
                return new int[] { };
            }
            int[] res = new int[Size()];
            int ind = 0;
            ArrayNode(root, res, ref ind);
            return res;
        }

        private void ArrayNode(Node p, int[] arr, ref int ind)
        {
            if (p == null)
                return;

            ArrayNode(p.left, arr, ref ind);
            arr[ind] = p.val;
            ind++;
            ArrayNode(p.right, arr, ref ind);
        }

        public int Nodes()
        {
            if (root == null || Size() == 0)
            {
                return 0;
            }
            return NodesNode(root);
        }

        private int NodesNode(Node p)
        {
            if (p == null)
                return 0;
            int res = 0;
            if (p.left != null || p.right != null)
            {
                res++;
            }
            res += NodesNode(p.left);
            res += NodesNode(p.right);
            return res;
        }


        public int Leaves()
        {
            if (root == null || Size() == 0)
            {
                return 0;
            }
            return LeavesNode(root);
        }

        private int LeavesNode(Node p)
        {
            if (p == null)
                return 0;
            int res = 0;
            if (p.left == null && p.right == null)
            {
                res++;
            }
            res += LeavesNode(p.left);
            res += LeavesNode(p.right);
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
        public void Reverse()
        {
            if (root == null || Size() == 0)
            {
                return;
            }
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
        public void Del(int val)
        {
            if (root == null || Size() == 0)
            {
                throw new Exception("Invalid tree!");
            }

            DeleteNode(root, val);
        }

        private void DeleteNode(Node p, int val)
        {
            if (root == null || Size() == 0)
            {
                return;
            }
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

        public void Draw(Graphics gr, int Width)
        {
            int level = 1;
            int h = Height();
            int w = Width / ((int)System.Math.Pow(2, h) + 1);
            int x = (int)(Math.Pow(2, h) / 2 + 1) * w;
            int y = w;

            DrawNode(gr, root, x, y, w, h, level);

        }

        private void DrawNode(Graphics gr, Node p, int x, int y, int w, int h, int level)
        {
            if (p == null)
                return;
            
            Brush brush = new SolidBrush(Color.Red);
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            drawBrush.Color = Color.Black;
            gr.FillEllipse(brush, x, y, w, w);
            gr.DrawString(p.val.ToString(), drawFont, drawBrush, x + 7, y + 7);

            DrawLeaf(gr, p.left, x, y, w, -1, h, ref level);
            DrawLeaf(gr, p.right, x, y, w, 1, h, ref level);
        }

        private void DrawLeaf(Graphics gr, Node p, int x, int y, int w, int side, int h, ref int level)
        {
            if (p == null)
                return;

            ++level;
            Pen pen = new Pen(Color.Black, 2);
            int yNew = y + w * 2;
            int xNew = (int)(x + Math.Pow(2, (h - level)) * w * side);
            gr.DrawLine(pen, x + w / 2, y + w / 2, xNew + w / 2, yNew + w / 2);
            DrawNode(gr, p, xNew, yNew, w, h, level);
            --level;
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
