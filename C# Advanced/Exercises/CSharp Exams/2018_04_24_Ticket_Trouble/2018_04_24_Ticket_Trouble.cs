using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2018_04_24_Ticket_Trouble
{
    class Program
    {
        static void Main(string[] args)
        {
            var location = Console.ReadLine();
            var contents = Console.ReadLine();

            /*        string pattern = @"((?<opener>\[)|{)(?(opener)[^\[\]]*?|[^{}]*?)(?(opener){|\[)" + location +
            @"(?(opener)}|\])(?(opener)[^\[\]]*?|[^{}]*?)(?(opener){|\[)(?<seat>[A-Z][0-9]{1,2})(?(opener)}|\])(?(opener)[^\[\]]*?|[^{}]*?)(?(opener)\]|})";    */      // Author's solution

            string ticketPattern = @"{[^{}]*\[" + location + @"\][^{}]*\[([A-Z](\d{1,2}))\][^{}]*}|\[[^\[\]]*{" + location + @"}[^\[\]]*{([A-Z](\d{1,2}))}[^\[\]]*\]";

            var tickets = new Regex(ticketPattern).Matches(contents)
                              .Select(m => m.Groups[1].Value != "" ?
                                    new KeyValuePair<string, string>(m.Groups[1].Value, m.Groups[2].Value) :
                                    new KeyValuePair<string, string>(m.Groups[3].Value, m.Groups[4].Value))
                              .ToArray();

            if (tickets.Count() > 2)
            {
                tickets = tickets.GroupBy(kvp => kvp.Value)
                               .Where(gr => gr.Count() == 2)
                               .First()
                               .ToArray();
            }

            Console.WriteLine($"You are traveling to {location} on seats {tickets[0].Key} and {tickets[1].Key}.");

        }
    }
}
