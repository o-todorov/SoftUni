using System;
using System.Collections.Generic;

namespace _07._02.WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Dictionary<string, List<string>>();

            int num = int.Parse(Console.ReadLine());

            while (num-- > 0)
            {
                var word = Console.ReadLine();

                if (!map.ContainsKey(word))
                {
                    map[word] = new List<string>();
                }

                map[word].Add(Console.ReadLine());
            }

            foreach (var pair in map)
            {
                Console.WriteLine($"{pair.Key} - {string.Join(", ", pair.Value)}");
            }


        }
    }
}
