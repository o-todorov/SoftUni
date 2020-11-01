using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            var targets = Console.ReadLine()
                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToList();

            string[] input;

            while ((input = Console.ReadLine().Split())[0].ToLower() != "end")
            {
                string  command = input[0].ToLower();
                int     idx     = int.Parse(input[1]);

                if (command == "shoot")
                {
                    if (idx < 0 || idx >= targets.Count) continue;

                    int power       = int.Parse(input[2]);
                    targets[idx]    -= power;

                    if (targets[idx] <= 0) targets.RemoveAt(idx);
                }
                else if (command == "add")
                {
                    int value = int.Parse(input[2]);

                    if (idx >= 0 && idx < targets.Count)
                    {
                        targets.Insert(idx, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }

                }
                else if (command == "strike")
                {
                    int radius = int.Parse(input[2]);

                    if ((idx - radius) < 0 || (idx + radius) >= targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        targets.RemoveRange(idx - radius, radius * 2 + 1);
                    }
                }
            }

            Console.WriteLine(string.Join("|", targets));

        }
    }
}
