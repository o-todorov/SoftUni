using System;
using System.Collections.Generic;
using System.Linq;

namespace Football.Team.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string[] input; ;

            while ((input = Console.ReadLine().Split(';'))[0] != "END")
            {
                try
                {
                    string command  = input[0];
                    string teamName = input[1].Trim();

                    if (command == "Team") 
                    {
                        teams.Add( new Team(teamName));
                    }
                    else
                    {
                        var team = Validators.ValidateNotNull(teams.FirstOrDefault(t => t.Name.Equals(teamName)),
                                                     $"Team {teamName} does not exist."); 

                        switch (command)
                        {
                            case "Add":
                                team.AddPlayer(MakePlayer(input[2..8]));
                                break;
                            case "Remove":
                                team.RemovePlayer(input[2]);
                                break;
                            case "Rating":
                                Console.WriteLine($"{team.Name} - {team.Rating}"); ;
                                break;
                            default:
                                break;
                        }
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static Player MakePlayer(string[] plInfo)
        {
            return new Player(plInfo[0], plInfo[1..6].Select(int.Parse).ToArray());
        }
    }
}
