using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                        .Split(" ")
                        .Select(int.Parse)
                        .ToArray();

            Console.WriteLine(orders.Max());
            Queue<int> queue = new Queue<int>(orders);

            while (queue.Count > 0 && food >= queue.Peek())
            {
                food -= queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: { string.Join(" ", queue.ToArray())}");
            }

        }
    }
}
