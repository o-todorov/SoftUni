using System;
using System.Collections.Generic;

namespace _01._10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int     greenTime   = int.Parse(Console.ReadLine());
            int     freeWindow  = int.Parse(Console.ReadLine());
            string  input       = Console.ReadLine();
            Queue<string> cars  = new Queue<string>();
            int passed = 0;

            while (input!="END")
            {
                if (input == "green")
                {
                    int green   = greenTime;
                    int window  = freeWindow;

                    while (cars.Count > 0 && green > 0)
                    {
                        string car = cars.Dequeue();

                        if ((green + window) < car.Length)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {car[green + window]}.");
                            return;
                        }

                        green -= car.Length;

                        passed++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passed} total cars passed the crossroads.");
        }
    }
}
