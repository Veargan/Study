using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class AvlTree : ITrees
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public int height;
            public Node(int val)
            {
                this.val = val;
            }
        }

        public Node root = null;

        int BsHeight(Node p)
        {
            int t;
            if (p == null)
            {
                return 0;
            }
            else
            {
                t = p.height;
                return t;
            }
        }


        public void Add(int val)
        {
            if (root == null)
            {
                root = new Node(val);
                root.height = 0;
                return;
            }
            AddNode(root, val);
        }

        private Node AddNode(Node p, int val)
        {
            if (p == null)
            {
                Node q = new Node(val);
                q.height = 1;
                return q;
            }
            if (val < p.val)
                p.left = AddNode(p.left, val);
            else
                p.right = AddNode(p.right, val);
            return Balance(p);
        }

        public void Del(int val)
        {
            DelNode(root, val);
        }

        private Node DelNode(Node p, int val)
        {
            if (p == null) return null;
            if (val < p.val)
                p.left = DelNode(p.left, val);
            else if (val > p.val)
                p.right = DelNode(p.right, val);
            else
            {
                Node l = p.left;
                Node r = p.right;

                if (r == null)
                {
                    if (p == root)
                        root = l;
                    return l;
                }

                Node min = FindMin(r);
                min.right = RemoveMin(r);
                min.left = l;
                if (p == root)
                    root = min;
                return Balance(min);

            }
            return Balance(p);
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

        public int Nodes()
        {
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

            ArrayNode(p.left, arr, ref ind);
            arr[ind] = p.val;
            ind++;
            ArrayNode(p.right, arr, ref ind);
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
            res += ToStringNode(p.left);
            res += p.val + ", ";
            res += ToStringNode(p.right);
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

        public bool Equals(AvlTree obj)
        {
            bool flag = false;

            if (this.root.val != obj.root.val)
                flag = false;
            flag = EqualsNode(root.left, obj.root.left);
            flag = EqualsNode(root.left, obj.root.left);
            return flag;
        }

        private bool EqualsNode(Node r, Node obj)
        {
            bool flag = false;

            if (r == null && obj == null)
                return true;
            if (r != null && obj != null)
            {
                if (r.val != obj.val)
                {
                    flag = false;
                    return flag;
                }
            }

            flag = EqualsNode(r.left, obj.left);
            flag = EqualsNode(r.right, obj.right);

            return flag;
        }                  

        void FixHeigth(Node p)
        {
            if (p == null)
            {
                return;
            }
            if (p.right == null)
            {
                if (p.left == null)
                {
                    p.height = 1;
                }
                else
                {
                    p.height = (byte)(p.left.height + 1);
                }
            }
            else if (p.left == null)
            {
                p.height = (byte)(p.right.height + 1);
            }
            else
            {
                p.height = (byte)(Math.Max(p.left.height, p.right.height) + 1);
            }
        }

        Node RotateRight(Node p)
        {
            Node q = p.left;
            p.left = q.right;
            q.right = p;
            FixHeigth(p);
            FixHeigth(q);
            return q;
        }

        Node RotateLeft(Node p)
        {
            Node q = p.right;
            p.right = q.left;
            q.left = p;         
            FixHeigth(p);
            FixHeigth(q);
            return q;
        }

        Node Balance(Node p)
        {
            FixHeigth(p);
            if ((BsHeight(p.right) - BsHeight(p.left)) == 2)
            {
                if ((BsHeight(p.right.right) - BsHeight(p.right.left)) < 0)
                    p.right = RotateRight(p.right);           
                if (p.val == root.val)
                {
                    root = RotateLeft(p);
                }
                else
                {
                    p = RotateLeft(p);
                }
            }
            if ((BsHeight(p.right) - BsHeight(p.left)) == -2)
            {
                if ((BsHeight(p.left.right) - BsHeight(p.left.left)) > 0)
                    p.left = RotateLeft(p.left);
                if (p.val == root.val)
                {
                    root = RotateRight(p);
                }
                else
                {
                    p = RotateRight(p);
                }
            }
            return p;
        }

        private Node RemoveMin(Node p)
        {
            if (p.left == null)
                return p.right;
            p.left = RemoveMin(p.left);
            return Balance(p);
        }

        Node FindMin(Node p)
        {
            if (p.left == null)
                return p;
            else
            {
                p.left = FindMin(p.left);
                return Balance(p);
            }
        }     
    }
}
