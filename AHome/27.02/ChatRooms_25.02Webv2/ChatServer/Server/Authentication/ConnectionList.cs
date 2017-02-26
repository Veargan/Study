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
        public List<Client> clientList;
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
            try
            {
                roomList.Add(room);
                foreach (Client client in clientList)
                    if (client.name == "admin")
                        room.AddClient(client);

                BroadcastSend();
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: AddRoom" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public void AddClient(Client client)
        {
            try
            {
                //if (!CheckName(client))
                //    return;

                client.Write("success");
                Thread.Sleep(100);

                lock (locker)
                {
                    clientList.Add(client);
                }
                //Thread.Sleep(100);
                if (client.name == "admin")
                {
                    foreach (Room room in roomList)
                    {
                        room.AddClient(client);
                    }
                }
                BroadcastSend();
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: AddClient" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public bool CheckName(Client client)
        {
            try
            {
                if (clientList.Count == 0)
                {
                    client.Write("success");
                    Thread.Sleep(100);
                    return true;
                }
                for (int i = 0; i < clientList.Count; i++)
                {
                    if (client.name == clientList[i].name)
                    {
                        client.Write("fail");
                        Thread.Sleep(100);
                        return false;
                    }
                    else if (i == clientList.Count - 1)
                    {
                        client.Write("success");
                        Thread.Sleep(100);
                        return true;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: CheckName" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public void BroadcastSend()
        {
            try
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
                    client.Write(rooms);
                    Thread.Sleep(100);
                    client.Write(clients);
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: BroadcastSend" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }
    }
}
