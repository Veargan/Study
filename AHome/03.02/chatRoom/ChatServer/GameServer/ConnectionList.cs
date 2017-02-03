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
            BroadcastSend();
        }

        public void AddClient(Client client)
        {
            lock (locker)
            {
                clientList.Add(client);
            }
            BroadcastSend();
        }
        
        private void BroadcastSend()
        {
            string rooms = "list,";

            foreach(var room in roomList)
            {
                rooms += room.name + ",";
            }
           
            foreach(var client in clientList)
            {
                StreamWriter writer = new StreamWriter(client.user.GetStream());
                writer.WriteLine(rooms);
                writer.Flush();
            }
        }
    }
}
