using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFreeze
{
    public class Locks
    {
        bool[,] locks;
        
        public Locks()
        {
            locks = new bool[4, 4];
            Random rnd = new Random();
            
            for (int i = 0; i < Math.Sqrt(locks.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(locks.Length); j++)
                {
                    if (rnd.Next()%2 == 0)
                        locks[i, j] = false;
                    else
                        locks[i, j] = true;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Math.Sqrt(locks.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(locks.Length); j++)
                {
                    if (Get(i,j) == true)
                    {
                        Console.Write("1 ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("--------------------------------------------------------");
        }


        public void Change(int i, int j)
        {
            locks[i, j] = !locks[i, j];
        }

        public void ChangeRC(int i, int j)
        {
            for (int k = 0; k < Math.Sqrt(locks.Length); k++)
            {
                Change(k, j);
                Change(i, k);
            }
            Change(i, j);
        }

        public bool Get(int i, int j)
        {
            return locks[i, j];
        } 

        public bool Check()
        {
            for (int i = 0; i < Math.Sqrt(locks.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(locks.Length); j++)
                {
                    if (locks[i, j] == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        
        public string Calc()
        {
            bool[,] tmp = new bool[4,4];
            string path = "";

            Print();

            while (!Check())
            {
                for (int i = 0; i < Math.Sqrt(locks.Length); i++)
                {
                    for (int j = 0; j < Math.Sqrt(locks.Length); j++)
                    {
                        tmp[i, j] = locks[i, j];
                    }
                }

                for (int i = 0; i < Math.Sqrt(locks.Length); i++)
                {
                    for (int j = 0; j < Math.Sqrt(locks.Length); j++)
                    {
                        if (tmp[i, j] == false)
                        {

                            ChangeRC(i, j);
                            path += "[" + i + "," + j + "] ";
                            Print();
                        }
                    }
                }
            }
            return path;
        }


    }
}
