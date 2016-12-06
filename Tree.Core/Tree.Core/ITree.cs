using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Core
{
    public interface ITree
    {
        void Init(int[] ini);
        int Size();
        int[] ToArray();
        string ToString();
        void Add(int val);
        int NodeS();
        int Leaves();
        int Width();
        int Height();
        void Reverse();
        void DelNode(int val);
        void Print();
    }
}
