using System;

namespace _04._08.Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {

            ulong a = ulong.Parse(Console.ReadLine());
            ulong b = ulong.Parse(Console.ReadLine());

            double divided = (double)getFactorial(a) / getFactorial(b);

            Console.WriteLine($"{divided:f2}");
        }

        private static ulong getFactorial(ulong a)
        {
            ulong res = 1;

            for (ulong i = 1; i <= a; i++)
            {
                res *= i;
            }
            return res;
        }
    }
}
