using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string message = Console.ReadLine();
                string rgxValid = @"^([$%])(?<tag>[A-z][a-z]{2,})\1\:[ ]{1}([^\[]*\[(?<num>\d+)\]\|){3}$";

                Match match = Regex.Match(message,rgxValid);

                if (match.Success)
                {
                    char[] res = match.Groups["num"]
                                      .Captures.Select(c => (char)int.Parse(c.Value))
                                      .ToArray();

                    Console.WriteLine($"{match.Groups["tag"].Value}: {string.Join("",res)}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
                int c=5 ,b = 6;
                int a = c > b ? 1 : 2;
                c = b;
            }
        }
    }
}
