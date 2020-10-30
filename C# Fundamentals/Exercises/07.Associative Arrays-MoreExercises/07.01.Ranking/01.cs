using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var users       = new SortedDictionary<string, User>();
            var contPasses    = new Dictionary<string, string>();
            string[] input;

            while ((input = Console.ReadLine().Split(":"))[0] != "end of contests")
            {
                contPasses[input[0]] = input[1];
            }

            while ((input = Console.ReadLine().Split("=>"))[0] != "end of submissions")
            {
                string  contest     = input[0];
                string  pass        = input[1];
                string  userName    = input[2];
                int     pts         = int.Parse(input[3]);

                if(contPasses.ContainsKey(contest) && contPasses[contest] == pass)
                {
                    if (users.ContainsKey(userName))
                    {
                        users[userName].AddContest(contest, pts);
                    }
                    else
                    {
                        users[userName] = new User(userName, contest, pts);
                    }
                }
            }

            User user = users.OrderByDescending(u => u.Value.GetPoints)
                             .First()
                             .Value;

            Console.WriteLine($"Best candidate is {user.Name} with total {user.GetPoints} points.");

            Console.WriteLine("Ranking:");

            foreach (var usr in users.Select(u => u.Value.ToString()))
            {
                Console.Write(usr);
            }
        }
    }

    class User
    {
        public User(string name, string contest, int points)
        {
            Name = name;
            this.contests = new Dictionary<string, int>() { { contest, points } };
        }

        private Dictionary<string, int> contests;
        public string Name;

        public int GetPoints
        {
            get
            {
                return contests.Values.Sum();
            }
        }

        public void AddContest(string contest, int points)
        {
            if (contests.ContainsKey(contest))
            {
                contests[contest] = Math.Max(contests[contest], points);
            }
            else
            {
                contests[contest] = points;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Name);

            foreach (var cont in contests.OrderByDescending(c=>c.Value))
            {
                sb.AppendLine($"#  {cont.Key} -> {cont.Value}");
            }

            return sb.ToString();
        }
    }
}
