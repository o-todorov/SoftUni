using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] city;
            Dictionary<string, City> cities = new Dictionary<string, City>();

            while ((city=Console.ReadLine().Split("||"))[0]!= "Sail")
            {
                string name = city[0];

                if (cities.ContainsKey(name))
                {
                    cities[name].Population += int.Parse(city[1]);
                    cities[name].Gold += int.Parse(city[2]);
                }
                else
                {
                    cities[name] = new City(city);
                }
            }

            string[] act;

            while ((act = Console.ReadLine().Split("=>"))[0] != "End")
            {
                string name = act[1];

                if(act[0]== "Plunder")
                {
                    int killed      = int.Parse(act[2]);
                    int goldStolen  = int.Parse(act[3]);
                    Console.WriteLine($"{name} plundered! {goldStolen} gold stolen, {killed} citizens killed.");
                    cities[name].Population -= killed;
                    cities[name].Gold       -= goldStolen;

                    if (cities[name].Population == 0 || cities[name].Gold == 0)
                    {
                        cities.Remove(name);
                        Console.WriteLine($"{name} has been wiped off the map!");
                    }
                }
                else if(act[0]== "Prosper")
                {
                    int goldAdded = int.Parse(act[2]);
                    if (goldAdded < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        Console.WriteLine($"{goldAdded} gold added to the city treasury. " +
                                          $"{name} now has {cities[name].Gold += goldAdded} gold.");
                    }
                }
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var town in cities.OrderByDescending(c=>c.Value.Gold).ThenBy(c=>c.Value.Name))
                {
                    Console.WriteLine($"{town.Value.Name} -> " +
                                      $"Population: {town.Value.Population} citizens, " +
                                      $"Gold: {town.Value.Gold} kg");
                }

            } else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
    class City
    {
        public City(string[]city)
        {
            Name        = city[0];
            Population  = int.Parse(city[1]);
            Gold        = int.Parse(city[2]);
        }

        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

    }
}
