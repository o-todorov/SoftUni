using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _09._05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] demons = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string rgxExtractNumbers    = @"[+-]*\d+(\.\d+)*";
            string rgxExtractOperators  = @"[*/]";
            string rgxGetHealthChars    = @"[^\d-+,*/.]";
            var demonsToPrint = new List<Demon>();

            foreach (var demon in demons)
            {
                double demonsDamage = Regex.Matches(demon, rgxExtractNumbers)
                                           .Select(d => double.Parse(d.Value))
                                           .Sum();

                foreach (Match oper in Regex.Matches(demon,rgxExtractOperators))
                {
                    if (oper.Value == "*")
                    {
                        demonsDamage *= 2;
                    }
                    else
                    {
                        demonsDamage /= 2;
                    }
                }

                var tmp     = Regex.Matches(demon, rgxGetHealthChars);
                int health  = tmp.Select(m => (int)m.Value[0]).Sum();
                demonsToPrint.Add(new Demon(demon, health, demonsDamage));

            }

            foreach (var demon in demonsToPrint.OrderBy(d=>d.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }



        }
    }

    class Demon
    {
        public Demon(string name, int health, double damage)
        {
            Name    = name;
            Health  = health;
            Damage  = damage;
        }

        public string   Name { get; set; }
        public int      Health { get; set; }
        public double   Damage { get; set; }
    }
}

//M3ph - 0.5s - 0.5t0 .0 * *
//M3ph1st0 * *, Azazel
