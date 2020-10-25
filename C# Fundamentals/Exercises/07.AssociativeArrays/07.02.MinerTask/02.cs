using System;
using System.Collections.Generic;

namespace _07._02.MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {

            var resources = new Dictionary<string, int>();

            string resource;

            while ((resource = Console.ReadLine()) != "stop")
            {
                if (!resources.ContainsKey(resource))
                {
                    resources[resource] = 0;
                }

                resources[resource] += int.Parse(Console.ReadLine());
            }

            foreach (var res in resources)
            {
                Console.WriteLine($"{res.Key} -> {res.Value}");
            }


        }
    }
}
