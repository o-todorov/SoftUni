using System;
using System.Collections.Generic;
using System.Linq;

namespace VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            var vechicles = new Dictionary<string, Vehicle>()
            {
                {"Car"  , ReadVehicle() },
                {"Truck", ReadVehicle() },
                {"Bus"  , ReadVehicle() }
            };

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var command = input[0];
                var vech    = vechicles[input[1]];
                var value   = double.Parse(input[2]);

                if (command == "Drive" || command == "DriveEmpty")
                {
                    if (vech.GetType().Name == nameof(Bus)) 
                    {
                        if (command == "DriveEmpty")
                        {
                            (vech as Bus).IsLoaded = false;
                        }
                        else
                        {
                            (vech as Bus).IsLoaded = true;
                        }
                    }

                    try
                    {
                        vech.Drive(value);
                        Console.WriteLine($"{vech.GetType().Name} travelled {value} km");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (command == "Refuel")
                {
                    try
                    {
                        vech.Refuel(value);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            vechicles.Values.ToList().ForEach(Console.WriteLine);
        }

        private static Vehicle ReadVehicle()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var fuel        = double.Parse(input[1]);
            var fuelPerKm   = double.Parse(input[2]);
            var capacity     =double.Parse(input[3]);

            if (input[0] == nameof(Car))
            {
                return new Car(fuel, fuelPerKm, capacity);
            }
            else if (input[0] == nameof(Truck))
            {
                return new Truck(fuel, fuelPerKm, capacity);
            }
            else if (input[0] == nameof(Bus))
            {
                return new Bus(fuel, fuelPerKm, capacity);
            }

            return null;
        }
    }
}

