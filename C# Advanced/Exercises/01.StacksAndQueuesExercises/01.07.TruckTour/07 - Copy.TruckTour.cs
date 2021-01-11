using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            Queue<Pump> pumps = new Queue<Pump>();

            for (int i = 0; i < pumpsCount; i++)
            {
                long[] input = Console.ReadLine()
                       .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                       .Select(long.Parse).ToArray();
                pumps.Enqueue(new Pump() { fuel = input[0], distanceToNext = input[1] });
            }

            for (int i = 0; i < pumps.Count; i++)
            {
                if (CheckIsValid(pumps))
                {
                    Console.WriteLine(i);
                    return;
                }

                pumps.Enqueue(pumps.Dequeue());
            }

        }

        private static bool CheckIsValid(Queue<Pump> pumps)
        {
            long fuel = 0;

            foreach (var pump in pumps.ToArray())
            {
                if((fuel += pump.fuel) < pump.distanceToNext)
                {
                    return false;
                }

                fuel -= pump.distanceToNext;
            }
                        
            return true;
        }
    }

    class Pump
    {
        public long fuel;
        public long distanceToNext;
    }
}
