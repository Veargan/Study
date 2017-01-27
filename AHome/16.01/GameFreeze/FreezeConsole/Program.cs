using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFreeze;

namespace FreezeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Locks lc = new Locks();

            Console.WriteLine(lc.Calc());

            Console.ReadLine();
        }
    }
}
