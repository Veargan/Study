using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class Client
    {
        public string name;
        public TcpClient user;

        public Client(string name, TcpClient user)
        {
            this.name = name;
            this.user = user;            
        }
        public string Read()
        {
            StreamReader sr = new StreamReader(user.GetStream());
            return sr.ReadLine();
        }
    }
}
