using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._05.Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            Queue<char> snake = new Queue<char>(Console.ReadLine().ToCharArray());
            char[,] matr = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matr[i, j] = snake.Peek();
                    snake.Enqueue(snake.Dequeue());
                }

                if (++i < rows)
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        matr[i, j] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                }
            }

            PrintMatrix(matr, rows, cols);
        }
        private static void PrintMatrix(char[,] matr, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matr[i, j]}");
                }
                Console.WriteLine();
            }
        }

    }


}
