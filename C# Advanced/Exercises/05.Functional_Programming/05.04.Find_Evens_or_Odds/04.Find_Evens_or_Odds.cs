using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace _05._04.Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> IsEven   = i => i % 2 == 0;
            Func<int, bool> IsOdd    = i => i % 2 != 0;

            int[] arr = Console.ReadLine()
                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToArray();

            Func<int, bool> isValid = (Console.ReadLine().Trim() == "even") ? IsEven : IsOdd;

            List<int> nums = new List<int>();

            for (int i = arr[0]; i <= arr[1]; i++)
            {
                nums.Add(i);
            }

            Console.WriteLine(string.Join(" ", nums.Where(isValid)));
        }
    }
}
