using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split('|')
                                    .ToArray();


            List<int> result = new List<int>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                result.AddRange(input[i]
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray());
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
