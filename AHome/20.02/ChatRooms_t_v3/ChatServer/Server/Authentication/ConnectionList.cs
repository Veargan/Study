using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ConnectionList
    {
        public  List<Client> clientList;
        public List<Room> roomList;
        private object locker;

        public ConnectionList(object locker)
        {
            this.locker = locker;
            clientList = new List<Client>();
            roomList = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            roomList.Add(room);            

            foreach (Client client in clientList)
                if (client.name == "admin")
                    room.AddClient(client);

            BroadcastSend();
        }

        public void AddClient(Client client)
        {
            if (!check_name(client))
                return;

            lock (locker)
            {
                clientList.Add(client);
            }

            BroadcastSend();

            if (client.name == "admin")
                foreach (Room room in roomList)
                {
                    room.AddClient(client);
                }
        }

        public bool check_name(Client client)
        {
            if (clientList.Count == 0)
            {
                StreamWriter writer = new StreamWriter(client.user.GetStream());
                writer.WriteLine("success");
                writer.Flush();
                Thread.Sleep(100);
                return true;
            }
            for (int i = 0; i < clientList.Count; i++)
            {
                if (client.name == clientList[i].name)
                {
                    StreamWriter writer = new StreamWriter(client.user.GetStream());
                    writer.WriteLine("fail");
                    writer.Flush();
                    Thread.Sleep(100);
                    return false;
                }
                else if (i == clientList.Count - 1)
                {
                    StreamWriter writer = new StreamWriter(client.user.GetStream());
                    writer.WriteLine("success");
                    writer.Flush();
                    Thread.Sleep(100);
                    return true;
                }
            }
            return true;
        }

        public void BroadcastSend()
        {
            string rooms = "list^";
            string clients = "clientlist^";

            foreach (var room in roomList)
            {
                rooms += room.name + "^";
            }

            rooms = rooms.TrimEnd('^');

            foreach (var client in clientList)
            {
                clients += client.name + "^";
            }

            clients = clients.TrimEnd('^');

            foreach (var client in clientList)
            {
                StreamWriter writer = new StreamWriter(client.user.GetStream());
                writer.WriteLine(rooms);
                writer.Flush();
                writer.WriteLine(clients);
                writer.Flush();
            }
        }
    }
}
