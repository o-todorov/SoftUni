using System;

namespace _04._05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[3];

            for (int i = 0; i < 3; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(substract(sumInt(nums[0], nums[1]), nums[2]));

        }

        private static int substract(int sum, int v)
        {
            return sum - v;
        }

        private static int sumInt(int v1, int v2)
        {
            return v1 + v2;
        }

    }
}
