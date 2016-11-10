using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core
{
    public class Quarter
    {
        public int FindQuarter(int x, int y)
        {
            int res = 0;

            if (x > 0 && y > 0)
            {
                res = 1;
            }
            else if (x < 0 && y > 0)
            {
                res = 2;
            }
            else if (x < 0 && y < 0)
            {
                res = 3;
            }
            else if (x > 0 && y < 0)
            {
                res = 4;
            }
            else if (x == 0 || y == 0)
            {
                throw new ArgumentException("Coordinates on the axis");
            }

            return res;
        }
    }
}