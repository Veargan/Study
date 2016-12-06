using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Core
{
    public class Program
    {
        private static BSTree tr;
        static void Main(string[] args)
        {
            int[] ini = { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 };
            tr = new BSTree();
            tr.Init(ini);
            Console.WriteLine(tr.Leaves());
            Console.WriteLine(tr.NodeS());
            Console.ReadKey();
        }
    }
}
