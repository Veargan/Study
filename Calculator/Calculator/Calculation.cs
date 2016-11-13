using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculation
    {
        public string Calculate(double a, double b, string op)
        {
            double res = 0;

            switch (op)
            {
                case "+":
                    res = a + b;
                    break;
                case "-":
                    res = a - b;
                    break;
                case "*":
                    res = a*b;
                    break;
                case "/":
                    res  = a/b;
                    break;
            }

            return res.ToString();
        }
    }
}
