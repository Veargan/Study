using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsAndLambdaExpressions
{
    class Program
    {
        delegate string MyDel1();
        delegate Animal MyDel2(); // covariance
        delegate 

        static void Main(string[] args)
        {
            MyDel1 del1 = DelMethod1;
            del1 += DelMethod2;
            Console.WriteLine(del1());

            MyDel2 del2 = DelMethod3; // covariance
            Console.ReadKey();
        }

        static string DelMethod1()
        {
            return "hello bitch";
        }

        static string DelMethod2()
        {
            return "bye bitch";
        }

        // covariance
        static Dog DelMethod3()
        {
            return new Dog();
        }

        static void DelMethod4()
        {

        }

        class Animal
        {

        }

        class Dog : Animal
        {

        }
    }
}
