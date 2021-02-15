using System;
using System.Collections.Generic;
using System.Linq;

namespace _2020_06_28_Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            var effects = new Queue<int>(Console.ReadLine()
                                                .Split(", ")
                                                .Select(int.Parse)
                                                .ToArray());

            var casings = new Stack<int>(Console.ReadLine()
                                                .Split(", ")
                                                .Select(int.Parse)
                                                .ToArray());

            var bombs = new Dictionary<int, int>() { { 60, 0 }, { 40, 0 }, { 120, 0 } };
            var counts = new List<int>() { 40, 60, 120 };

            while (effects.Count > 0 && casings.Count > 0 && counts.Count > 0)
            {
                int value = effects.Dequeue() + casings.Pop();

                while (true)
                {
                    if (bombs.ContainsKey(value))
                    {
                        bombs[value]++;

                        if (bombs[value] == 3)
                        {
                            counts.Remove(value);
                        }

                        break;
                    }

                    value -= 5;
                }
            }

            if (counts.Count == 0)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }

            if (casings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }

            Console.WriteLine($"Cherry Bombs: {bombs[60]}");
            Console.WriteLine($"Datura Bombs: {bombs[40]}");
            Console.WriteLine($"Smoke Decoy Bombs: {bombs[120]}");

        }
    }
}
