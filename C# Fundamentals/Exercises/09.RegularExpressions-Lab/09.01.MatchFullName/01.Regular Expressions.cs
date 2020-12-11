using System;
using System.Text.RegularExpressions;

namespace _09._01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(?<!\w)[A-Z][a-z]+ [A-Z][a-z]+";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, regex);

            foreach (var name in matches)
            {
                Console.Write(name + " ");
            }

            Console.WriteLine();
        }
    }
}
