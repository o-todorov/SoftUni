using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, User> users = new Dictionary<string, User>();
            int capacity = int.Parse(Console.ReadLine());
            string[] input;

            while ((input = Console.ReadLine().Split("="))[0].ToLower() != "statistics")
            {
                switch (input[0].ToLower())
                {
                    case "add":
                        string  user        = input[1];
                        int     sent        = int.Parse(input[2]);
                        int     received    = int.Parse(input[3]);

                        if (!users.ContainsKey(user))
                        {
                            users[user] = new User(user, sent, received, capacity);
                        }
                        break;
                    case "message":
                        string sender   = input[1];
                        string receiver = input[2];

                        if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                        {
                            if (users[sender].AddLimitReached())
                            {
                                users.Remove(sender);
                                Console.WriteLine($"{sender} reached the capacity!");
                            }

                            if (users[receiver].ReceivedLimitReached())
                            {
                                users.Remove(receiver);
                                Console.WriteLine($"{receiver} reached the capacity!");
                            }
                        }
                        break;
                    case "empty":
                        user = input[1];

                        if (user.ToLower() == "all")
                        {
                            users.Clear();
                        }
                        else if(users.ContainsKey(user))
                        {
                            users.Remove(user);
                        }
                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine($"Users count: {users.Count}");

            users.Values
                 .OrderByDescending(v=>v.Received)
                 .ThenBy(v=>v.Name)
                 .ToList()
                 .ForEach(u => Console.WriteLine($"{u.Name} - {u.Sent+u.Received}"));
        }
    }

    class User
    {
        public string   Name { get; set; }
        public int      Sent { get; set; }
        public int      Received { get; set; }
        private int     limit;

        public User(string name, int sent, int received, int limit)
        {
            Name        = name;
            Sent        = sent;
            Received    = received;
            this.limit  = limit;
        }

        public bool AddLimitReached()
        {
            Sent++;
            return Sent + Received >= this.limit;
        }
        public bool ReceivedLimitReached()
        {
            Received++;
            return Sent + Received >= this.limit;
        }
    }
}
