using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _09._02.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            input = Regex.Replace(input, @"[a-z]+", m => m.Value.ToUpper());

            string rgxSplit = @"(\D+)(\d+)"; // group 1 - letters, group 2 - numbers
            var regex   = new Regex(rgxSplit);
            var matches = regex.Matches(input);
            var hset    = new HashSet<char>();
            var sb      = new StringBuilder();

            foreach (Match match in matches)
            {
                int count = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < count; i++)
                {
                    sb.Append(match.Groups[1].Value);
                }

                if (count == 0) continue;
                foreach (char ch in match.Groups[1].Value) hset.Add(ch);
            }

            Console.WriteLine($"Unique symbols used: {hset.Count}");
            Console.WriteLine(sb);

        }
    }
}