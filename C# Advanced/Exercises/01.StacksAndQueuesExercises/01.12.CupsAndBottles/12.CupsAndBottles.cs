using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> caps = new Queue<int>(Console.ReadLine()
                       .Split(" ")
                       .Select(int.Parse)
                       .ToArray());
            Queue<int> bottles = new Queue<int>(Console.ReadLine()
                       .Split(" ")
                       .Select(int.Parse)
                       .Reverse()
                       .ToArray()); ;
            int litters = 0;
            int bottle  = 0;
            int cap     = 0;

            while (caps.Count > 0 && bottles.Count > 0)
            {
                bottle = bottles.Dequeue();

                if (cap == 0) cap = caps.Peek();

                if (cap <= bottle)
                {
                    litters += bottle - cap;
                    caps.Dequeue();
                    cap = 0;
                }
                else
                {
                    cap -= bottle;
                }
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles.ToArray())}");
            }

            if (caps.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ",caps.ToArray())}");
            }

            Console.WriteLine($"Wasted litters of water: {litters}");
        }
    }
}
