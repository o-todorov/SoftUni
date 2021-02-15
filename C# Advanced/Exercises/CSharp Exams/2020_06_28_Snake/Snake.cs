using System;
using System.Collections.Generic;

namespace _2020_06_28_Snake
{
    class Snake
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] territory = new char[size,size];
            int snakeRow = 0;
            int snakeCol = 0;
            var burrows = new List<int[]>();

            for (int i = 0; i < size; i++)
            {
                var row = Console.ReadLine();

                for (int j = 0; j < size; j++)
                {
                    char currChar = row[j];

                    if (currChar == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }
                    else if (currChar == 'B')
                    {
                        burrows.Add(new int[2] { i, j });
                    }

                    territory[i, j] = currChar;
                }
            }

            var moves = new Dictionary<string, int[]>()
            {
            {"up"   ,new int[2]{-1,0} },
            {"down" ,new int[2]{1,0 } },
            {"left" ,new int[2]{0,-1} },
            {"right",new int[2]{0,1 } },
            };

            int food = 0;
            string move = Console.ReadLine();

            while (move != null)
            {
                territory[snakeRow,snakeCol] = '.';
                char newpos = GetNewPosition(territory, snakeRow += moves[move][0], snakeCol += moves[move][1]);

                if (newpos == 'X')
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (newpos == '*')
                {
                    if (++food == 10)
                    {
                        Console.WriteLine("You won! You fed the snake.");
                        break;
                    }
                }
                else if (newpos == 'B')
                {
                    territory[snakeRow, snakeCol] = '.';

                    if (burrows[0][0] == snakeRow && burrows[0][1] == snakeCol)
                    {
                        snakeRow = burrows[1][0];
                        snakeCol = burrows[1][1];

                    }
                    else
                    {
                        snakeRow = burrows[0][0];
                        snakeCol = burrows[0][1];
                    }
                }

                move = Console.ReadLine();
            }

            Console.WriteLine($"Food eaten: {food}");

            PrintMatrix(territory);
        }

        private static void PrintMatrix(char[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {

                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    Console.Write(matr[i,j]);
                }

                Console.WriteLine();
            }
        }

        private static char GetNewPosition(char[,] matr, int r, int c)
        {
            if (IsValidPosition(matr.GetLength(0), matr.GetLength(1), r, c))
            {
                var ret = matr[r,c];
                matr[r,c] = 'S';
                return ret;
            }
            else
            {
                return 'X';
            }
        }

        private static bool IsValidPosition(int rows, int cols, int r, int c)
        {
            return r >= 0 && r < rows && c >= 0 && c < cols;
        }
    }
}
