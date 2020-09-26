using System;

namespace _03._02.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            ulong[][] matrix = new ulong[rows][];

            matrix[0] = new ulong[1] { 1 };

            if (rows > 1)
            {
                matrix[1] = new ulong[2] { 1, 1 };
            }

            for (int i = 2; i < rows; i++)
            {
                matrix[i] = new ulong[i + 1];
                matrix[i][0] = 1;
                matrix[i][i] = 1;

                for (int j = 1; j < i; j++)
                {
                    matrix[i][j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                }

            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }


        }
    }
}
