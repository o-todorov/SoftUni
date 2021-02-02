// Write a program that filters a list of names according to their length. On the first line, you will be given an integer n, representing a name's length. On the second line, you will be given some names as strings separated by space. Write a function that prints only the names whose length is less than or equal to n.

using System;
using System.Linq;

namespace _05._08.Custom_Comparator
{

    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> IsEven   = i => i % 2 == 0;

            Func<int, int, int> lessEvenOdd = (a, b) =>
               {
                   return (IsEven(a) && !IsEven(b) || IsEven(a) == IsEven(b) && (a < b))
                            ? -1 : 1;
               };

            var nums = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

            Array.Sort(nums, (a, b) => lessEvenOdd(a, b));
            Console.WriteLine(string.Join(" ", nums));
        }

    }
}
