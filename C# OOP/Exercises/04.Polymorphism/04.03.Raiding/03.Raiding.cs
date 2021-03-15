using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            for (int i = 0; i < count;)
            {
                var name       = Console.ReadLine().Trim();
                var heroType   = Console.ReadLine().Trim();

                var hero = ReadHero(name, heroType);

                if (hero != null) 
                {
                    heroes.Add(hero);
                    i++;
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            heroes.ForEach(h => Console.WriteLine(h.CastAbility()));

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = heroes.Sum(h => h.Power);


            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero ReadHero(string name, string heroType)
        {
            Type classType = Type.GetType($"Raiding.{heroType}"); // Fullname - namespace.className

            if (classType != null)
            {
                //object[] constractorArgs = new object[] { name, 80 }; // Create params object for more parameters
                //heroes[name] = Activator.CreateInstance(classType, constractorArgs) as BaseHero;
                return Activator.CreateInstance(classType, name) as BaseHero;
            }

            return null;
        }
    }
}
