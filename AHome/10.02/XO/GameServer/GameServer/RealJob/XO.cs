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

            if (player1turn && player1.Equals(player)) // player1 turn
            {
                string turn1 = input;
                string res1 = Turn1(turn1);

                writer2.WriteLine("gamexo" + "," + turn1 + "," + "X");
                writer2.Flush();
                writer1.WriteLine("gamexo" + "," + turn1 + "," + "X");
                writer1.Flush();

                if (res1 == "victory")
                {
                    writer1.WriteLine("gamexo" + "," + "victory");
                    writer1.Flush();
                    writer2.WriteLine("gamexo" + "," + "fail");
                    writer2.Flush();

                    return true;
                }

                if (res1 == "standoff")
                {
                    writer1.WriteLine("gamexo" + "," + "standoff");
                    writer1.Flush();
                    writer2.WriteLine("gamexo" + "," + "standoff");
                    writer2.Flush();

                    return true;
                }

                player1turn = !player1turn;

                
            }

            else if(!player1turn && player2.Equals(player))
            {
                string turn2 = input;
                string res2 = Turn2(turn2);

                writer1.WriteLine("gamexo" + "," + turn2 + "," + "O");
                writer1.Flush();
                writer2.WriteLine("gamexo" + "," + turn2 + "," + "O");
                writer2.Flush();


                if (res2 == "victory")
                {
                    writer1.WriteLine("gamexo" + "," + "fail");
                    writer1.Flush();
                    writer2.WriteLine("gamexo" + "," + "victory");
                    writer2.Flush();

                    return true;
                }

                if (res2 == "standoff")
                {
                    writer1.WriteLine("gamexo" + "," + "standoff");
                    writer1.Flush();
                    writer2.WriteLine("gamexo" + "," + "standoff");
                    writer2.Flush();

                    return true;
                }

                player1turn = !player1turn;
            }

            return false;
        }

        public string Turn1(string message)
        {
            if (matrix[Convert.ToInt32(message)] == 0)
            {
                matrix[Convert.ToInt32(message)] = 1;
            }
            if (Checking() == 1)
                return "victory";
            if (Checking() == -1)
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
