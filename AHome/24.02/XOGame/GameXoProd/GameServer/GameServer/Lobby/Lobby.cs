using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class Lobby
    {
        InviteManager inviteManager;
        CommandManager commandManager;
        public Lobby(CommandManager commandManager)
        {
            inviteManager = new InviteManager();
            this.commandManager = commandManager;
        }
        public void SetCommand(string command)
        {
            string[] msg = command.Split(',');
            switch(msg[1])
            {
                case "invite":
                    inviteManager.SendInvite(commandManager.connectionList.GetClient(msg[2]), commandManager.connectionList.GetClient(msg[3]), msg[4]);
                    break;
                case "exit":
                    commandManager.connectionList.Remove(commandManager.connectionList.GetClient(msg[2]));
                    break;
               

            }
        }
    }
}
