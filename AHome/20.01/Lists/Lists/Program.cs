using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            AList2S lst = new AList2S();
            string[] array = { "-1", "0", "3", "3", "5", "7", "8" };
            lst.Init(array);
            object s = lst.Get(5);
            
        }
    }
}
