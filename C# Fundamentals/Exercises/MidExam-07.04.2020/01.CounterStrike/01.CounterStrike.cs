using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string input = string.Empty;
            int wonBattles = 0;

            while ((input = Console.ReadLine()).ToLower() != "end of battle")
            {
                int distance = int.Parse(input);

                if (distance > energy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {energy} energy");
                    return;
                }
                else
                {
                    energy -= distance;
                    wonBattles++;
                    if (wonBattles % 3 == 0)
                    {
                        energy += wonBattles;
                    }
                }
            }

            Console.WriteLine($"Won battles: {wonBattles}. Energy left: {energy}");
        }
    }
}
