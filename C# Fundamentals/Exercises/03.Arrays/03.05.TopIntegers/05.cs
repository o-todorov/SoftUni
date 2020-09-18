using System;
using System.Linq;

namespace _03._05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] helperArr = new int[arr.Length];
            int currSize = 0;
            int maxVal = int.MinValue;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] > maxVal)
                {
                    maxVal = arr[i];
                    helperArr[currSize] = maxVal;
                    currSize++;
                }
            }

            for (int i = currSize-1; i >= 0; i--)
            {
                Console.Write($"{helperArr[i]} ");
            }


        }
    }
}
