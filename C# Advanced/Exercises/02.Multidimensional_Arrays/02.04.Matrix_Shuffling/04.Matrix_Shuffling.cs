using System;
using System.Linq;

namespace _02._04.Matrix_Shuffling
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
            string[,] matr = new string[rows, cols];

            FillMatrixFromConsole(matr, rows, cols);

            string[] command = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            while (command[0].ToLower()!="end")
            {
                if(!IsValidCommand(command,rows,cols))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    string tmp = matr[int.Parse(command[1]), int.Parse(command[2])];
                    matr[int.Parse(command[1]), int.Parse(command[2])] = matr[int.Parse(command[3]), int.Parse(command[4])];
                    matr[int.Parse(command[3]), int.Parse(command[4])] = tmp;

                    PrintMatrix(matr, rows, cols);
                }

                command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static bool IsValidCommand(string[] arr, int rows, int cols)
        {
            if (arr[0].ToLower() == "swap" && arr.Length == 5)
            {
                if (IsValid(arr[1], rows) && IsValid(arr[2], cols) && IsValid(arr[3], rows) && IsValid(arr[4], cols))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsValid(string str, int max)
        {
            int idx = int.Parse(str);

            return idx >= 0 && idx < max;
        }

        private static void PrintMatrix(string[,] matr, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matr[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrixFromConsole(string[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                string[] arr = Console.ReadLine()
                       .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = arr[j];
                }
            }
        }
    }

}
