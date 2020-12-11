using System;
using System.Text.RegularExpressions;

namespace _09._01.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            char[] symbols = { '@', '#', '$', '^' };

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                bool success = false;

                for (int i = 0; i < 4; i++)
                {
                    string rgx = $"[\\{symbols[i]}]{{6,10}}";

                    var matchLeft   = Regex.Match(ticket.Substring(0, 10), rgx);
                    var matchRight  = Regex.Match(ticket.Substring(10), rgx);

                    if (matchRight.Success && matchRight.Success)
                    {
                        success = true;

                        if (matchLeft.Length == 10 && matchRight.Length == 10)
                        {
                            Console.WriteLine($"ticket \"{ ticket}\" - {matchLeft.Length}{symbols[i]} Jackpot!");
                            break;
                        }
                        else
                        {
                            int minCount = Math.Min(matchLeft.Length, matchRight.Length);
                            Console.WriteLine($"ticket \"{ ticket}\" - {minCount}{symbols[i]}");
                            break;
                        }
                    }
                }

                if (!success)
                {
                    Console.WriteLine($"ticket \"{ ticket}\" - no match");
                }
            }
        }
    }
}

// (?=.{20}).*?(?=(?<ch>[@#$^]))(?<match>\k<ch>{6,}).*(?<=.{10})\k<match>.*   REGEX to validate the ticket