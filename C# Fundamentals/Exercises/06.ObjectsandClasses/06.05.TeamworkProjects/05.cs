using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace _06._05.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            StringBuilder output = new StringBuilder("");

            for (int i = 0; i < teamsCount; i++)
            {
                string[] newTeam = Console.ReadLine().Split('-');

                if (GetTeamIndex(teams, newTeam[1]) != -1)
                {
                    output.AppendLine($"Team {newTeam[1]} was already created!");
                    continue;
                }

                if (MemberExist(teams, newTeam[0]))
                {
                    output.AppendLine($"{newTeam[0]} cannot create another team!");
                    continue;
                }

                teams.Add(new Team(newTeam[1], newTeam[0]));
                output.AppendLine($"Team {teams.Last().Name} has been created by {teams.Last().Creater}!");
            }

            string input;

            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] comm = input.Split("->").ToArray();

                string  user        = comm[0];
                string  teamName    = comm[1];
                int     teamIndex   = GetTeamIndex(teams, teamName);

                if (teamIndex == -1)
                {
                    output.AppendLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (MemberExist(teams, user))
                {
                    output.AppendLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                teams[teamIndex].Add(user);
            }

            foreach (var team in teams.Where(t => t.Count != 0)
                        .OrderByDescending  (t => t.Count)
                        .ThenBy             (t => t.Name))
            {
                output.Append(team.ToString());
            }

            output.AppendLine("Teams to disband:");

            foreach (var team in teams.Where(t => t.Count == 0)
                        .OrderBy (t => t.Name)
                        .ToList())
            {
                output.AppendLine(team.Name);
            }

            Console.WriteLine(output);
        }

        private static bool MemberExist(List<Team> teams, string member)
        {
            foreach (Team team in teams)
            {
                if (team.Contains(member) || team.Creater == member)
                {
                    return true;
                }
            }

            return false;
        }

        private static int GetTeamIndex(List<Team> teams, string teamName)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Name == teamName)
                {
                    return i;
                }
            }

            return -1;
        }

        class Team
        {
            public string Name { get; set; }
            public string Creater { get; set; }
            public int Count
            {
                get
                {
                    return this.members.Count;
                }
            }

            List<string> members;
            public Team(string _newName, string _newCreator)
            {
                this.Name = _newName;
                this.Creater = _newCreator;
                this.members = new List<string>();
            }

            public void Add(string _newMember)
            {
                members.Add(_newMember);
            }
            public bool Contains(string member)
            {
                return members.Contains(member);
            }
            override public  string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(Name);
                sb.Append("- ").AppendLine(Creater);
                members.Sort();
                members.ForEach(m => sb.Append("-- ").AppendLine(m));

                return sb.ToString();
            }


        }
    }
}
