using System;
using System.Collections.Generic;

namespace _01._07.HotPotato
{
    class HotPotato
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Queue<string> players = new Queue<string>();

            foreach (var item in input)
            {
                players.Enqueue(item);
            }

            int jump = int.Parse(Console.ReadLine());

            while (players.Count > 1)
            {
                for (int i = 0; i < jump - 1; i++)
                {
                    players.Enqueue(players.Dequeue());
                }

                Console.WriteLine($"Removed {players.Dequeue()}");
            }

            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}
