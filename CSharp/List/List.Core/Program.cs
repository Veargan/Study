using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.Core
{
    public class Program
    {
        private static LListR list;
        private static void Main(string[] args)
        {
            list = new LListR();
            int[] ar = new int[] { 1, 2, 3 };
            list.Init(ar);
            list.DelPos(1);
            int[] res = list.ToArray();
        }
    }
}
