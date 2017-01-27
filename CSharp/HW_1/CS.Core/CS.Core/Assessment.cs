using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core
{
    public class Assessment
    {
        public string Calculation(int a)
        {
            string res = "";

            if ((a >= 0) && (a <= 19)) res = "F";
            if ((a >= 20) && (a <= 39)) res = "E";
            if ((a >= 40) && (a <= 59)) res = "D";
            if ((a >= 60) && (a <= 74)) res = "C";
            if ((a >= 75) && (a <= 89)) res = "B";
            if ((a >= 90) && (a <= 100)) res = "A";
            if (a < 0) throw new ArgumentOutOfRangeException("Not a valid range");
            if (a > 100) throw new ArgumentOutOfRangeException("Not a valid range");

            return res;
        }
    }
}