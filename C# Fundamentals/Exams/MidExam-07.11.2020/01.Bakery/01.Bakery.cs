using System;

namespace _01.Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscPerDayPerWorker     = int.Parse(Console.ReadLine());
            int workers                 = int.Parse(Console.ReadLine());
            int biscuitsPerMonthOthers  = int.Parse(Console.ReadLine());

            int bisquitsPerDay          = workers * biscPerDayPerWorker;
            int bisquitsPerThirdDay     = (int)(bisquitsPerDay * 0.75);

            int bisquitsPerMonth        = 20 * bisquitsPerDay + 10 * bisquitsPerThirdDay;
            int diff = bisquitsPerMonth - biscuitsPerMonthOthers;

            Console.WriteLine($"You have produced {bisquitsPerMonth} biscuits for the past month.");

            double percentage = (double)Math.Abs(diff) / biscuitsPerMonthOthers * 100;

            if (diff > 0)
            {
                Console.WriteLine($"You produce { percentage:f2} percent more biscuits.");     
                    }
            else
            {
                Console.WriteLine($"You produce { percentage:f2} percent less biscuits.");
            }

        }
    }
}
