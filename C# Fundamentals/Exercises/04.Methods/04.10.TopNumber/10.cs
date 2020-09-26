using System;

namespace _04._10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 17; i < num; i++)
            {
                if (isTopNum(i)) Console.WriteLine(i);
            }

        }

        private static bool isTopNum(int num)
        {
            int digitsSum = 0;
            bool res = false;

            while (num != 0)
            {
                int d = num % 10;
                if (d % 2 != 0) res = true;
                digitsSum += d;
                num /= 10;
            }

            return res == true && (digitsSum % 8 )== 0;

        }
    }
}
