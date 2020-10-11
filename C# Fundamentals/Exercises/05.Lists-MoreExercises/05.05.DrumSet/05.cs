using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05._05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());

            List<int> startDrums = Console.ReadLine().Split(" ")
                                    .Select(int.Parse)
                                    .ToList();
            List<int> drums =new List<int>( startDrums.ToArray());

            string input;

            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                for (int i = 0; i < drums.Count; i++)
                {
                    drums[i] -= hitPower;

                    if (drums[i] <= 0)
                    {
                        if (savings >= startDrums[i] * 3)
                        {
                            drums[i] = startDrums[i];
                            savings -= startDrums[i] * 3;
                        }
                        else
                        {
                            drums.RemoveAt(i);
                            startDrums.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", drums));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");

        }

    }
}
