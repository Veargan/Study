using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Games
    {
        CommandManager commandManager;
        List<XO> gameList;
        public Games(CommandManager commandManager)
        {
            gameList = new List<XO>() { new XO("mike1", "oleg")};
            this.commandManager = commandManager;
        }
        public string SetCommand(string command)
        {
            string tmp = "";
            string[] msg = command.Split(',');
            switch (msg[1])
            {
                case "ask":
                    if (AskRequest(msg[2], msg[3], msg[4]))
                        XO(msg);
                    return gameList.Count().ToString();

                case "gamexo":
                    return GameXo(msg);
            }
            return tmp;
        }
        public void XO(string[] msg)
        {
            Random ran = new Random();
            int variant = ran.Next(0, 2);
            if (variant == 1)
            {
                gameList.Add(new XO(msg[3], msg[4]));
            }
            else gameList.Add(new XO(msg[4], msg[3]));
        }
        public string GameXo(string[] msg)
        {
            string tmp = "";
            for (int i = 0; i < gameList.Count; i++)
            {
                if (gameList[i].ContainsPlayer(msg[2]))
                {
                    return gameList[i].Action(msg[2], msg[3]);
                }
            }
            return tmp;
        }


        private bool AskRequest(string ask, string player1, string player2)
        {
            if (ask == "No")
            {
                return false;
            }
            else return true;
        }    
    }
}
