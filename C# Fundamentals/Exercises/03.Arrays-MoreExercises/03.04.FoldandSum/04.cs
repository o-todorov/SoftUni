using System;
using System.Linq;

namespace _03._04.FoldandSum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int step = arr.Length / 4;

            for (int i = step, j = step - 1; i < step * 2; i++, j--)
            {
                Console.Write($"{arr[i] + arr[j]} ");
            }

            for (int i = step * 2, j = arr.Length - 1; i < step * 3; i++, j--)
            {
                Console.Write($"{arr[i] + arr[j]} ");
            }

            Console.WriteLine();
        }
    }
}
