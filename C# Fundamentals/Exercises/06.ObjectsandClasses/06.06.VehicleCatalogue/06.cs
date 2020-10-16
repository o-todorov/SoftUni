using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string newVehicle = string.Empty;

            while ((newVehicle = Console.ReadLine()).ToUpper() != "END")
            {
                vehicles.Add(new Vehicle(newVehicle));
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
            var veh = vehicles.Where(v => v.Type.ToUpper() == vType).ToList();
            double averageHPower = 0.00;

            if (veh.Count > 0)
            {
                int hPowers = 0;
                veh.ForEach(v => hPowers += v.Horsepower);
                averageHPower = (double)hPowers / veh.Count;
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

        public Vehicle(string vehicleSpec)
        {
            string[] vehicle = vehicleSpec.Split();

            this.Type   = vehicle[0];
            this.Model  = vehicle[1];
            this.Color  = vehicle[2];
            this.Horsepower = int.Parse(vehicle[3]);
        }

        public void Print()
        {
            var charArr = Type.ToCharArray();
            charArr[0]  = char.ToUpper(charArr[0]);

            Console.WriteLine($"Type: {new string(charArr)}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Color: {Color }");
            Console.WriteLine($"Horsepower: {Horsepower }");
        }
    }
}
