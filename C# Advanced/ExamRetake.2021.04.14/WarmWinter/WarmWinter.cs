using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class WarmWinter
    {
        static void Main(string[] args)
        {
            var hats = Console.ReadLine()
                              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToList();

            var scarfs = new Queue<int>( Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray());

            var sets = new List<int>();

            while(hats.Count > 0 && scarfs.Count > 0)
            {
                var lastHatIdx  = hats.Count - 1;
                var hat         = hats[lastHatIdx];
                var scarf       = scarfs.Peek();

                if (hat > scarf)
                {
                    sets.Add(hat + scarf);
                    hats.RemoveAt(lastHatIdx);
                    scarfs.Dequeue();
                }
                else if (hat < scarf)

                {
                    hats.RemoveAt(lastHatIdx);
                }
                else
                {
                    scarfs.Dequeue();
                    hats[lastHatIdx]++;
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");

            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
