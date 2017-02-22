using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameServer 
{
    class XO : IGame
    {
        int[] matrix;
        Client player1;
        Client player2;
        bool player1turn = true;

        public XO(Client player1, Client player2)
        {
            matrix = new int[9];
            this.player1 = player1;
            this.player2 = player2;
            Thread.Sleep(100);
            player1.Write("gamexo,yourturn");
            
        }

        public bool ContainsPlayer(Client client)
        {
            if (player1.Equals(client) || player2.Equals(client))
                return true;
            return false;
        }

        public bool Action(Client player, string input)
        {
            StreamWriter writer1 = new StreamWriter(player1.user.GetStream());
            StreamWriter writer2 = new StreamWriter(player2.user.GetStream());
           
            writer1.Flush();
            if(input=="StopGame")
            {
                player2.Write("gamexo" + "," + "fail");
                player1.status = "0";
              
                player2.status = "0";
                player1.Write("gamexo" + "," + "victory");
                return true;
            }
            if (player1turn && player1.Equals(player)) // player1 turn
            {
                string turn1 = input;
                string res1 = Turn1(turn1);

                player2.Write("gamexo" + "," + turn1 + "," + "X");
                player1.Write("gamexo" + "," + turn1 + "," + "X");
                
                if (res1 == "victory")
                {
                    player1.Write("gamexo" + "," + "victory");
                    player1.status = "0";

                    player2.status = "0";
                    player2.Write("gamexo" + "," + "fail");

                    return true;
                }

                if (res1 == "standoff")
                {
                    player1.Write("gamexo" + "," + "standoff");
                    player1.status = "0";
                    player2.Write("gamexo" + "," + "standoff");
                    player2.status = "0";

                    return true;
                }

                player1turn = !player1turn;

                Thread.Sleep(100);
                player2.Write("gamexo,yourturn");
                Thread.Sleep(100);
                player1.Write("gamexo,notyourturn");
            }

            else if(!player1turn && player2.Equals(player))
            {
                string turn2 = input;
                string res2 = Turn2(turn2);

                player1.Write("gamexo" + "," + turn2 + "," + "O");
                player2.Write("gamexo" + "," + turn2 + "," + "O");


                if (res2 == "victory")
                {
                    player1.Write("gamexo" + "," + "fail");
                    player1.status = "0";
                    player2.Write("gamexo" + "," + "victory");
                    player2.status = "0";

                    return true;
                }

                if (res2 == "standoff")
                {
                    player1.Write("gamexo" + "," + "standoff");
                    player1.status = "0";
                    player2.Write("gamexo" + "," + "standoff");
                    player2.status = "0";

                    return true;
                }

                player1turn = !player1turn;

                Thread.Sleep(100);
                player1.Write("gamexo,yourturn");
                Thread.Sleep(100);
                player2.Write("gamexo,notyourturn");
            }

            return false;
        }

        public string Turn1(string message)
        {
            if (matrix[Convert.ToInt32(message)] == 0)
            {
                matrix[Convert.ToInt32(message)] = 1;
            }
            if (Checking() == 1 )
                return "victory";
            if (Checking() == -1 )
                return "standoff";
           
            else return "";
        }
        public string Turn2(string message)
        {
            if (matrix[Convert.ToInt32(message)] == 0)
            {
                matrix[Convert.ToInt32(message)] = 2;
            }
            if (Checking() == 1)
                return "victory";
            if (Checking() == -1)
                return "standoff";
            else return "";
        }
        private int Checking()
        {
            int res = 0;

            if (((matrix[0] == 1 && matrix[3] == 1 && matrix[6] == 1) || (matrix[0] == 2 && matrix[3] == 2 && matrix[6] == 2))
                || ((matrix[1] == 1 && matrix[4] == 1 && matrix[7] == 1) || (matrix[1] == 2 && matrix[4] == 2 && matrix[7] == 2))
                || ((matrix[2] == 1 && matrix[5] == 1 && matrix[8] == 1) || (matrix[2] == 2 && matrix[5] == 2 && matrix[8] == 2))
                || ((matrix[0] == 1 && matrix[4] == 1 && matrix[8] == 1) || (matrix[0] == 2 && matrix[4] == 2 && matrix[8] == 2))
                || ((matrix[2] == 1 && matrix[4] == 1 && matrix[6] == 1) || (matrix[2] == 2 && matrix[4] == 2 && matrix[6] == 2))
                || ((matrix[0] == 1 && matrix[1] == 1 && matrix[2] == 1) || (matrix[0] == 2 && matrix[1] == 2 && matrix[2] == 2))
                || ((matrix[3] == 1 && matrix[4] == 1 && matrix[5] == 1) || (matrix[3] == 2 && matrix[4] == 2 && matrix[5] == 2))
                || ((matrix[6] == 1 && matrix[7] == 1 && matrix[8] == 1) || (matrix[6] == 2 && matrix[7] == 2 && matrix[8] == 2)))
                res = 1;
            else
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] == 0)
                {
                    break;
                }
                if (i == matrix.Length - 1 && matrix[i] != 0)
                {
                    res = -1;
                }
            }
           
            return res;
        }
    }
}
