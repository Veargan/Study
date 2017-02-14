using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class InviteManager
    {
        public InviteManager() {}
        
        public void SendInvite(Client player1, Client player2, string gameid)
        {
            StreamWriter writer = new StreamWriter(player2.user.GetStream());
            writer.WriteLine("invite," + player1.name + "," + player2.name + "," + gameid);
            writer.Flush();
        }

        public bool AskRequest(string ask, Client player1, Client player2, string gameid)
        {
            if (ask == "No")
            {
                return false;
            }
            
            StreamWriter writer = new StreamWriter(player1.user.GetStream());
            writer.WriteLine("ask" + "," + "XO");
            writer.Flush();
            StreamWriter sw = new StreamWriter(player2.user.GetStream());
            sw.WriteLine("ask" + "," + "XO");
            sw.Flush();
            return true;
        }
    }
}
