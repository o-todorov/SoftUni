using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._05.DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            var dragons = new Dictionary<string, Dragon>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                int damage = input[2] != "null" ? int.Parse(input[2]) : 45;
                int health = input[3] != "null" ? int.Parse(input[3]) : 250;
                int armor = input[4] != "null" ? int.Parse(input[4]) : 10;

                Dragon dragon = new Dragon(input[1], input[0], damage, health, armor);

                dragons[dragon.ID] = dragon;
            }

            foreach (var type in dragons.Values.GroupBy(drs => drs.Type))
            {
                double damage = type.Select(d => d.Stat.Damage).Average();
                double health = type.Select(d => d.Stat.Health).Average();
                double armor = type.Select(d => d.Stat.Armor).Average();

                Console.WriteLine($"{type.Key}::({damage:f2}/{health:f2}/{armor:f2})");

                foreach (var dragon in type.OrderBy(d=>d.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Stat.Damage}, health: {dragon.Stat.Health}, armor: {dragon.Stat.Armor}");
                }
            }
        }

        class Dragon
        {
            public class Status
            {
                public Status(int damage, int health, int armor)
                {
                    Damage = damage;
                    Health = health;
                    Armor = armor;
                }

                public int Damage { get; set; }
                public int Health { get; set; }
                public int Armor { get; set; }
            }
            public string Name { get; set; }
            public string Type { get; set; }
            public Status Stat;

            public Dragon(string name, string type, int damage, int health, int armor)
            {
                Name = name;
                Type = type;
                Stat = new Status(damage, health, armor);
            }

            public string ID { get { return this.Name + ":" + this.Type; } }
        }
    }
}
