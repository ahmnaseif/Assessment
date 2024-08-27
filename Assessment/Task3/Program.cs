using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Minefield
    {
        private int[,] field;
        private int row, col;
        private int[,] path;

        public Minefield(int[,] field)
        {
            this.field = field;
            this.row = field.GetLength(0);
            this.col = field.GetLength(1);
            this.path = new int[row, col];
        }

        private bool IsSafeRAnge(int x, int y)
        {
            bool xInRange = x >= 0 && x < row;
            bool yInRange = y >= 0 && y < col;
            bool noBomb = false;

            if (xInRange && yInRange)
                noBomb = field[x, y] == 0;

            return xInRange && yInRange  && noBomb;
        }

        public bool FindSafePath(int x, int y)
        {
            if (!IsSafeRAnge(x, y))
                return false;

            if (x == row - 1 && y == col - 1 || x == row - 1 && y == 0)
            {
                path[x, y] = 1; 
                return true;
            }


            field[x, y] = 2; 

            int[] downDir = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] rightDir = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++)
            {
                int newX = x + downDir[i];
                int newY = y + rightDir[i];

                if (IsSafeRAnge(newX, newY))
                {
                    if (FindSafePath(newX, newY))
                    {
                        path[x, y] = 1;
                        return true;
                    }
                }
            }

            field[x, y] = 0; 
            return false;
        }


        public void PrintPath()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (path[i, j] == 1)
                        Console.Write("√ ");
                    else if (field[i, j] == 1)
                        Console.Write("X ");
                    else
                        Console.Write("  ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            int[,] field = {
            { 0, 1, 1,0 },
            { 0, 0, 1,1 },
            { 1, 0, 0 , 1},
            { 0, 0, 1 , 1},
            { 0, 1, 0,0 }
            };

            Minefield minefield = new Minefield(field);

            if (minefield.FindSafePath(0, 0))
            {
                Console.WriteLine("A safe path was found:");
                minefield.PrintPath();
            }
            else
            {
                Console.WriteLine("No safe path exists.");
            }

            Console.WriteLine("Enter a key to Exit..");
            Console.ReadKey();
        }
    }
}
