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
        public List<Room> roomList;

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
        
        private void BroadcastSend()
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
