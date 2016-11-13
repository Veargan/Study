using System;

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
                    if ((a == 0) && (b == 0)) throw new ArgumentNullException("NaN");
                    if (b == 0) throw new DivideByZeroException("Divided by zero");
                    res  = a/b;
                    break;
            }

            return res.ToString();
        }
    }
}
