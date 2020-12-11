using System;
using System.Text.RegularExpressions;

namespace _09._03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b(?<day>((0|1|2)\d)|3(0|1))([-.\/])(?<month>[JFMASOND][a-z]{2})\4(?<year>\d{4})\b";
            string input = Console.ReadLine();
            MatchCollection dates = Regex.Matches(input, regex);

            foreach (Match date in dates)
            {
                var day     = date.Groups["day"].Value;
                var month   = date.Groups["month"].Value;
                var year    = date.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }

        }
    }
}
