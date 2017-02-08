using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameServer
{
    class Session
    {
        string gameid;
        List<Client> clients;
        Thread threadSession;
        ConnectionList connectionList;

        public Session(List<Client> clients, string gameid, ConnectionList connectionList)
        {
            this.gameid = gameid;
            this.clients = clients;
            this.connectionList = connectionList;
        }
        public Session(string gameid, ConnectionList connectionList)
        {
            this.gameid = gameid;
            clients = new List<Client>();
            this.connectionList = connectionList;
        }
        public void StartSession()
        {
            threadSession = new Thread(Action);
            threadSession.Start();
        }
        public void AddClient(Client client)
        {
            clients.Add(client);
        }
        public void Action()
        {
            if (gameid == "XO")
            {
                XO xo = new XO(clients[0], clients[1]);
                xo.Action();
            }

            foreach (var client in clients)
            {
                connectionList.AddList(client);
            }
        }

    }
}
