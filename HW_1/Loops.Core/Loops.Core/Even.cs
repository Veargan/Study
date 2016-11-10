using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops.Core
{
    public class Even
    {
        public static void Main(string[] args)
        {
        }

        public int SumEvenNumbers()
        {
            int sum = 0;

            for (int i = 1; i <= 99; i++)
            {
                if (i%2 == 0) sum += i++;
            }

            return sum;
        }

        public int CountEvenNumbers()
        {
            int quantity = 0;

            int i = 1;

            do
            {
                if (i%2 == 0) quantity++;
                i++;
            } while (i <= 99);


            return quantity;
        }
    }
}