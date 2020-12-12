using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input    = Console.ReadLine();
            string rgxEmoji = @"(::|\*\*)([A-Z][a-z]{2,})\1";
            string rgxNums  = @"[\d]";
            Regex regex     = new Regex(rgxNums);

            long coolThreshold = 1;
            regex.Matches(input).Select(n => int.Parse(n.Value))
                                .ToList()
                                .ForEach(i => coolThreshold *= i);
            Console.WriteLine($"Cool threshold: {coolThreshold}");

            regex = new Regex(rgxEmoji);
            var matches = regex.Matches(input);
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

            foreach(Match match in matches)
            {
                long coolness = match.Value.Substring(2, match.Length - 4)
                                  .Select(ch =>(int) ch)
                                  .Sum();

                if (coolness > coolThreshold) 
                {
                    Console.WriteLine($"{match.Value}");
                }
            }
        }
    }
}
