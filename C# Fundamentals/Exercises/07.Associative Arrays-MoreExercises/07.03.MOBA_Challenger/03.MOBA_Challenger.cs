using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._03.MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var         players = new Dictionary<string, Player>();
            string[]    input = Console.ReadLine().Split(new [] { " -> ", " vs " },StringSplitOptions.RemoveEmptyEntries);

            while (input[0].ToLower() != "season end")
            {
                string player = input[0];

                if (input.Length > 2)
                {
                    string  position    = input[1];
                    int     skills       = int.Parse(input[2]);

                    if (!players.ContainsKey(player))
                    {
                        players[player] = new Player(player, position, skills);
                    }
                    else
                    {
                        players[player].AddPosition(position, skills);
                    }
                }
                else
                {
                    string player2 = input[1];

                    if (players.ContainsKey(player) && players.ContainsKey(player2))
                    {
                        string looser;

                        if ((looser = Fight(players[player], players[player2])) != null)
                        {
                            players.Remove(looser);
                        }
                    }
                }

                input = Console.ReadLine().Split(new[] { " -> ", " vs " }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var player in players.OrderByDescending(p=>p.Value.TotalSkill)
                                          .ThenBy(p=>p.Key))
            {
                Console.Write(player.Value.ToString());
            }
        }

        private static string Fight(Player pl1, Player pl2)
        {
            bool toBattle = (pl1.Pool.Keys.Intersect(pl2.Pool.Keys).Count() > 0);
            string looser = null;

            if (toBattle)
            {
                looser = (pl1.TotalSkill > pl2.TotalSkill) ? pl2.Name : (pl2.TotalSkill > pl1.TotalSkill) ? pl1.Name:null;
            }

            return looser;
        }
    }

    class Player
    {
        public string   Name;
        public Dictionary<string, int> Pool;

        public Player(string name, string position, int skill)
        {
            Name = name;
            Pool = new Dictionary<string, int>() { { position, skill } };
        }

        public int TotalSkill
        {
            get
            {
                return Pool.Values.Sum();
            }
        }

        public void AddPosition(string position, int skill)
        {
            if (Pool.ContainsKey(position))
            {
                Pool[position] = Math.Max(Pool[position], skill);
            }
            else
            {
                Pool[position] =  skill;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Name}: {TotalSkill} skill");

            foreach (var pos in Pool.OrderByDescending(p=>p.Value)
                                    .ThenBy(p=>p.Key))
            {
                sb.AppendLine($"- {pos.Key} <::> {pos.Value}");
            }

            return sb.ToString();
        }
    }
}
