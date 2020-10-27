using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var forceSides = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine())!= "Lumpawaroo")
            {
                var arr = input.Split(" | ");
                string forceSide;
                string forceUser;

                if (arr.Length > 1)
                {
                    forceSide = arr[0];
                    forceUser = arr[1];
                    bool userExist = forceSides.Select(p => p.Value)
                                               .Any(p => p.Contains(forceUser));

                    if (!userExist)
                    {
                        addUser(ref forceSides, forceSide, forceUser);
                    }
                }
                else
                {
                    var newArr = input.Split(" -> ");

                    forceUser = newArr[0];
                    forceSide = newArr[1];

                    foreach (var side in forceSides)
                    {
                        side.Value.Remove(forceUser);
                    }

                    addUser(ref forceSides, forceSide, forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            foreach (var side in forceSides.Where(s => s.Value.Count > 0)
                                           .OrderByDescending(s => s.Value.Count)
                                           .ThenBy(s => s.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                side.Value.OrderBy(u=>u).ToList().ForEach(u => Console.WriteLine($"! {u}"));
            }

        }

        private static void addUser(ref Dictionary<string,List<string>> forceSides, 
                                    string forceSide, 
                                    string forceUser)
        {
            if (forceSides.ContainsKey(forceSide))
            {
                forceSides[forceSide].Add(forceUser);
            }
            else
            {
                forceSides[forceSide] = new List<string>() { forceUser };
            }
        }
    }
}
