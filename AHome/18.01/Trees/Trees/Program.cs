using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            ////int[] ini = { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 };
            ////int[] ini = { 1, 2, 3, 4, 5, 6, 0 };
            ////int[] ini = { 4, 5, 3, 6, 2, 1 };
            ////AvlTree tr = new AvlTree();
            ////tr.Init(ini);
            ////tr.Del(3);
            ////int[] t = tr.ToArray();
            ////Console.WriteLine();
            ////Console.WriteLine();
            ////for (int i = 0; i < t.Length; i++)
            ////{
            ////    Console.WriteLine(t[i]);
            ////}
            //////tr.Delete(11);
            //////tr.Print();
            int[] ini = { 1, 2, 3, 0};

            int[] inv = { 1,2,3,4,5,6 };
            AvlTree bt = new AvlTree();
            bt.Init(ini);
            AvlTree bs = new AvlTree();
            bs.Init(inv);
            bt.Del(2);
           // bool flag = bt.Equals(bs);
            Console.ReadKey();
        }
    }
}
