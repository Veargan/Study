using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class ConnectionList
    {
        public  List<Client> clientList;
        private object locker;

        public ConnectionList()
        {
            this.locker = new object();
            clientList = new List<Client>();
        }

        public void AddList(Client client)
        {
            lock (locker)
            {
                clientList.Add(client);
            }
            BroadcastSend();
        }

        public void Remove(Client client)
        {
            lock (locker)
            {
                clientList.Remove(client);
            }
            BroadcastSend();
        }

        public void Remove(string client)
        {
            lock (locker)
            {
                foreach (var item in clientList)
                {
                    if (item.name == client)
                    {
                        clientList.Remove(item);
                    }
                }
            }
            BroadcastSend();
        }

        private void BroadcastSend()
        {
            string freeUsers = "list,";

            foreach(var item in clientList)
            {
                freeUsers += item.name + ",";
            }

            freeUsers.Remove(freeUsers.Length - 2);

            foreach(var item in clientList)
            {
                StreamWriter writer = new StreamWriter(item.user.GetStream());
                writer.WriteLine(freeUsers);
                writer.Flush();
            }
        }
    }
}
