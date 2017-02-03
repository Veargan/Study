using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HenesseyXO.Authentification
{
    public class Client : IDisposable
    {
        public string Name { set; get; }
        public TcpClient User { set; get; }

        public Client(string name, TcpClient user)
        {
            this.Name = name;
            this.User = user;
        }

        public void Dispose()
        {
            User.Close();
        }
    }
}
