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

                int idx = 0;
                var car = new Car(input[idx++],
                                  new Engine(input[idx++], input[idx++]),
                                  new Cargo(input[idx++], input[idx++]),
                                  new Tyre[4]);

                for (int j = 0; j < 4; j++)
                {
                    car.Tyres[j] = new Tyre(input[idx++],input[idx++]);
                }

                cars.Add(car);
            }

            var cargo = Cargo.GetCargoType(Console.ReadLine());

            Func<Car, bool> filter = GetFilter(cargo);

            var result = cars.Where(filter).Select(c => c.Model);

            Console.WriteLine(string.Join(Environment.NewLine, result));
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
    }
}
