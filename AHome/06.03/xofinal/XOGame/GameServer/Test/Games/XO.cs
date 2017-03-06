using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test 
{
    class XO
    {
        int[] matrix;
        string player1;
        string player2;
        bool player1turn = true;

        public XO(string player1, string player2)
        {
            matrix = new int[9];
            this.player1 = player1;
            this.player2 = player2;            
        }

        public bool ContainsPlayer(string client)
        {
            if (player1 == client || player2 == client)
                return true;
            return false;
        }

        public string Action(string player, string input)
        {
            string tmp = "";

            if (input == "StopGame")
                if (player == player1)
                {
                    return ("gamexo," + player1 + ",fail");
                }
                else
                {
                    return ("gamexo," + player2 + ",fail");
                }

            if (player1turn && player == player1) // player1 turn
            {
                string turn1 = input;
                player1turn = !player1turn;
                return ("gamexo," + turn1 + ",X");   
            }

            else if(!player1turn && player2 == player)
            {
                string turn2 = input;
                player1turn = !player1turn;
                return ("gamexo," + turn2 + ",O");
            }
            return tmp;
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
