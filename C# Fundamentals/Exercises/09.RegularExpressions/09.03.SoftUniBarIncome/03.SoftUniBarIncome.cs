using System;
using System.Text.RegularExpressions;

namespace _09._03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexValidate = @"%([A-Z][a-z]*)%.*<(\w+)>.*\|(\d+)\|\D*(\d+(\.\d+)*)\$";
            double total = 0.00;
            string input;

            while ((input=Console.ReadLine())!= "end of shift")
            {
                var match = Regex.Match(input, regexValidate);

                if (match.Groups.Count> 1)
                {
                    double itemPrice = double.Parse(match.Groups[3].Value) *
                                       double.Parse(match.Groups[4].Value);
                    Console.WriteLine($"{match.Groups[1].Value}: {match.Groups[2].Value} - {itemPrice:f2}");
                    total += itemPrice;
                }
            }

            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}
