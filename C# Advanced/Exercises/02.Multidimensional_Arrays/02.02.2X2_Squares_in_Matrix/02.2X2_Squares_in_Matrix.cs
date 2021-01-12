using System;
using System.Linq;

namespace _02._02._2X2_Squares_in_Matrix
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
            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                char[] arr = Console.ReadLine()
                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                       .Select(char.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            int count = 0;

            for (int i = 0; i < rows-1; i++)
            {
                for (int j = 0; j < cols-1; j++)
                {
                    if (IsSquare(i, j, matrix))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);

        }

        private static bool IsSquare(int i, int j, char[,] matrix)
        {
            char ch = matrix[i, j];

            if (ch == matrix[i + 1, j] && ch == matrix[i + 1, j + 1] && ch == matrix[i, j + 1])
            {
                return true;
            }

            return false;
        }
    }
}
