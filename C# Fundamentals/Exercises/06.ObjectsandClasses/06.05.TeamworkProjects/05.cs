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
            int             teamsCount  = int.Parse(Console.ReadLine());
            List<Team>      teams       = new List<Team>();
            StringBuilder   output      = new StringBuilder("");

            for (int i = 0; i < teamsCount; i++)
            {
                string[] newTeam    = Console.ReadLine().Split('-');
                string   teamName   = newTeam[1];
                string   creator    = newTeam[0];

                if (teams.FindIndex(t=>t.Name== teamName) != -1)
                {
                    output.AppendLine($"Team {teamName} was already created!");
                }
                else if (MemberExist(teams, creator))
                {
                    output.AppendLine($"{creator} cannot create another team!");
                }
                else
                {
                    teams.Add(new Team(teamName, creator));

                    output.AppendLine($"Team {teams.Last().Name} has been created by {teams.Last().Creater}!");
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] comm = input.Split("->").ToArray();

                string  user        = comm[0];
                string  teamName    = comm[1];
                int     teamIndex   = teams.FindIndex(t => t.Name == teamName);

                if (teamIndex == -1)
                {
                    output.AppendLine($"Team {teamName} does not exist!");
                }
                else if (MemberExist(teams, user))
                {
                    output.AppendLine($"Member {user} cannot join team {teamName}!");
                }
                else
                {
                    teams[teamIndex].Add(user);
                }
            }

            foreach (var team in teams  .Where(t => t.Count != 0)
                                        .OrderByDescending  (t => t.Count)
                                        .ThenBy             (t => t.Name))
            {
                output.Append(team.ToString());
            }

            output.AppendLine("Teams to disband:");

            teams.Where(t => t.Count == 0)
                .OrderBy (t => t.Name)
                .ToList()
                .ForEach(t=>output.AppendLine(t.Name));
            

            Console.WriteLine(output.ToString());
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

        class Team
        {
            public string   Name { get; set; }
            public string   Creater { get; set; }
            List<string>    members;

            public int      Count
            {
                get
                {
                    return this.members.Count;
                }
            }

            public Team(string _newName, string _newCreator)
            {
                this.Name       = _newName;
                this.Creater    = _newCreator;
                this.members    = new List<string>();
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
                sb.AppendLine(Name).Append("- ").AppendLine(Creater);
                members.Sort();
                members.ForEach(m => sb.Append("-- ").AppendLine(m));

                return sb.ToString();
            }


        }
    }
}
