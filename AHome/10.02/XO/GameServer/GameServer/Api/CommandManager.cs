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
        InviteManager inviteManager;
        List<IGame> gameList;

        public CommandManager(ConnectionList connectionList)
        {
            this.connectionList = connectionList;
            inviteManager = new InviteManager();
            gameList = new List<IGame>();
        }

        public void Dispatcher(string message)
        {
            string[] input = message.Split(',');

            if (input[0] == "invite")
            {
                inviteManager.SendInvite(GetClient(input[1]), GetClient(input[2]), input[3]);
            }

            if (input[0] == "ask")
            {
                if (inviteManager.AskRequest(input[1], GetClient(input[2]), GetClient(input[3]), input[4]))
                {
                    switch (input[4])
                    {
                        case "XO":
                            gameList.Add(new XO(GetClient(input[2]), GetClient(input[3])));
                            break;
                    }
                }
            }

            if (input[0] == "gamexo")//gamexo,name,btnNumber
            {
                for(int i=0;i<gameList.Count;i++)
                {
                    if (gameList[i].ContainsPlayer(GetClient(input[1])))
                    {
                        if (gameList[i].Action(GetClient(input[1]), input[2]))
                            gameList.Remove(gameList[i]);

                    }
                }
            }
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
    }
}
