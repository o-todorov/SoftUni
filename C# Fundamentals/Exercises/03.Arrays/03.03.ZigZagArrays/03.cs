using System;
using System.Linq;

namespace _03._03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[] a = new int[size];
            int[] b = new int[size];

            bool aFirst = true;

            for (int i = 0; i < size; i++)
            {
                int[] curr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                if (aFirst)
                {
                    a[i] = curr[0];
                    b[i] = curr[1];
                    aFirst = false;
                }
                else
                {
                    a[i] = curr[1];
                    b[i] = curr[0];
                    aFirst = true;
                }
            }

            Console.WriteLine(string.Join(" ",a));
            Console.WriteLine(string.Join(" ",b));

        }
    }
}
