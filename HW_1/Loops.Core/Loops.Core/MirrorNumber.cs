using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops.Core
{
    public class MirrorNumber
    {
        public int FindMirrorNumber(int n)
        {
            int res = 0;

            while (n != 0)
            {
                res = res*10 + n%10;
                n /= 10;
            }
            res = Math.Abs(res);

            return res;
        }
    }
}