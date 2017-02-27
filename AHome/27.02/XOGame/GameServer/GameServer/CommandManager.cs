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

        public void Dispatcher(string message, Client client)
        {
            ;
            string[] input = message.Split(',');
            switch(input[0])
            {
                case "login":
                    if (connectionList.GetClient(input[1]) == null)
                    {
                        if (dbmanager.Login(input[1], input[2]))
                        {
                            client.name = input[1];
                            client.Write("login,Y," + input[1]);
                            connectionList.ClientReady(client);
                        }
                        else
                            client.Write("login,N," + input[1] + ",1");
                        break;
                    }
                    else
                        client.Write("login,N," + input[1] + ",2");
                    break;

                case "reg":
                    if (dbmanager.Register(input[1], input[2]))
                    {
                        client.name = input[1];
                        client.Write("reg,Y," + input[1]);
                        connectionList.ClientReady(client);                        
                    }
                    else
                        client.Write("reg,N," + input[1]);
                    break;

                case "lobby":
                    lobby.SetCommand(message);
                    break;
                case "games":
                    if(games.SetCommand(message))
                        connectionList.BroadcastSend();
                    break;
                case "list":
                    connectionList.BroadcastSend();
                    break;
                case "change":
                    if (dbmanager.ChangePassword(input[1], input[2], input[3]))                        
                        client.Write("change,Y");
                    else
                        client.Write("change,N");
                    connectionList.Remove(input[1]);
                    break;
                case "forgot":
                    if (dbmanager.SendPassword(input[1], input[2]))
                        client.Write("send,Y");
                    else
                        client.Write("send,N");
                    connectionList.Remove(input[1]);
                    break;
                case "logout":
                    client.user.Close();
                    connectionList.clientList.Remove(client);
                    connectionList.BroadcastSend();
                    break;
            }         
        }      
    }
}
