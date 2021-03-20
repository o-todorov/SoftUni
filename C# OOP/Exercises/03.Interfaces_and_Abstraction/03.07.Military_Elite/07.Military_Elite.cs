
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            var army = new Dictionary<string, ISoldier>();
            string[] info;

            while ((info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries))[0]
                                             .ToLower() != "end")
            {
                string rank = info[0];
                string id   = info[1];
                string firstName   = info[2];
                string lastName   = info[3];

                switch (rank)
                {
                    case "Private":
                                // "Private <id> <firstName> <lastName> <salary>
                        army.Add(id, new Private(id, firstName, lastName, decimal.Parse(info[4])));
                        break;
                    case "LieutenantGeneral":
                                // LieutenantGeneral <id> <firstName> <lastName> <salary> <private1Id> <private2Id> … <privateNId>
                        var lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, decimal.Parse(info[4]));
                        lieutenantGeneral.Privates = info[5..].Select(i => army[i]).ToList();
                        army[id] = lieutenantGeneral;
                        break;
                    case "Engineer":
                                // Engineer <id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>
                        var engineer = new Engineer(id, firstName, lastName, decimal.Parse(info[4]));
                        Corps corps;

                        if (Enum.TryParse(info[5], out corps))
                        {

                            engineer.Corps = corps;
                            var repairs = info[6..];

                            for (int i = 0; i < repairs.Length; i += 2)
                            {
                                engineer.AddRepair(repairs[i], int.Parse(repairs[i + 1]));
                            }

                            army[id] = engineer;
                        }
                        break;
                    case "Commando":
                                // Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  
                                // <mission1state> … <missionNCodeName> <missionNstate>
                        var commando = new Commando(id, firstName, lastName, decimal.Parse(info[4]));

                        if (Enum.TryParse(info[5], out corps))
                        {
                            commando.Corps = corps;

                            var missions = info[6..];

                            for (int i = 0; i < missions.Length; i += 2)
                            {
                                commando.AddMission(missions[i], missions[i + 1]);
                            }

                            army[id] = commando;
                        }
                        break;
                    case "Spy":
                                // Spy <id> <firstName> <lastName> <codeNumber>
                        var spy = new Spy(id, firstName, lastName, int.Parse(info[4]));
                        army[id] = spy;
                        break;
                    default:
                        break;
                }
            }

            army.Values.ToList().ForEach(Console.WriteLine);
        }
    }
}
