using System;

namespace _02._07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 255;
            int free = capacity;
            int inputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsCount; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if (free < liters)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }

                free -= liters;
            }

            Console.WriteLine($"{capacity-free}");
        }
    }
}
