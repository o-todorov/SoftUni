using System;

namespace _02._09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int spiceCollected = 0;
            int days = 0;

            while (yield>=100)
            {
                days++;
                spiceCollected += yield;
                spiceCollected -= 26;

                yield -= 10;
            }

            spiceCollected -= Math.Min(26,spiceCollected);

            Console.WriteLine(days);
            Console.WriteLine(spiceCollected);
        }
    }
}
