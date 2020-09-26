using System;

namespace _02._03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int coarses = peopleCount / capacity;
            if (peopleCount % capacity > 0) coarses++;
            Console.WriteLine(coarses);


        }
    }
}
