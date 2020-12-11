using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _09._04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            var planets = new List<Planet>();

            int messagesCount = int.Parse(Console.ReadLine());
            string regexCount = @"(?i)[star]";

            for (int i = 0; i < messagesCount; i++)
            {
                string input    = Console.ReadLine();
                int offset      = Regex.Matches(input, regexCount).Count;
                string decrypted = new string(input.Select(ch => (char)(ch - offset)).ToArray());

                string regexSplit = @"@(?<name>[a-zA-Z]+)[^@:!\->]*:(?<popul>\d+)[^@:!\->]*!(?<stat>[AD])![^@:!\->]*->(?<soldiers>\d+)";
                var match = Regex.Match(decrypted, regexSplit);

                if (match.Success)
                {
                    Planet planet       = new Planet();
                    planet.Name         = match.Groups["name"].Value;
                    planet.Population   = int.Parse(match.Groups["popul"].Value);
                    planet.Status       = match.Groups["stat"].Value[0];
                    planet.SoldiersCount = int.Parse(match.Groups["soldiers"].Value);
                    planets.Add(planet);
                }
            }

            var outList = planets.Where(p => p.Status == 'A')
                                .OrderBy(p => p.Name)
                                .ToList();
            Console.WriteLine($"Attacked planets: {outList.Count()}");
            outList.ForEach(p => Console.WriteLine($"-> {p.Name}"));

            outList = planets.Where(p => p.Status == 'D')
                            .OrderBy(p => p.Name)
                            .ToList();
            Console.WriteLine($"Destroyed planets: {outList.Count()}");
            outList.ForEach(p => Console.WriteLine($"-> {p.Name}"));
        }
    }

    class Planet
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public char Status { get; set; }
        public int SoldiersCount { get; set; }
    }
}
