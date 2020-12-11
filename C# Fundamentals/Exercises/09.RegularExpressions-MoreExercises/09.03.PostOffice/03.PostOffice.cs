using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _09._03.PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|");

            var capitals = Regex.Match(input[0], @"(?<=([#$%*&]))(?<caps>[A-Z]+)(?=\1)")
                                .Value;
            var numbers = Regex.Matches(input[1], @"(?:[6][5-9]|[7-8][0-9]|90):(?:[0][1-9]|[1-9][\d])")
                               .Select(n => n.Value)
                               .Distinct()
                               .ToDictionary(n => int.Parse(n.Substring(0, 2)), n => int.Parse(n.Substring(3, 2)));
            var words = Regex.Matches(input[2], @"[^\s\|]+")
                             .Select(n => n.Value)
                             .ToArray();

            foreach (var ch  in capitals)
            {
                int length = numbers[ch];

                var result = words.FirstOrDefault(w => w[0] == ch && w.Length == length + 1);
                if (result != null) Console.WriteLine(result);
            }
        }
    }
}
