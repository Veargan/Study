using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace CS.Core
{
    public class Calculate
    {
        public const int Three = 3;

        public int FindMaxExpression(int a, int b, int c)
        {
            int res = 0;

            res = Max(a*b*c, a + b + c) + Three;

            return res;
        }
    }
}