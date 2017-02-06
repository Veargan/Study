using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class Admin : Client
    {
        public Admin(string name, TcpClient user) : base(name, user)
        {
        }
    }
}
