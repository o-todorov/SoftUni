using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _09._02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = Console.ReadLine()
                                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                .ToDictionary(n => n, n => 0);
            string regexNumbers = @"\d";
            string regexNames = @"[A-Za-z]";
            string input;

            while ((input=Console.ReadLine())!= "end of race")
            {
                int km = Regex.Matches(input, regexNumbers).Select(i => int.Parse(i.Value)).Sum();
                string playerName = new string(Regex.Matches(input, regexNames)
                                                    .Select(n =>n.Value.First()).ToArray());
                if (players.ContainsKey(playerName)) players[playerName] += km;
            }

            var final = players.OrderByDescending(p => p.Value)
                               .Take(3)
                               .Select(p=>p.Key)
                               .ToList();
            string[] prefix = new string[3] { "1st", "2nd", "3rd" };

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{prefix[i]} place: {final[i]}");
            }
        }
    }
}
