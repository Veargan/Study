using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Loops.Core
{
    public class NaturalNumber
    {
        public int CalculateRoot(int n)
        {
            int res = 1;

            while (res*res < n) res++;

            return res;
        }

        public int CalculateRootLoop(int n)
        {
            int res = 0;

            if (n >= 1) res = (int) Round(Sqrt(n));
            if ((n == 0) || (n < 0)) throw new ArgumentException("Not a valid value");

            return res;
        }
    }
}