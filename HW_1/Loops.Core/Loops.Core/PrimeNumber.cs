using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops.Core
{
    public class PrimeNumber
    {
        public bool IsPrime(int n)
        {
            if ((n == 0) || (n == 1) || (n < 1)) throw new ArgumentException("Not a valid value");

            for (int i = 2; i*2 < n; i++)
            {
                if (n%i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}