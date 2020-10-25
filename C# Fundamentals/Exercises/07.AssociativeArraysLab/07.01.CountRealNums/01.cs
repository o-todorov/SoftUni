using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _07._01.CountRealNums
{
    class Program
    {
        static void Main(string[] args)
        {
            double[]nums = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> map = new SortedDictionary<double, int>();


            foreach (var d in nums)
            {
                if (map.ContainsKey(d))
                {
                    map[d]++;
                }
                else
                {
                    map[d] = 1;
                }
            }

            foreach (var item in map)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
