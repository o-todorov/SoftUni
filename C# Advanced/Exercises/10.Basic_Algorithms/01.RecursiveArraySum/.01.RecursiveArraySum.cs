using System;
using System.Linq;

namespace RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                       .Split(" ")
                       .Select(int.Parse)
                       .ToArray();
            int sum = CalculateSum(arr, 0);
            Console.WriteLine(sum);
        }

        private static int CalculateSum(int[] arr, int currIndex)
        {
            if (currIndex >= arr.Length)
            {
                return 0;
            }

            return arr[currIndex] + CalculateSum(arr, currIndex + 1);
        }
    }
}
