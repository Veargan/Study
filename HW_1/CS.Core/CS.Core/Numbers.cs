using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core
{
    public class Numbers
    {
        public int SumOnlyPosNumbers(int a, int b, int c)
        {
            int res = 0;

            if (a > 0)
            {
                res += a;
            }
            if (b > 0)
            {
                res += b;
            }
            if (c > 0)
            {
                res += c;
            }

            return res;
        }
    }
}