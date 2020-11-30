using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace _07._03.MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var         players = new Dictionary<string, Player>();
            string[]    input;

            while ((input = Console.ReadLine().Split())[0].ToLower() != "season")
            {
                string player = input[0];

                if (input.Length > 3)
                {
                    input = input.Where(s => s != "->").ToArray();
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
                    string player1 = input[2];

                    if (players.ContainsKey(player) && players.ContainsKey(player1))
                    {
                        string looser;

                        if ((looser = Fight(players[player], players[player1])) != null)
                        {
                            players.Remove(looser);
                        }
                    }
                }
            }

            foreach (var player in players.OrderByDescending(p=>p.Value.TotalSkill)
                                          .ThenBy(p=>p.Key))
            {
                Console.Write(player.Value.ToString());
            }
        }

        private static string Fight(Player pl, Player pl1)
        {
            bool toBattle = false;

            foreach (var position in pl.Pool)
            {
                if (pl1.Pool.ContainsKey(position.Key))
                {
                    toBattle = true;
                    break;
                }
            }

            if (toBattle)
            {
                if (pl.TotalSkill > pl1.TotalSkill)
                {
                    return pl1.Name;
                }else if (pl1.TotalSkill > pl.TotalSkill)
                {
                    return pl.Name;
                }
            }

            return null;
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
