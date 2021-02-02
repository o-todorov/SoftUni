// Write a program that reverses a collection and removes elements that are divisible by a given integer n. Use predicates/functions.

using System;
using System.Linq;

namespace _05._06.Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> indivisibleByN = (x, n) => x % n != 0;

            var nums = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse);

            int divider = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", nums.Where(x => indivisibleByN(x, divider)).Reverse()));

        }
    }
}
