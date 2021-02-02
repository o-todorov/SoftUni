// Write a program that reverses a collection and removes elements that are divisible by a given integer n. Use predicates/functions.

using System;
using System.Linq;

namespace _05._06.Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse);

            int divider = int.Parse(Console.ReadLine());
            Func<int, bool> indivisibleByN = x => x % divider != 0;
            nums= nums.Where(indivisibleByN).Reverse();

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
