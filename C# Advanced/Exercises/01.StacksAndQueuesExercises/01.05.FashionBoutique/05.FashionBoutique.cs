using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._05.FashionBoutique
{
    class FashionBoutique
    {
        static void Main(string[] args)
        {
            Stack<int> box = new Stack<int>(Console.ReadLine()
                       .Split(" ")
                       .Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());
            int racksUsed = 1;
            int freeSpace = rackCapacity;

            while (box.Count!=0)
            {
                if (box.Peek() <= freeSpace)
                {
                    freeSpace -= box.Pop();
                }
                else
                {
                    freeSpace = rackCapacity - box.Pop();
                    racksUsed++;
                }
            }

            Console.WriteLine(racksUsed);
        }
    }
}
