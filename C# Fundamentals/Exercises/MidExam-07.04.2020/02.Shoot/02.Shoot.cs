using System;
using System.Linq;

namespace _02.Shoot
{
    class Shoot
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                       .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse).ToArray();

            string input = string.Empty;
            int shot = 0;

            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                int idx = int.Parse(input);

                if (idx < 0 || idx >= targets.Length || targets[idx] == -1) continue;

                int val         = targets[idx];
                targets[idx]    = -1;
                targets         = targets.Select(t => 
                                                t > val ? t - val : 
                                                t > -1 ? t + val : t)
                                        .ToArray();
                shot++;
            }

            Console.WriteLine($"Shot targets: {shot} -> {string.Join(" ", targets)}");
        }
    }
}
