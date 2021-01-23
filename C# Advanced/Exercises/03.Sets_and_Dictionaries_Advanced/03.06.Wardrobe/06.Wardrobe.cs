using System;
using System.Collections.Generic;

namespace _03._06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int clothesNumber = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            string color;

            for (int i = 0; i < clothesNumber; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
                color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                foreach (var cloth in input[1].Split(","))
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color][cloth] = 1;
                    }
                    else
                    {
                        wardrobe[color][cloth]++;
                    }
                }



            }

            string[] clothesToFind = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            color           = clothesToFind[0];
            string clothes  = clothesToFind[1];

            foreach (var clr in wardrobe)
            {
                Console.WriteLine($"{clr.Key} clothes:");

                foreach (var dress in clr.Value)
                {
                    Console.Write($"* {dress.Key} - {dress.Value}");

                    if (clr.Key == color && dress.Key == clothes)
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }

        }
    }
}
