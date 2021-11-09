using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLive
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endgame = false;
            int[,] grid = new int[,]
            {
                {1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,},
                {0,  0,  1,  0,  0,  1,  1,  0,  0,  0,  0,},
                {0,  1,  1,  0,  1,  1,  1,  1,  0,  0,  0,},
                {0,  1,  0,  0,  0,  1,  1,  0,  0,  0,  0,},
                {0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,},
                {0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,},
                {0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,},
                {1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {1,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,},
                {1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,}
            };

            gridconstructor gameofLife = new gridconstructor();
            while (endgame == false)
            {
                Console.WriteLine("Bienvenido al Game of life simulator");
                Console.WriteLine("Para empezar presione 1, para salir presione 2:");
                Console.WriteLine();

                
                int choice;
                repeat:
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Intente otra vez...");
                    goto repeat;
                }

                if (choice == 1)
                {
                    gameofLife.activegird(grid);
                }
                else
                {
                    Environment.Exit(1);
                }
            }
        }
    }

    class gridconstructor
    {
         int[,] livegrid;
         int[,] oldgrid;

         public void activegird(int[,] grid)
         {
             livegrid = (int[,])grid.Clone();

             int gridcol = livegrid.GetLength(0);
             int gridrow = livegrid.GetLength(1);

             for (int i = 0; i < gridcol; i++)
             {
                 for (int j = 0; j < gridrow; j++)
                 {
                     int livecellcount = cellchecker(i, j);

                     if (livegrid[i, j] == 1)
                     {
                         if (livecellcount <= 1)
                         {
                             livegrid[i, j] = 0;
                         }
                         else if (livecellcount == 2 || livecellcount == 3)
                         {
                             livegrid[i, j] = 1;
                         }
                         else
                         {
                             livegrid[i, j] = 0;
                         }
                     }
                     else
                     {
                         if (livecellcount == 3)
                         {
                             livegrid[i, j] = 1;
                         }
                         else
                         {
                             livegrid[i, j] = 0;
                         }
                     }
                 }
             }

             oldgrid = (int[,]) livegrid.Clone();
             displaygrid(livegrid);
             Console.WriteLine("Si deseas continuar presiona y");
             string checkkey = Console.ReadLine();
             checkkey = checkkey.ToLower();

             if (checkkey == "y")
             {
                 activegird(oldgrid);
             }
             else
             {
                 return;
             }

             
         }

        public int cellchecker(int x, int y)
        {
            int livecells = 0;

            if (x < 9 && y < 9)
            {
                if (livegrid[x + 1, y] == 1)
                {
                    livecells++;
                }
            }

            if (x < 9)
            {
                if (livegrid[x + 1, y] == 1)
                {
                    livecells++;
                }
            }

            if (y < 9)
            {
                if (livegrid[x, y + 1] == 1)
                {
                    livecells++;
                }
            }

            if(x > 0 && y > 0)
            {
                if (livegrid[x - 1, y - 1] == 1)
                {
                    livecells++;
                }
            }

            if (y > 0)
            {
                if (livegrid[x, y - 1] == 1)
                {
                    livecells++;
                }
            }

            if (x > 0)
            {
                if (livegrid[x - 1, y] == 1)
                {
                    livecells++;
                }
            }

            if (x < 9 && y > 0)
            {
                if (livegrid[x + 1, y - 1] == 1)
                {
                    livecells++;
                }
            }

            if (x > 0 && y < 9)
            {
                if (livegrid[x - 1, y + 1] == 1)
                {
                    livecells++;
                }
            }
            return livecells;
        }

        public void displaygrid(int[,] livegrid)
        {
            int gridcol = livegrid.GetLength(0);
            int gridrow = livegrid.GetLength(1);

            for (int i = 0; i < gridcol; i++)
            {
                for (int j = 0; j < gridrow; j++)
                {
                    Console.Write("{0,2}", livegrid[i, j]);
                }

                Console.WriteLine();
            }
        }

    }
}

