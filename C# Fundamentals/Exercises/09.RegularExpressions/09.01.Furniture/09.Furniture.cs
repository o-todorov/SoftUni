using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _09._01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            string input;

            while ((input = Console.ReadLine())!= "Purchase")
            {
                sb.Append(input);
            }

            string regex = @">>(?<name>\w+)<<(?<price>\d+\.*\d*)!(?<quantity>\d+)";
            MatchCollection items = Regex.Matches(sb.ToString(), regex);

            Console.WriteLine("Bought furniture:");
            double total = 0.00;

            foreach (Match item in items)
            {
                Console.WriteLine($"{item.Groups["name"].Value}");

                total += double.Parse(item.Groups["price"].Value) *
                                         int.Parse(item.Groups["quantity"].Value);
            }

            Console.WriteLine($"Total money spend: {total:f2}");

        }
    }
}

            //">>{furniture name}<<{price}!{quantity}"

            //>>Sofa<<312.23!3
            //>>TV<<300!5
            //>Invalid<<!5
            //Purchase
            //

            //"Bought furniture:
            //{ 1st name}
            //{ 2nd name}
            //"Total money spend: {spend money}"

