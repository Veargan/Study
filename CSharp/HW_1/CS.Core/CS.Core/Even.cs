using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core
{
    public class Even
    {
        public static void Main(string[] args)
        {
        }

        public int EvenNumber(int a, int b)
        {
            int res = 0;

            if (a % 2 == 0)
            {
                res = a * b;
            }
            else
            {
                res = a + b;
            }

            return res;
        }
    }
}