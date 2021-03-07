using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._03_Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people;
            Dictionary<string, Product> products;

            try
            {
                people = ReadFromConsole()
                                .Select(s => new Person(s[0].Trim(), decimal.Parse(s[1].Trim())))
                                .ToDictionary(p => p.Name, p => p);

                products = ReadFromConsole()
                                .Select(s => new Product(s[0].Trim(), decimal.Parse(s[1].Trim())))
                                .ToDictionary(p => p.Name, p => p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string[] input;

            while ((input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries))[0] != "END")
            {
                var person  = people[input[0]];
                var product = products[input[1]];

                if (person.Money >= product.Cost)
                {
                    person.Money -= product.Cost;
                    person.AddProduct(product);
                    Console.WriteLine($"{person} bought {product}");
                }
                else
                {
                    Console.WriteLine($"{person} can't afford {product}");
                }
            }

            PrintPeople(people);
        }

        private static void PrintPeople(Dictionary<string, Person> people)
        {
            foreach (var person in people.Values)
            {
                if (person.BagCount == 0)
                {
                    Console.WriteLine($"{person} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person} - {string.Join(", ", person.Bag)}");
                }
            }
        }

        private static string[][] ReadFromConsole()
        {
            return Console.ReadLine()
                           .Trim()
                           .Split(";", StringSplitOptions.RemoveEmptyEntries)
                           .Select(s => s.Trim().Split('='))
                           .ToArray();
        }
    }
}
