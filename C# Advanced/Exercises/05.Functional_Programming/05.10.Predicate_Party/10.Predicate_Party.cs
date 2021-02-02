/* Ivancho’s parents are on a vacation for the holidays and he is planning an epic party at home. Unfortunately, his organizational skills are next to non-existent, so you are given the task to help him with the reservations.
On the first line, you receive a list with all the people that are coming. On the next lines, until you get the "Party!" command, you may be asked to double or remove all the people that apply to a given criteria. There are three different criteria: 
    • Everyone that has his name starting with a given string
    • Everyone that has a name ending with a given string
    • Everyone that has a name with a given length.
Finally, print all the guests who are going to the party separated by ", " and then add the ending "are going to the party!". If there are no guests going to the party print "Nobody is going to the party!". See the examples below:*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._10.Predicate_Party
{
    class Program
    {
        public delegate bool Filter(string name);

        static void Main(string[] args)
        {
            string[] peapleComming = Console.ReadLine()
                           .Split(' ',StringSplitOptions.RemoveEmptyEntries);

            string[] command = Console.ReadLine()
                           .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0].ToLower() != "party!")
            {

                Filter isInFilter = MakeFilter(command[1], command[2]);

                if (command[0] == "Remove")
                {
                    peapleComming = peapleComming.Where(n => !isInFilter(n)).ToArray();
                }
                else if (command[0] == "Double")
                {
                    var list = new List<string>();
                    peapleComming.ToList()
                                 .ForEach(name => 
                                 { 
                                     list.Add(name);
                                     if (isInFilter(name)) list.Add(name);
                                 });
                    peapleComming = list.ToArray();
                }

                    command = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            if (peapleComming.Length == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", peapleComming) + " are going to the party!");
            }
        }

        private static Filter MakeFilter(string criteria, string value)
        {
            Filter result = name => name.Equals(name);

            if (criteria == "StartsWith")
            {
                result = name => name.StartsWith(value);
            }else if (criteria == "EndsWith")
            {
                result = name => name.EndsWith(value);
            }
            else if (criteria == "Length")
            {
                result = name => name.Length == int.Parse(value);
            }

            return result;
        }
    }
}
