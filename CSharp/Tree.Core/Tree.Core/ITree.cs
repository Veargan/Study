using System.Collections;

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
        void Del(int val);
        void Print();
        IEnumerator GetEnumerator();
    }
}
