using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> times = Console.ReadLine().Split(" ")
                                       .Select(int.Parse)
                                       .ToList();

            int halfRange = times.Count / 2;

            double timeA = GetCarTime(times.GetRange(0, halfRange).ToArray());
            double timeB = GetCarTime(times.GetRange(halfRange + 1, halfRange)
                                                                .ToArray()
                                                                .Reverse()
                                                                .ToArray());

            double winnerTime = timeA;
            string winner = "left";

            if (timeB < winnerTime)
            {
                winnerTime = timeB;
                winner = "right";
            }

            Console.WriteLine($"The winner is {winner} with total time: {string.Format("{0:0.##}", winnerTime)}");
        }

        private static double GetCarTime(int[] times)
        {
            double sum = 0.0;

            foreach (var time in times)
            {
                if (time != 0)
                {
                    sum += time;
                }
                else
                {
                    sum *= 0.8;
                }
            }

            return sum;
        }
    }
}
