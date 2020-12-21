using System;
using System.Linq;
using System.Text.RegularExpressions;

// Description: https://softwareuniversity-my.sharepoint.com/:w:/g/personal/ivet_atanasova_softuni_bg/EcOSWHFIWztAqt_4OsHGETYBxUiyoHeB1ozitGUQVjGSCQ?rtime=Be_PziOl2Eg

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
                string rgxValid = @"^([$%])(?<tag>[A-z][a-z]{2,})\1\:[ ]{1}([^\[]*\[(?<num>\d+)\]\|){3}(\n|$)";

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
            }
        }
    }
}
