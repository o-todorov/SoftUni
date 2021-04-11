using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Cooking
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                       .Select(int.Parse)
                                                       .ToArray());

            List<int> ingredients = new List<int>(Console.ReadLine()
                                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                       .Select(int.Parse)
                                                       .Reverse()
                                                       .ToList());

            var foods = new Dictionary<string, int>()
            {
                { "Bread"         , 0 },
                { "Cake"          , 0 },
                { "Pastry"        , 0 },
                { "Fruit Pie"     , 0 }
            };
            var foodsValuesNeeded = new Dictionary<int, string>()
            {
                { 25    ,   "Bread"          },
                { 50    ,   "Cake"           },
                { 75    ,   "Pastry"         },
                { 100   ,   "Fruit Pie"      }
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int sum = liquids.Peek() + ingredients[0];

                if (foodsValuesNeeded.ContainsKey(sum))
                {
                    foods[foodsValuesNeeded[sum]]++;
                    ingredients.RemoveAt(0);
                }
                else
                {
                    ingredients[0] += 3;
                }

                liquids.Dequeue();
            }

            if (foods.Values.All(f => f > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }


            string liqOutput = (liquids.Count == 0) ? "none" : string.Join(", ", liquids);
            Console.WriteLine($"Liquids left: {liqOutput}");

            string ingrOutput = (ingredients.Count == 0) ? "none" : string.Join(", ", ingredients);
            Console.WriteLine($"Ingredients left: {ingrOutput}");

            foods.Select(f => $"{f.Key}: {f.Value}")
                 .OrderBy(f => f)
                 .ToList()
                 .ForEach(Console.WriteLine);

        }

    }
}
