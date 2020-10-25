using System;
using System.Collections.Generic;

namespace _07._01.CharsCountInSring
{
    class Program
    {
        static void Main(string[] args)
        {
            var charArr = Console.ReadLine().Replace(" ", "").ToCharArray();

            var charMap = new Dictionary<char, int>();

            foreach (var ch in charArr)
            {
                if (charMap.ContainsKey(ch))
                {
                    charMap[ch]++;
                }
                else
                {
                    charMap[ch] = 1;
                }
            }

            foreach (var pair in charMap)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
