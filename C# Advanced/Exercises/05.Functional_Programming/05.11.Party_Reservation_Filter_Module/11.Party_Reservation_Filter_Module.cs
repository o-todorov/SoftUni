// You need to implement a filtering module to a party reservation software. First, to the Party Reservation Filter Module (PRFM for short) is passed a list with invitations. Next the PRFM receives a sequence of commands that specify whether you need to add or remove a given filter.
// Each PRFM command is in the given format:
// "{command;filter type;filter parameter}"

using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._11.Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] invited = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            string[] command = Console.ReadLine()
                           .Split(';', StringSplitOptions.RemoveEmptyEntries);
            var predicatesDict = new Dictionary<string, Func<string, bool>>();

            while (command[0].ToLower() != "print")
            {
                string predicateKey = string.Concat(command[1], command[2]);

                if (command[0] == "Add filter")
                {
                    predicatesDict.Add(predicateKey, MakeValidFilter(command[1], command[2]));
                }
                else if (command[0] == "Remove filter")
                {
                    predicatesDict.Remove(predicateKey);
                }

                command = Console.ReadLine()
                       .Split(';', StringSplitOptions.RemoveEmptyEntries);
            }

            invited = GetFiltered(invited, predicatesDict);

            Console.WriteLine(string.Join(" ", invited));

        }

        private static string[] GetFiltered(string[] invited, Dictionary<string, Func<string, bool>> predicates)
        {
            predicates.Values
                      .ToList()
                      .ForEach(filter => invited = invited.Where(name => filter(name)).ToArray());
            return invited;
        }

        private static Func<string, bool> MakeValidFilter(string criteria, string value)
        {
            Func<string, bool> result;

            if (criteria == "Starts with")
            {
                result = name => !name.StartsWith(value);
            }
            else if (criteria == "Ends with")
            {
                result = name => !name.EndsWith(value);
            }
            else if (criteria == "Contains")
            {
                result = name => !name.Contains(value);
            }
            else if (criteria == "Length")
            {
                result = name => !(name.Length == int.Parse(value));
            }
            else
            {
                Console.WriteLine("Invalid data");
                result = null;
            }

            return result;
        }
    }
}
