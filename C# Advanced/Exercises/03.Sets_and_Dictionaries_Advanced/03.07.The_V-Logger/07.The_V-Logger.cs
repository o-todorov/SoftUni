using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._07.The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();

            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            while (input[0].ToLower()!="statistics")
            {
                string vloggerA = input[0];

                if(input[1]== "joined")
                {
                    if (!vloggers.ContainsKey(vloggerA))
                    {
                        vloggers.Add(vloggerA, new Vlogger() { Name = vloggerA });
                    }
                }
                else if (input[1] == "followed")
                {
                    string vloggerB = input[2];

                    if (vloggers.ContainsKey(vloggerA) && vloggers.ContainsKey(vloggerB))
                    {
                        if (!vloggerA.Equals(vloggerB) && vloggers[vloggerB].Followers.Add(vloggerA))
                        {
                            vloggers[vloggerA].FollowingCount++;
                        }
                    }
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var res = vloggers.OrderByDescending(v => v.Value.Followers.Count)
                              .ThenBy(v => v.Value.FollowingCount)
                              .ThenBy(v => v.Key)
                              .Select(v => v.Value);

            var vlogger = res.First();

            Console.WriteLine($"1. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.FollowingCount} following");

            foreach (var follower in vlogger.Followers)
            {
                Console.WriteLine($"*  {follower}");
            }

            int counter = 2;

            foreach (var vl in res.Skip(1))
            {
                Console.WriteLine($"{counter++}. {vl.Name} : {vl.Followers.Count} followers, {vl.FollowingCount} following");
            }

        }
    }

    class Vlogger
    {
        public string Name;
        public SortedSet<string> Followers = new SortedSet<string>();
        public int FollowingCount = 0;
    }
}
