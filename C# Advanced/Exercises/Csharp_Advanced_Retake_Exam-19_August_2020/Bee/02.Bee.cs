using System;
using System.Collections.Generic;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] matr = new char[size][];
            int beeRow = 0, beeCol = 0;

            for (int i = 0; i < size; i++)
            {
                var row = Console.ReadLine();
                matr[i] = row.ToCharArray();

                int c = row.IndexOf('B');
                if (c == -1) continue;
                beeCol = c;
                beeRow = i;
            }

            var moves = new Dictionary<string, int[]>()
            {
            {"up"   ,new int[2]{-1,0} },
            {"down" ,new int[2]{1,0 } },
            {"left" ,new int[2]{0,-1} },
            {"right",new int[2]{0,1 } },
            };

            int pollinated = 0;
            string move = Console.ReadLine();

            while (move != "End")
            {
                matr[beeRow][beeCol] = '.';
                char newpos = GetNewPosition(matr, size, beeRow += moves[move][0], beeCol += moves[move][1]);

                if (newpos == 'X')
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (newpos == 'f')
                {
                    pollinated++;
                }
                else if (newpos == 'O')
                {
                    continue;
                }

                move = Console.ReadLine();
            }

            if (pollinated < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinated} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinated} flowers!");
            }

            PrintMatrix(matr, size);
        }

        private static void PrintMatrix(char[][] matr, int size)
        {
            foreach (var row in matr)
            {
                Console.WriteLine(row);
            }
        }

        private static char GetNewPosition(char[][] matr, int size, int r, int c)
        {
            if (IsValidPosition(size, r, c))
            {
                var ret = matr[r][c];
                matr[r][c] = 'B';
                return ret;
            }
            else
            {
                return 'X';
            }
        }

        private static bool IsValidPosition(int size, int r, int c)
        {
            return r >= 0 && r < size && c >= 0 && c < size;
        }
    }
}
