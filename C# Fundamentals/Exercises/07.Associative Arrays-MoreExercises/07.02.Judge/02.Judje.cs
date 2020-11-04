using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, Dictionary<string, int>>();

            string[] input;

            while ((input = Console.ReadLine().Split(" -> "))[0].ToLower() != "no more time")
            {
                string  user    = input[0];
                string  contest = input[1];
                int     pts     = int.Parse(input[2]);

                if (!contests.ContainsKey(contest))
                {
                    contests[contest] = new Dictionary<string, int>() { { user, pts } };
                }
                else if (!contests[contest].ContainsKey(user))
                {
                    contests[contest][user] = pts;
                }
                else
                {
                    if (pts > contests[contest][user]) contests[contest][user] = pts;
                }
            }

            var users = new List<KeyValuePair<string, int>>();

            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                int counter = 0;

                foreach (var user in contest.Value.OrderByDescending(u=>u.Value).ThenBy(u=>u.Key))
                {
                    Console.WriteLine($"{++counter}. {user.Key} <::> {user.Value}");
                    users.Add(user);
                }
            }

            Console.WriteLine("Individual standings:");

            var finalDict = users.GroupBy(u => u.Key)
                                 .ToDictionary(g => g.Key, g => g.Select(u => u.Value).Sum())
                                 .OrderByDescending(u => u.Value)
                                 .ThenBy(u => u.Key);

            int position = 0;

            foreach (var user in finalDict)
            {
                Console.WriteLine($"{++position}. {user.Key} -> {user.Value}");
            }
        }
   }
}
