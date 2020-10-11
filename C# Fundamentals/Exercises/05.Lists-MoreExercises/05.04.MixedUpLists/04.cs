using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            List<int> secondList = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            if(secondList.Count>firstList.Count)
            {
                firstList.AddRange(secondList.GetRange( secondList.Count - 2, 2));
                secondList.RemoveRange(secondList.Count - 2, 2);
            }

            List<int> result = new List<int>();

            int idx = secondList.Count;

            for (int i = 0; i < idx; i++)
            {
                result.Add(firstList[i]);
                result.Add(secondList[idx - i - 1]);
            }

            result.Sort();

            int start   = Math.Min(firstList[idx], firstList[idx + 1]);
            int end     = Math.Max(firstList[idx], firstList[idx + 1]);

            Console.WriteLine(string.Join(" ", result.Where(c => c > start && c < end)));

        }
    }
}
