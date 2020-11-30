using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._04.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwarfs = new Dictionary<string, Dwarf>();
            var colors = new Dictionary<string, int>();
            string[] input;

            while ((input = Console.ReadLine().Split(" <:> "))[0].ToLower() != "once upon a time")
            {
                Dwarf dw = new Dwarf(input[0], input[1], int.Parse(input[2]));
                string dwarf = dw.Name + " " + dw.HatColor;

                if (!dwarfs.ContainsKey(dwarf))
                {
                    dwarfs[dwarf] = dw;
                    if (!colors.ContainsKey(dw.HatColor))
                    {
                        colors[dw.HatColor] = 1;
                    }
                    else
                    {
                        colors[dw.HatColor]++;
                    }
                }
                else if (dw.Phisics > dwarfs[dwarf].Phisics)
                {
                    dwarfs[dwarf].Phisics = dw.Phisics;
                }
            }

            foreach (var dwarf in dwarfs.Values.OrderByDescending(dw => dw.Phisics)
                                               .ThenByDescending(dw => colors[dw.HatColor]))
            {
                Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Phisics}");
            }

        }
    }
    class Dwarf
    {
        public Dwarf(string name, string hatColor, int phisics)
        {
            Name        = name;
            HatColor    = hatColor;
            Phisics     = phisics;
        }

        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Phisics { get; set; }
    }
}
