using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._04.MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, char> dict = new Dictionary<string, char>()
            {
                {".-",'A' },    {"-...",'B' },  {"-.-.",'C' },  {"-..",'D' },   {".",'E' },     {"..-.",'F' },
                {"--.",'G' },   {"....",'H' },  {"..",'I' },    {".---",'J' },  {"-.-",'K' },   {".-..",'L' },
                {"--",'M' },    {"-.",'N' },    {"---",'O' },   {".--.",'P' },  {"--.-",'Q' },  {".-.",'R' },
                {"...",'S' },   {"-",'T' },     {"..-",'U' },   {"...-",'V' },  {".--",'W' },   {"-..-",'X' },
                {"-.--",'Y' },  {"--..",'Z' }
            };

            foreach (var word in words) 
            {
                var w = new string(word.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(ch => dict[ch])
                            .ToArray());

                Console.Write(w);
                Console.Write(" ");
            }
        }
    }
}
