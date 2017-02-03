using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenesseyXO.RealJope
{
    public class XOGame : IGame
    {
        private string[] matrix;

        private string[] combinations;

        public XOGame()
        {
            matrix = new string[] { "", "", "", "", "", "", "", "", "", };
            combinations = new string[8];
        }

        public void Turn(int index, string unit)
        {
            matrix[index] = unit;
        }

        public string[] GetMatrix()
        {
            return matrix;
        }

        public string Result { set; get; }

        public bool IsGameOver()
        {
            combinations[0] = matrix[0] + matrix[1] + matrix[2];
            combinations[1] = matrix[3] + matrix[4] + matrix[5];
            combinations[2] = matrix[6] + matrix[7] + matrix[8];
            combinations[3] = matrix[0] + matrix[3] + matrix[6];
            combinations[4] = matrix[1] + matrix[4] + matrix[7];
            combinations[5] = matrix[2] + matrix[5] + matrix[8];
            combinations[6] = matrix[0] + matrix[4] + matrix[8];
            combinations[7] = matrix[2] + matrix[4] + matrix[6];

            bool draw = true;
            for (int i = 0; i < combinations.Length; i++)
            {
                if (combinations[i].Length >= 3)
                {
                    if (combinations[i].All(ch => ch == 'X') || combinations[i].All(ch => ch == '0'))
                    {
                        Result = combinations[i].First() + " win!";
                        return true;
                    }
                }
                else
                {
                    draw = false;
                }
            }

            if (draw)
            {
                Result = "Draw!";
            }
            return draw;
        }
    }
}
