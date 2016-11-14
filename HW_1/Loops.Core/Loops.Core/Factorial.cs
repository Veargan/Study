using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops.Core
{
    public class Factorial
    {
        public long FindFactorial(int n)
        {
            long res = 1;

            if (n == 0 || n < 0) throw new ArgumentException("Not a valid value");
            if (n > 0) {
                for (int i = n; i >= 1; i--) res *= i;
            }

            return res;
        }
    }
}
