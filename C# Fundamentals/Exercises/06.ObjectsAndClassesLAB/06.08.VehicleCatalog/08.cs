using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _06._08.VehicleCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            var catalog = new Catalog();
            string[] input;

            while ((input=Console.ReadLine().Split('/'))[0] != "end")
            {
                string type     = input[0];
                string brand    = input[1];
                string model    = input[2];
                int horsePower  = int.Parse( input[3]);
                int weight      = int.Parse(input[3]);

                if (type == "Car")
                {
                    catalog.Add(new Car(brand, model, horsePower));
                }
                else if (type == "Truck")
                {
                    catalog.Add(new Truck(brand, model, weight));
                }
            }

            catalog.Print("cars");
            catalog.Print("trucks");
        }


    }

    class Catalog
    {
        private List<Truck>  Trucks;
        private List<Car>    Cars;

        public Catalog()
        {
            Trucks  = new List<Truck>();
            Cars    = new List<Car>();
        }

        public void Add(Car veh) 
        {
            Cars.Add(veh);
        }
        public void Add(Truck veh) 
        {
            Trucks.Add(veh);
        }

        public void Print(string vehicleType)
        {
            if (vehicleType.ToLower() == "cars" && Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                Console.WriteLine(string.Join(Environment.NewLine, Cars.OrderBy(c => c.Brand)));
            }
            else if (vehicleType.ToLower() == "trucks" && Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                Console.WriteLine(string.Join(Environment.NewLine, Trucks.OrderBy(c => c.Brand)));
            }

        }
    }

    class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            Brand   = brand;
            Model   = model;
            Weight  = weight;
        }

        public string   Brand { get; set; }
        public string   Model { get; set; }
        public int      Weight { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }
    }

    class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            Brand       = brand;
            Model       = model;
            HorsePower  = horsePower;
        }

        public string   Brand { get; set; }
        public string   Model { get; set; }
        public int      HorsePower { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {HorsePower}hp";
        }
    }

}
