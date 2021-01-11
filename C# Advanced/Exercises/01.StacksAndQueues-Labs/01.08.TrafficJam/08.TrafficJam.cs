using System;
using System.Collections.Generic;

namespace _01._08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsToPass = int.Parse(Console.ReadLine());
            int counter = 0;
            Queue<string> waitingCars = new Queue<string>();
            string input = Console.ReadLine();

            while (input!="end")
            {
                if (input=="green")
                {
                    for (int i = Math.Min(waitingCars.Count, carsToPass); i > 0; i--)
                    {
                        Console.WriteLine($"{waitingCars.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    waitingCars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
