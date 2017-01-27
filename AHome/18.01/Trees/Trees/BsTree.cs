using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Trees
{
    public class BsTree : ITrees, IEnumerable, IEnumerator
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

        public Node root = null;
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
        private void NodeToEnumerator(Node node, ref int res, ref int index, int comp)
        {
            if (node == null)
            {
                return;
            }

            NodeToEnumerator(node.left, ref res, ref index, comp);
            if (index == comp)
            {
                index++;
                res = node.val;
                return;
            }
            index++;
            NodeToEnumerator(node.right, ref res, ref index, comp);
        }
            
        public IEnumerator GetEnumerator()
        {
            return this;
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

            PrintNode(p.left);
            Console.Write(p.val + ", ");
            PrintNode(p.right);            
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
            return SizeNode(root);
        }

        static private int SizeNode(Node p)
        {
            
            if (p == null)
                return 0;
            int res = 0;
            res += SizeNode(p.left);
            res++;
            res += SizeNode(p.right);
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
            res += ToStringNode(p.left);
            res += p.val + ", ";
            res += ToStringNode(p.right);
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
            DelNode(root, val, null);
        }

        private Node FindMin(Node p)
        {
            if (p == null)
                return null;
            while (p.left != null)
                p = p.left;
            return p;
        }

        private void DelNode(Node p, int val, Node par)
        {

            if (val < p.val)
            {
                DelNode(p.left, val, p);              
            }
            else if (val > p.val)
            {
                DelNode(p.right, val, p);               
            }
            else if ((p.left == null) && (p.right == null))
            {
                if (p.val < par.val)
                    par.left = null;
                else
                    par.right = null;
            }
            else if (p.left == null)
            {
                if (p.val < par.val)
                    par.left = p.left;
                else
                    par.right = p.right;
            }
            else if (p.right == null)
            {
                if (p.val < par.val)
                    par.left = p.left;
                else
                    par.right = p.right;
            }
            else
            {
                Node m = FindMin(p.right);
                p.val = m.val;
                DelNode(p.right, m.val, p);
            }
            
        }

        public bool Equals(BsTree obj)
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

            flag = EqualsNode(r.left,obj.left);
            flag = EqualsNode(r.right,obj.right);

            return flag;
        }

    }
}
