using System;
using System.Globalization;

namespace _04._01.SmallestNumbers
{
    class Program
    {






        static void Main(string[] args)
        {
            int[] arr = new int[3];

            for (int i = 0; i < 3; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            printSmallestInt(arr);
        }

        private static void printSmallestInt(int[] arr)
        {
            int minInt = int.MaxValue;

            foreach (int i in arr)
            {
                if (i < minInt) minInt = i;
            }

            Console.WriteLine(minInt);
        }
    }
}