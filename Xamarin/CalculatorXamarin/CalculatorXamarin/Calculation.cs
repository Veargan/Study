using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CalculatorXamarin
{
    public class Calculation
    {
        public int Calculate(int a, int b, string op)
        {
            int res = 0;

            switch (op)
            {
                case "+":
                    res = a + b;
                    break;
                case "-":
                    res = a - b;
                    break;
                case "*":
                    res = a * b;
                    break;
                case "/":
                    if ((a == 0) || (b == 0)) throw new ArithmeticException("NaN");
                    if (b == 0) throw new DivideByZeroException();
                    res = a / b;
                    break;
                default:
                    break;
            }

            return res;
        }
    }
}