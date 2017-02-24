using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class CommandManager
    {
        public ConnectionList connectionList;
        DataBaseManager dbmanager;  
        Lobby lobby;
        Games games;

        public CommandManager(ConnectionList connectionList, DataBaseManager dbmanager)
        {
            this.connectionList = connectionList;
            games = new Games(this);
            lobby = new Lobby(this);
            this.dbmanager = dbmanager;
        }

        public void Dispatcher(string message)
        {
            string[] input = message.Split(',');
            switch(input[0])
            {
                case "lobby":
                    lobby.SetCommand(message);
                    break;
                case "games":
                    games.SetCommand(message);
                    break;
                case "list":
                    connectionList.BroadcastSend();
                    break;
                case "change":
                    if (dbmanager.ChangePassword(input[1], input[2], input[3]))
                        connectionList.GetClient(input[1]).Write("changesuccess");
                    else
                        connectionList.GetClient(input[1]).Write("changefail");
                    connectionList.Remove(input[1]);
                    break;
                case "forgot":
                    string newpass = dbmanager.SendPassword(input[1]);
                    connectionList.GetClient(input[1]).Write(newpass);
                    connectionList.Remove(input[1]);
                    break;

            }         
        }      
    }
}
