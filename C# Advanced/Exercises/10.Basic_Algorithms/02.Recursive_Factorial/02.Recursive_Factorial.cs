using System;

namespace _02.Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            long fact = Recursive_Factorial(num);
            Console.WriteLine(fact);
        }

        private static long Recursive_Factorial(int num)
        {
            if (num == 1)
            {
                return 1;
            }

            return num * Recursive_Factorial(num - 1);
        }
    }
}
