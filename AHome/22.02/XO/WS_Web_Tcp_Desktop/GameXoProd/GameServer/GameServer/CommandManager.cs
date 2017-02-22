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
        Lobby lobby;
        Games games;

        public CommandManager(ConnectionList connectionList)
        {
            this.connectionList = connectionList;
            games = new Games(this);
            lobby = new Lobby(this);
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
            }         
        }      
    }
}
