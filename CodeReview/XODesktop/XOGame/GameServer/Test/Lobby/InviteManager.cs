using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class InviteManager
    {
        public string SendInvite(Client player1, Client player2, string gameid)
        {
            if (player1.status != "1" || player2.status != "1")
            {
                return("invite," +  gameid + "," + player1.name + "," + player2.name );
            }
            return "fail";
        }

        public string SendSuccess(Client player1, Client player2, string gameid)
        {
            if (player1.status != "1" || player2.status != "1")
            {
                return("success," + gameid + "," + player1.name + "," + player2.name);
            }
            return "fail";
        }
    }
}
