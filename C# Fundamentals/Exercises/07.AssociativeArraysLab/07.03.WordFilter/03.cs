using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _07._03.WordOddOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            string[] words = Console.ReadLine()
                    .Split()
                    .Select(s => s = s.ToLower())
                    .ToArray();

            foreach (var word in words)
            {
                if (!map.ContainsKey(word)) map[word] = 0;

                map[word]++;
            }

            Console.WriteLine(string.Join(" ", map.Where(p => p.Value % 2 != 0).Select(p=>p.Key)));
            
        }
    }
}
