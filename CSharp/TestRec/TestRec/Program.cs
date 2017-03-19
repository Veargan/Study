using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRec
{
    class A
    {
        public A() { }
    }

    class B : A
    {
        public B() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();

            A a = (A)b; //upcast
            B b1 = (B)a; //downcast

            A a2 = new A();
            B b2 = new B();

            B b3 = (B)a; //wrong

            Console.WriteLine(Count(3));
            Console.WriteLine(Count1(3));
            Console.WriteLine(Count2(4));
            Console.WriteLine(fib(20));
            Console.WriteLine(fib1(20));
            Console.ReadKey();
        }

        static string Count(int x)
        {
            if (x == 1)
                return "1";

            return Count(x - 1) + "-" + x;
        }

        static string Count1(int x)
        {
            if (x > 1)
                Count1(x - 1);

            Console.Write(x + "-");
            return "";
        }

        static int Count2(int x)
        {
            if (x == 1)
                return 1;

            return Count2(x - 1) * x;
        }

        static int fib(int n)
        {
            return n > 1 ? fib(n - 1) + fib(n - 2) : n;
        }

        static string fib1(int n)
        {
            int fib1 = 1;
            int fib2 = 1;
            int i = 2;
            int fib_sum = 1;

            while (i < n)
            {
                fib_sum = fib2 + fib1;
                fib1 = fib2;
                fib2 = fib_sum;
                i += 1;
                Console.Write(fib_sum + "+");
            }

            Console.WriteLine(fib_sum);

            return "";
        }
    }
}