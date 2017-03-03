using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameServer
{
    class ConnectionList
    {
        public  List<Client> clientList;   

        public ConnectionList()
        {
            clientList = new List<Client>();            
        }

        public void AddList(Client client)
        {
            clientList.Add(client);            
        }

        public void ClientReady(Client client)
        {
            BroadcastSend();
        }
        public void Remove(Client client)
        {
            clientList.Remove(client);
            BroadcastSend();
        }

        public void Remove(string client)
        {
            foreach (var item in clientList)
            {
                if (item.name == client)
                {
                    clientList.Remove(item);
                }
            }
            BroadcastSend();
        }

        public void BroadcastSend()
        {
            foreach (var item in clientList)
            {
                item.Write(MakeClientList(item.name));
            }          
        }

        private string MakeClientList(string name)
        {
            string users = "list,";

            foreach(var item in clientList)
            {
                if (item.name == name || item.name == null)
                    continue;
                users += item.name+"#"+item.status + ",";
            }
            users = users.TrimEnd(',');

            return users;
        }

        public Client GetClient(string name)
        {
            Client client = null;
            foreach (var item in clientList)
            {
                if (item.name == name)
                {
                    client = item;
                    break;
                }
            }
            return client;
        }
    }
}
