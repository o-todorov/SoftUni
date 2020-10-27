using System;
using System.Collections.Generic;

namespace _07._08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var companies = new SortedDictionary<string, List<string>>();

            string[] input;

            while ((input = Console.ReadLine().Split(" -> "))[0] != "End")
            {
                string compName = input[0];
                string empID    = input[1];
                
                if (companies.ContainsKey(compName))
                {
                    if (!companies[compName].Contains(empID))
                    {
                        companies[compName].Add(empID);
                    }
                }
                else
                {
                    companies[compName] = new List<string>() { empID };
                }
            }

            foreach (var comp in companies)
            {
                Console.WriteLine($"{comp.Key}");

                comp.Value.ForEach(c => Console.WriteLine($"-- {c}"));
            }


        }
    }
}
