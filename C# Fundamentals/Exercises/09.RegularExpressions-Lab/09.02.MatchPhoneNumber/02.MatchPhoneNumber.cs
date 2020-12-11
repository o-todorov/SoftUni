using System;
using System.Text.RegularExpressions;

namespace _09._02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(?<= |^)\+359( |-)2\1\d{3}\1\d{4}\b";
            string input = Console.ReadLine();
            MatchCollection phones = Regex.Matches(input, regex);

            Console.WriteLine(string.Join(", ",phones));

        }
    }
}
