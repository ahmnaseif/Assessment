using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_Difficulty_2
{
    public class Minefield
    {
        private int[,] field;
        private int row, col;

        public Minefield(int[,] field)
        {
            this.field = field;
            this.row = field.GetLength(0);
            this.col = field.GetLength(1);
        }
        private bool IsSafeRAnge(int x, int y)
        {
            bool xInRange = x >= 0 && x < row;
            bool yInRange = y >= 0 && y < col;
            bool noBomb = false;

            if (xInRange && yInRange)
                noBomb = field[x, y] == 0;

            return xInRange && yInRange && noBomb;
        }

        private bool SearchPath(int pupX, int pupY, int allyX, int allyY)
        {
            if (pupX == row - 1 && pupY == col - 1)
            {
                if ((allyX == row - 1 && allyY == col - 2) || (allyX == row - 2 && allyY == col - 1))
                    return true;
                return false;
            }


            int[] downDir = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] rightDir = { -1, 0, 1, -1, 1, -1, 0, 1 };


            field[pupX, pupY] = 2; 
            if (allyX != -1 && allyY != -1)
                field[allyX, allyY] = 3; 

            for (int i = 0; i < 8; i++)
            {
                int newPupX = pupX + downDir[i];
                int newPupY = pupY + rightDir[i];

                if (IsSafeRAnge(newPupX, newPupY))
                {
                    int newAllyX = pupX;
                    int newAllyY = pupY;


                    if (newAllyX == newPupX && newAllyY == newPupY)
                        continue;

                    if (SearchPath(newPupX, newPupY, newAllyX, newAllyY))
                        return true;
                }
            }

            field[pupX, pupY] = 0;
            if (allyX != -1 && allyY != -1)
                field[allyX, allyY] = 0;

            return false;
        }

        public bool FindSafePathForSnifferPupAndAlly()
        {
            return SearchPath(0, 0, -1, -1); 
        }

        public void PrintPath()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (field[i, j] == 2)
                        Console.Write("√ "); 
                    else if (field[i, j] == 3)
                        Console.Write("√√ "); 
                    else if (field[i, j] == 1)
                        Console.Write("X "); 
                    else
                        Console.Write(" "); 
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
                { 0, 1, 1, 0 },
                { 0, 0, 1, 1 },
                { 1, 0, 0, 1 },
                { 0, 0, 0, 0 },
                { 0, 1, 0, 0 }
            };

            Minefield minefield = new Minefield(field);

            if (minefield.FindSafePathForSnifferPupAndAlly())
            {
                Console.WriteLine("A safe path was found for both Sniffer Pup and Ally:");
                minefield.PrintPath();
            }
            else
            {
                Console.WriteLine("No safe path exists for both Sniffer Pup and Ally.");
            }

            Console.WriteLine("Enter a key to Exit..");
            Console.ReadKey();
        }
    }
}
