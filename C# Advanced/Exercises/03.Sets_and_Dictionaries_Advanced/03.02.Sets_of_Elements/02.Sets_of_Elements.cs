using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._02.Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                       .Split(" ")
                       .Select(int.Parse).ToArray();

            int sizeA = sizes[0];
            int sizeB = sizes[1];

            HashSet<int> setA = FillSet(sizeA);
            HashSet<int> setB = FillSet(sizeB);

            setA.IntersectWith(setB);
            Console.WriteLine(string.Join(" ", setA));
        }

        private static HashSet<int> FillSet(int setSize)
        {
            var set = new HashSet<int>();

            for (int i = 0; i < setSize; i++)
            {
                set.Add(int.Parse(Console.ReadLine()));
            }

            return set;
        }
    }
}
