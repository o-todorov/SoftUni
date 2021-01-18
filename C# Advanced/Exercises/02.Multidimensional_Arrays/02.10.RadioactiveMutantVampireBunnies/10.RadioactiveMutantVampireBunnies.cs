using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class RadioActiveBunnies
    {
        public static int rows;
        public static int cols;
        public static char[][] lair;
        public static Queue<int[]> bunnies = new Queue<int[]>();

        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse).ToArray();

            rows = matrixSize[0];
            cols = matrixSize[1];
            lair = new char[rows][];

            int playerRow = 0, playerCol = 0;

            for (int r = 0; r < rows; r++)
            {
                lair[r] = Console.ReadLine().ToCharArray();

                for (int c = 0; c < cols; c++)
                {
                    if (lair[r][c] == 'B')
                    {
                        bunnies.Enqueue(new int[] { r, c });
                    }
                    else if (lair[r][c] == 'P')
                    {
                        playerRow = r;
                        playerCol = c;
                    }
                }
            }

            bool won = false;
            var moves = Console.ReadLine().ToCharArray();

            foreach (var direction in moves)
            {
                int r = playerRow, c = playerCol;

                if (direction == 'U') r--;
                else if (direction == 'D') r++;
                else if (direction == 'L') c--;
                else if (direction == 'R') c++;

                lair[playerRow][playerCol] = '.';

                int bunniesCount = bunnies.Count;

                for (int i = 0; i < bunniesCount; i++)
                {
                    GrowUpBunny(bunnies.First()[0], bunnies.First()[1]);
                    bunnies.Dequeue();
                }



                if (r < 0 || r >= rows || c < 0 || c >= cols)
                {
                    won = true;
                    break;
                }

                playerRow = r;
                playerCol = c;

                if (lair[r][c] == 'B')
                {
                    break;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join("", lair[i]));
            }

            string status = won ? "won" : "dead";
            Console.WriteLine($"{status}: {playerRow} {playerCol}");
        }

        private static void GrowUpBunny(int r, int c)
        {
            if (r - 1 >= 0) AddbUnny(r - 1, c);
            if (r + 1 < rows) AddbUnny(r + 1, c);
            if (c - 1 >= 0) AddbUnny(r, c - 1);
            if (c + 1 < cols) AddbUnny(r, c + 1);
        }

        private static void AddbUnny(int r, int c)
        {
            if (lair[r][c] != 'B')
            {
                lair[r][c] = 'B';
                bunnies.Enqueue(new int[] { r, c });
            }
        }
    }
}
