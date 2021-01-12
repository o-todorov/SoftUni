using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int barrel = barrelSize;

            Queue<int> bullets = new Queue<int>(Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .Reverse()
                    .ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray());
            int budget = int.Parse(Console.ReadLine());

            while (bullets.Count > 0 && locks.Count > 0)
            {
                if (bullets.Dequeue() <= locks.Peek())
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                budget -= bulletPrice;
                barrel--;

                if (barrel == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    barrel = barrelSize;
                }
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${budget}");
            }

        }
    }
}
