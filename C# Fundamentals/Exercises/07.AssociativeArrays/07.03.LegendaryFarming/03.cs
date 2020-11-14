using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new Dictionary<string, string>(){
                                    {"shards"   ,"Shadowmourne"},
                                    {"fragments","Valanyr" },
                                    {"motes"    ,"Dragonwrath" } };

            var materials   = new Dictionary<string, int>(){
                                    {"shards"   ,0},
                                    {"fragments",0 },
                                    {"motes"    ,0 } };

            var junk        = new SortedDictionary<string, int>();
            string input    = Console.ReadLine();

            while (input != null && input != "")
            {
                string[] res = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < res.Length; i += 2)
                {
                    string mat = res[i + 1];
                    int quontity = int.Parse(res[i]);

                    if (materials.ContainsKey(mat))
                    {
                        materials[mat] += quontity;

                        if (materials[mat] >= 250)
                        {
                            Console.WriteLine($"{items[mat]} obtained!");
                            materials[mat] -= 250;

                            foreach (var x in materials
                                                .OrderByDescending(m => m.Value)
                                                .ThenBy(m => m.Key)
                                                .ToDictionary(m => m.Key, m => m.Value))
                            {
                                Console.WriteLine($"{x.Key}: {x.Value}");
                            }

                            foreach (var x in junk)
                            {
                                Console.WriteLine($"{x.Key}: {x.Value}");
                            }

                            return;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(mat))
                        {
                            junk[mat] += quontity;
                        }
                        else
                        {
                            junk[mat] = quontity;
                        }
                    }
                }

                input = Console.ReadLine();
            }

        }
    }
}
