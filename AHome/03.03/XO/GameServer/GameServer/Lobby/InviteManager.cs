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
        public void SendInvite(Client player1, Client player2, string gameid)
        {
            if (player1.status != "1" || player2.status != "1")
            {
                player2.Write("invite," +  gameid + "," + player1.name + "," + player2.name );
            }              
        }

        public void SendSuccess(Client player1, Client player2, string gameid)
        {
            if (player1.status != "1" || player2.status != "1")
            {
                player2.Write("success," + gameid + "," + player1.name + "," + player2.name);
            }
        }
    }
}
