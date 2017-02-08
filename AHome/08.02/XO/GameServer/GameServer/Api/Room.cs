using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class Room
    {
        ConnectionList connectionList;
        string player1;
        string player2;
        string gameid;
        
        public Room(ConnectionList connectionList, string player1, string player2, string gameid)
        {
            this.connectionList = connectionList;
            this.player1 = player1;
            this.player2 = player2;
            this.gameid = gameid;
        }

        public bool IsRoom(Room r)
        {
            if (r.player1.Equals(player1))
                return true;
            return false;
        }

        public bool IsRoom(string player)
        {
            if (player1.Equals(player))
                return true;
            return false;
        }

        private Client GetClient(string name)
        {
            Client client = null;
            foreach (var item in connectionList.clientList)
            {
                if (item.name == name)
                {
                    client = item;
                    break;
                }
            }
            return client;
        }

        public void SendInvite()
        {
            foreach (var item in connectionList.clientList)
            {
                if (item.name == player2)
                {
                    StreamWriter writer = new StreamWriter(item.user.GetStream());
                    writer.WriteLine("invite," + player1 + "," + player2 + "," + gameid);
                    writer.Flush();
                }
            }
        }

        public void AskRequest(string ask)
        {
            if (ask == "No")
            {
                return;
            }
            foreach (var item in connectionList.clientList)
            {
                if (item.name == player2)
                {
                    StreamWriter writer = new StreamWriter(GetClient(player1).user.GetStream());
                    writer.WriteLine("ask" + "," + "XO");
                    writer.Flush();
                    StreamWriter sw = new StreamWriter(GetClient(player2).user.GetStream());
                    sw.WriteLine("ask" + "," + "XO");
                    sw.Flush();
                    Session session = new Session(gameid, connectionList);
                    session.AddClient(GetClient(player1));
                    session.AddClient(GetClient(player2));

                    StartSession(session);
                }
            }
            connectionList.Remove(GetClient(player1));
            connectionList.Remove(GetClient(player2));
        }

        private void StartSession(Session session)
        {
            session.StartSession();
        }
    }
}
