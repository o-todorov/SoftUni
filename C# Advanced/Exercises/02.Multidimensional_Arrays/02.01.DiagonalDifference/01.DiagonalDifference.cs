using System;
using System.Linq;

namespace _02._01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            int sumA = 0;
            int sumB = 0;

            for (int i = 0, j = matrixSize - 1; i < matrixSize; i++, j--)
            {
                sumA += matrix[i, j];
                sumB += matrix[i, i];
            }

            Console.WriteLine(Math.Abs(sumA - sumB));

        }
    }
}
