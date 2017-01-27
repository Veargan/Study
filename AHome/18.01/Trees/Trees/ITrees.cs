using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public interface ITrees
    {
        void Add(int val);
        int Size();
        void Init(int[] ini);
        String ToString();
        int[] ToArray();
        int Nodes();
        int Leaves();
        int Width();
        int Height();
        void Reverse();
        void Del(int val);
    }
}
