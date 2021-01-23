using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string[] input;

            while ((input = Console.ReadLine().Split(":"))[0] != "end of contests")
            {
                string contest  = input[0];
                string password = input[1];
                contests[contest] = password;
            }

            Dictionary<string, Dictionary<string,int>> users = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine().Split("=>"))[0] != "end of submissions")
            {
                string contest  = input[0];
                if (!contests.ContainsKey(contest)) continue;
                string password = input[1];
                if (contests[contest]!=password) continue;
                string username = input[2];
                int points = int.Parse(input[3]);

                if (users.ContainsKey(username))
                {
                    if (users[username].ContainsKey(contest))
                    {
                        if (users[username][contest] < points)
                        {
                            users[username][contest] = points;
                        }
                    }
                    else
                    {
                        users[username].Add(contest, points);
                    }
                }
                else
                {
                    users[username] = new Dictionary<string, int>() { { contest, points } };
                }
            }

            var res = users.ToDictionary(u => u.Key, u => u.Value.Values.Sum())
                            .OrderByDescending(u => u.Value);

            Console.WriteLine($"Best candidate is {res.First().Key} with total {res.First().Value} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in users.OrderBy(u=>u.Key))
            {
                Console.WriteLine($"{user.Key}");

                foreach (var contest in user.Value.OrderByDescending(c=>c.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }
    }
}
