using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles  = new List<Vehicle>();

            string[] newVehicle = Console.ReadLine().Split();

            while (newVehicle[0].ToUpper() != "END")
            {
                vehicles.Add(new Vehicle(newVehicle));

                newVehicle = Console.ReadLine().Split();
            }

            string model = string.Empty;

            while ((model = Console.ReadLine()).ToLower() != "close the catalogue")
            {
                vehicles.Find(v => v.Model == model).Print();
            }

            PrintAverageHPower(ref vehicles, "CAR", "Cars");
            PrintAverageHPower(ref vehicles, "TRUCK", "Trucks");


        }

        private static void PrintAverageHPower(ref List<Vehicle> vehicles, string vType, string heading)
        {
            var veh = vehicles.Where(v => v.Type.ToUpper() == vType);

            double averageHPower = 0.00;

            if (veh.Count() > 0)
            {
                averageHPower = (double)veh.Sum(v => v.Horsepower) / veh.Count();
            }

            Console.WriteLine($"{heading} have average horsepower of: {averageHPower:f2}.");
        }
    }


    class Vehicle
    {
        public string   Type;
        public string   Model;
        public string   Color;
        public int      Horsepower;

        public Vehicle(string[] vehicleSpec)
        {
            this.Type   = vehicleSpec[0];
            this.Model  = vehicleSpec[1];
            this.Color  = vehicleSpec[2];
            this.Horsepower = int.Parse(vehicleSpec[3]);
        }

        public void Print()
        {
            Console.WriteLine($"Type: {char.ToUpper(Type[0])}{Type.Substring(1)}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Color: {Color }");
            Console.WriteLine($"Horsepower: {Horsepower}");
        }
    }
}
