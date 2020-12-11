using System;
using System.Text.RegularExpressions;

namespace _09._06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string rgxEmailPattern = @"(?<=[ ,])[a-zA-Z0-9]+([.\-_][a-zA-Z0-9]+)*@[a-zA-Z]+([\.-][a-zA-Z]+)*(?=\.[a-zA-Z])(\.[a-zA-Z]+)";
            string input = Console.ReadLine();

            foreach (Match email in Regex.Matches(input,rgxEmailPattern))
            {
                Console.WriteLine(email.Value);
            }

        }
    }
}
