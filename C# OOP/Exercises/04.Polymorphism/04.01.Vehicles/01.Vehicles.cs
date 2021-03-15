using System;
using System.Collections.Generic;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            var vechicles = new Dictionary<string, IVehicle>()
            {
                {"Car"  , ReadVehicle() },
                {"Truck", ReadVehicle() }
            };

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var vech = vechicles[input[1]];

                if (input[0] == "Drive")
                {
                    var km = double.Parse(input[2]);

                    if (vech.Fuel >= vech.FuelPerKm * km)
                    {
                        vech.Drive(km);
                        Console.WriteLine($"{input[1]} travelled {km} km");
                    }
                    else
                    {
                        Console.WriteLine($"{input[1]} needs refueling");
                    }
                }
                else if(input[0] == "Refuel")
                {
                    var litres = double.Parse(input[2]);
                    vech.Refuel(litres);
                }
            }

            Console.WriteLine($"Car: {vechicles["Car"].Fuel:f2}");
            Console.WriteLine($"Truck: {vechicles["Truck"].Fuel:f2}");
        }

        private static IVehicle ReadVehicle()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (input[0] == "Car")
            {
                return new Car(double.Parse(input[1]), double.Parse(input[2]));
            }
            else if (input[0] == "Truck")
            {
                return new Truck(double.Parse(input[1]), double.Parse(input[2]));
            }

            return null;
        }
    }
}
