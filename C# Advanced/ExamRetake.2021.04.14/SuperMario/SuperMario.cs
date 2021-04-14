using System;
using System.Collections.Generic;

namespace SuperMario
{
    class SuperMario
    {
        private static Dictionary<char, Tuple<int, int>> moves = new Dictionary<char, Tuple<int, int>>()
            {
                {'W', new Tuple<int, int>(-1, 0) },
                {'S', new Tuple<int, int>( 1, 0) },
                {'A', new Tuple<int, int>( 0,-1) },
                {'D', new Tuple<int, int>( 0, 1) }
            };

        static void Main(string[] args)
        {
            const char princess     = 'P';
            const char bowser       = 'B';
            const char marioKilled  = 'X';
            const char empty        = '-';

            int lives       = int.Parse(Console.ReadLine());
            int rows        = int.Parse(Console.ReadLine());
            var maze        = new char[rows][];
            int marioRow    = 0, marioCol = 0;

            for (int i = 0; i < rows; i++)
            {
                var row = Console.ReadLine().Trim();
                maze[i] = row.ToCharArray();

                int idx = row.IndexOf('M');

                if (idx != -1)
                {
                    marioRow = i;
                    marioCol = idx;
                    maze[marioRow][marioCol] = empty;
                }

            }

            bool princessFound  = false;

            while (lives > 0 && !princessFound)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var bowserRow = int.Parse(input[1]);
                var bowserCol = int.Parse(input[2]);
                maze[bowserRow][bowserCol] = bowser;

                Move(input[0][0],ref  marioRow,ref marioCol);
                ValidateMove(ref  marioRow,ref marioCol, rows, maze[0].Length);

                lives--;

                if (maze[marioRow][marioCol] == princess)
                {
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    princessFound = true;
                    maze[marioRow][marioCol] = empty;
                }
                else if (maze[marioRow][marioCol] == bowser)
                {
                    lives -= 2;

                    if (lives > 0)
                    {
                        maze[marioRow][marioCol] = empty;
                    }
                }

                if (lives <= 0)
                {
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    maze[marioRow][marioCol] = marioKilled;
                }
            }


            PrintMaze(maze);

        }

        private static void PrintMaze(char[][] maze)
        {
            foreach (var row in maze)
            {
                Console.WriteLine(string.Join("",row));
            }
        }

        private static void ValidateMove(ref int marioRow, ref int marioCol, int rows, int cols)
        {
            marioRow = Math.Max(0, marioRow);
            marioRow = Math.Min(rows-1, marioRow);
            marioCol = Math.Max(0, marioCol);
            marioCol = Math.Min(cols-1, marioCol);
        }

        private static void Move(char direction, ref int marioRow, ref int marioCol)
        {
            marioRow += moves[direction].Item1;
            marioCol += moves[direction].Item2;
        }
    }
}
