using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var buyers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < count; i++)
            {
                var info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                AddBuyer(buyers, info);
            }

            string name = Console.ReadLine().Trim();

            while (name.ToLower() != "end")
            {
                if (buyers.ContainsKey(name))
                {
                    buyers[name].BuyFood();
                }

                name = Console.ReadLine().Trim();
            }

            Console.WriteLine(buyers.Values.Sum(b=>b.Food));


        }
        private static void AddBuyer(Dictionary<string, IBuyer> buyers, string[] info)
        {
            string name = info[0];
            int age = int.Parse(info[1]);

            switch (info.Length)
            {
                case 4:
                    buyers[name] = new Citizen(name, age, info[2], DateTime.ParseExact(info[3], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    break;
                case 3:
                    buyers[name] = new Rebel(name, age, info[2]);
                    break;
                default:
                    break;
            }
        }

    }
}
