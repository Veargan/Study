using MultiChatServerClientThread.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiChatServerClientThread
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerApi server = new ServerApi();
            Console.ReadKey();
        }
    }
}
