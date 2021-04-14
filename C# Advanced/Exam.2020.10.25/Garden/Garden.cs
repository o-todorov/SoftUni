using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Garden
    {
        static void Main(string[] args)
        {

            int[] arr = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse).ToArray();
            int rows = arr[0];
            int cols = arr[1];
            int[][] field = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                field[i] = new int[cols];
            }

            string input;
            Queue<Tuple<int, int>> flowers = new Queue<Tuple<int, int>>();

            while ((input=Console.ReadLine().Trim())!= "Bloom Bloom Plow")
            {
                var ar = input.Split().Select(int.Parse).ToArray();
                int row = ar[0];
                int col = ar[1];

                if( CoordinatesOutOfField(row, col, rows, cols))
                {
                    continue;
                }

                flowers.Enqueue(new Tuple<int, int>(row, col));

            }

            while (flowers.Count > 0)
            {
                var flower = flowers.Dequeue();
                Bloom(flower, field, rows, cols);
            }

            PrintField(field);
        }

        private static void Bloom(Tuple<int, int> flower, int[][] field, int rows, int cols)
        {
            for (int i = 0; i < cols; i++)
            {
                field[flower.Item1][i]++;
            }

            for (int i = 0; i < rows; i++)
            {
                field[i][flower.Item2]++;
            }

            field[flower.Item1][flower.Item2]--;

        }

        private static void PrintField(int[][] field)
        {
            foreach (var row in field)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static bool CoordinatesOutOfField(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
            {
                Console.WriteLine("Invalid coordinates.");
                return true;
            }
            return false;
        }
    }
}
