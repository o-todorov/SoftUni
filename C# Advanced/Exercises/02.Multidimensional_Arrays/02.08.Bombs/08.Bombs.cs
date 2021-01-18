using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrSize    = int.Parse(Console.ReadLine());
            int[,] matr     = new int[matrSize + 2, matrSize + 2]; 
            // Makes matrix with offsets - cols + 2 and cols + 2

            ReadMatrix(matr, matrSize);

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var bombs = input.Select(s =>  new KeyValuePair<int,int>(
                 int.Parse(s.Split(',')[0]),
                 int.Parse(s.Split(',')[1])));

            foreach (var item in bombs)
            {
                Explode(item, matr);
            }

            int sum     = 0;
            int counter = 0;

            for (int i = 1; i < matrSize + 1; i++)
            {
                for (int j = 1; j < matrSize + 1; j++)
                {
                    if (matr[i, j] > 0)
                    {
                        counter++;
                        sum += matr[i, j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {sum}");

            PrintMatrix(matr);
        }

        private static void PrintMatrix(int[,] matr)
        {
            int matrSize = (int)Math.Sqrt(matr.Length) - 2;

            for (int i = 1; i < matrSize + 1; i++)
            {
                for (int j = 1; j < matrSize + 1; j++)
                {
                    Console.Write($"{matr[i, j]} ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void Explode(KeyValuePair<int, int> bomb, int[,] matr)
        {
            int bombPower = matr[bomb.Key + 1, bomb.Value + 1];

            if (bombPower <= 0) return;

            for (int i = bomb.Key; i < bomb.Key + 3; i++)
            {
                for (int j = bomb.Value; j < bomb.Value + 3; j++)
                {
                    if (matr[i, j] > 0)
                    {
                        matr[i, j] -= bombPower;
                    }
                }
            }

            matr[bomb.Key + 1, bomb.Value + 1] = 0;
        }

        private static void ReadMatrix(int[,] matr, int matrSize)
        {
            for (int i = 0; i < matrSize; i++)
            {
                int[] arr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrSize; j++)
                {
                    matr[i + 1, j + 1] = arr[j];
                }

            }
        }
    }
}
