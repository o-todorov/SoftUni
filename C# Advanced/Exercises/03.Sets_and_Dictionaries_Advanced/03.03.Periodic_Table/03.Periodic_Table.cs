using System;
using System.Collections.Generic;

namespace _03._03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int comproundCount = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < comproundCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in input)
                {
                    elements.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ",elements));

        }
    }
}
