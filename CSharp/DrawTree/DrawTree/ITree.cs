using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTree
{
    public interface ITree
    {
        void Init(int[] ini);
        void Add(int val);
        int Size();
        int[] ToArray();
        int Nodes();
        int Leaves();
        int Width();
        int Height();
        void Reverse();
        void Del(int val);

    }
}
