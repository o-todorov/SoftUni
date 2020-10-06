using System;
using System.Collections.Generic;

namespace _05._03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCommands = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int i = 0; i < numCommands; i++)
            {
                string[] guest = Console.ReadLine().Split();

                string name = guest[0];
                bool inList = guests.Contains(name);
                bool isGoing = (guest[2] == "going!");

                if (isGoing)
                {
                    if (inList)
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
                else
                {
                    if (inList)
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            foreach (var item in guests)
            {
                Console.WriteLine(item);
            }

        }
    }
}
