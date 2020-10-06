using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> handA = Console.ReadLine().Split(" ")
                    .Select(int.Parse)
                    .ToList();
            List<int> handB = Console.ReadLine().Split(" ")
                    .Select(int.Parse)
                    .ToList();

            while(handA.Count!=0 && handB.Count != 0)
            {
                int cardA = handA[0];
                int cardB = handB[0];

                handA.RemoveAt(0);
                handB.RemoveAt(0);

                if (cardA > cardB)
                {
                    handA.Add(cardB);
                    handA.Add(cardA);
                }
                else if (cardA < cardB)
                {
                    handB.Add(cardA);
                    handB.Add(cardB);
                }
            }

            if (handB.Count == 0)
            {
                Console.WriteLine($"First player wins! Sum: {handA.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {handB.Sum()}");
            }
        }
    }
}
