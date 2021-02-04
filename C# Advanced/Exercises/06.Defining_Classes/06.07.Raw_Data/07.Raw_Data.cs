using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = input[0];
                var engine = new Engine(input[1], input[2]);
                CargoType cargoT = GetCargoType(input[4]);
                var cargo = new Cargo(input[3], cargoT);

                int idx = 5;
                Tyre[] tyres = new Tyre[4];

                for (int j = 0; j < 4; j++)
                {
                    tyres[j] = new Tyre();
                    tyres[j].Pressure   = double.Parse(input[idx++]);
                    tyres[j].Age        = int.Parse(input[idx++]);
                }

                cars.Add(new Car(carModel, engine, cargo, tyres));
            }

            CargoType cargoType = GetCargoType(Console.ReadLine());

            Func<Car, bool> filter = GetFilter(cargoType);

            var result = cars.Where(filter)
                             .Select(c => c.Model);

            Console.WriteLine(string.Join(Environment.NewLine,result));
        }

        private static Func<Car, bool> GetFilter(CargoType cargoType)
        {
            Func<Car, bool> result = car => true;

            if (cargoType == CargoType.Fragile)
            {
                result = car => car.Cargo.Type == CargoType.Fragile &&
                                car.Tyres.Any(t => t.Pressure < 1);
            }
            else if (cargoType == CargoType.Flamable)
            {
                result = car => car.Cargo.Type == CargoType.Flamable &&
                                car.Engine.Power > 250;
            }

            return result;
        }

        private static CargoType GetCargoType(string cargoType)
        {
            return cargoType == "fragile" ? CargoType.Fragile : 
                   cargoType == "flamable" ? CargoType.Flamable :
                   CargoType.Unknown;
        }
    }
}
