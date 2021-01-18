using System;
using System.Linq;

namespace _02._06.Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matr = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                matr[i] = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(double.Parse)
                               .ToArray();
            }

            for (int i = 0; i < rows - 1; i++)
            {
                if (matr[i].Length == matr[i + 1].Length)
                {
                    matr[i] = matr[i].Select(i => i * 2).ToArray();
                    matr[i + 1] = matr[i + 1].Select(i => i * 2).ToArray();
                }
                else
                {
                    matr[i] = matr[i].Select(i => i / 2).ToArray();
                    matr[i + 1] = matr[i + 1].Select(i => i / 2).ToArray();
                }
            }

            string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0].ToLower() != "end")
            {
                int r = int.Parse(command[1]);
                int c = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (IsValid(r, rows) && IsValid(c, matr[r].Length))
                {
                    if (command[0] == "Add")
                    {
                        matr[r][c] += value;
                    }
                    else
                    {
                        matr[r][c] -= value;
                    }
                }

                command = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var row in matr)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static bool IsValid(int i, int max)
        {
            return i >= 0 && i < max;
        }
    }
}
