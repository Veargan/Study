using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Core
{
    public class Program
    {
        private static AVLTree tr;
        static void Main(string[] args)
        {
            int[] ini = { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 };
            tr = new AVLTree();
            tr.Init(ini);
            Console.WriteLine(tr.Leaves());
            Console.WriteLine(tr.NodeS());
            Console.WriteLine(tr.Height());
            //Console.WriteLine(tr.Width());
            Console.ReadKey();
        }
    }
}
