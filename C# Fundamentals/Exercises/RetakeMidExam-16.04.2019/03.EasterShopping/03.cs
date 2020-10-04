using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading;

namespace _03.EasterShopping
{
    class Program
    {

        public static List<string> shops;

        static void Main(string[] args)
        {
            shops = Console.ReadLine().Split().ToList();

            int numCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCommands; i++)
            {
                string[] commandLine = Console.ReadLine().Split();

                switch (commandLine[0])
                {
                    case "Include":
                        shops.Add(commandLine[1]);
                        break;
                    case "Visit":
                        int count = int.Parse(commandLine[2]);

                        if (count > shops.Count) break;

                        if (commandLine[1] == "first")
                        {
                            shops.RemoveRange(0, count);
                        }
                        else
                        {
                            shops.RemoveRange(shops.Count - count, count);
                        }
                        break;
                    case "Prefer":
                        int first = int.Parse(commandLine[1]);
                        int second = int.Parse(commandLine[2]);

                        if (!inRange(first) || !inRange( second)) break;

                        exchange( first, second);

                        break;
                    case "Place":
                        int indToPlace = int.Parse(commandLine[2])+1;

                        if (!inRange(indToPlace) ) break;

                        shops.Insert(indToPlace, commandLine[1]);

                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(' ', shops));
        }

        private static void exchange( int first, int second)
        {
            string temp = shops[first];
            shops[first] = shops[second];
            shops[second] = temp;
        }

        private static bool inRange( int IDX)
        {
            return (IDX >= 0 && IDX < shops.Count);
        }
    }
}
