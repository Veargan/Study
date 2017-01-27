using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public interface IList
    {
        void  Init(int[] arr);
        int   Size();
        void  Clear();

        int[] ToArray();

        void  AddStart(int n);
        void  AddEnd(int n);
        void  AddPos(int pos, int n);
        int   DelStart();
        int   DelEnd();
        int   DelPos(int pos);

        void  Set(int pos, int n);
        int   Get(int pos);

        void  Reverse();
        void  HalfReverse();
        int   Min();
        int   Max();
        int   IndMin();         
        int   IndMax();
        void  Sort();

    }
}
