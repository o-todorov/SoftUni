using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _09._04.SantasSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int code = int.Parse(Console.ReadLine());
            string input;
            Regex regex = new Regex(@"@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<behaviour>[GN]!)");
            Match match;

            while ((input=Console.ReadLine())!="end")
            {
                var decoded =input.Select(ch =>(char) (ch - code)).ToArray();
                match = regex.Match(new string(decoded));

                if (match.Success&& match.Groups["behaviour"].Value[0]=='G')
                {
                    Console.WriteLine($"{match.Groups["name"].Value}");
                }
            }
        }
    }
}
