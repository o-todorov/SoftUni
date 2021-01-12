using System;
using System.Linq;

namespace _02._03.Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                       .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            int[,] matr = new int[rows, cols];

            FillMatrixFromConsole(matr, rows, cols);
            int a, b, c;
            long max = int.MinValue;
            long sum = 0;
            int idxR = 0, idxC = 0;

            for (int i = 0; i < rows - 2; i++)
            {
                a = matr[i, 0] + matr[i + 1, 0] + matr[i + 2, 0];
                b = matr[i, 1] + matr[i + 1, 1] + matr[i + 2, 1];
                c = matr[i, 2] + matr[i + 1, 2] + matr[i + 2, 2];
                sum = a + b + c;

                if (sum > max)
                {
                    max = sum;
                    idxR = i;
                    idxC = 0;
                }

                for (int j = 3; j < cols; j++)
                {
                    a = b;
                    b = c;
                    c = matr[i, j] + matr[i + 1, j] + matr[i + 2, j];
                    sum = a + b + c;

                    if (sum > max)
                    {
                        max = sum;
                        idxR = i;
                        idxC = j - 2;
                    }
                }
            }

            Console.WriteLine($"Sum = {max}");

            for (int i = idxR; i < idxR + 3; i++)
            {
                Console.WriteLine($"{matr[i, idxC]} {matr[i, idxC + 1]} {matr[i, idxC + 2]}");
            }


        }

        private static void FillMatrixFromConsole(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                int[] arr = Console.ReadLine()
                       .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = arr[j];
                }
            }
        }
    }
}
