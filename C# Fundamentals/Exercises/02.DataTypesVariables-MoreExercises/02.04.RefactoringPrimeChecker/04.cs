using System;

namespace _02._04.RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());

            for (int i = 2; i <= endNumber; i++)
            {
                bool isPrime = true;

                for (int divider = 2; divider < i; divider++)
                {
                    if (i % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine("{0} -> {1}", i, isPrime.ToString().ToLower());
            }


        }
    }
}
