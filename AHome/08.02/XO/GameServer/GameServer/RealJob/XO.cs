using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class XO
    {
        int[] matrix;
        Client player1;
        Client player2;

        public XO(Client player1, Client player2)
        {
            matrix = new int[9];
            this.player1 = player1;
            this.player2 = player2;
        }

        public void Action()
        {
            StreamWriter writer1 = new StreamWriter(player1.user.GetStream());
            StreamWriter writer2 = new StreamWriter(player2.user.GetStream());
            
            while (true)
            {
                string turn1 = player1.Read();
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
                    break;
                }

                if (res1 == "standoff" || res1 == "standoff")
                {
                    writer1.WriteLine("gamexo" + "," + "standoff");
                    writer1.Flush();
                    writer2.WriteLine("gamexo" + "," + "standoff");
                    writer2.Flush();
                    break;
                }

                string turn2 = player2.Read();
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
                    break;
                }              
            }
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
