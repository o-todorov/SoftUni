using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int carCount = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < carCount; i++)
            {
                string[] carData    = Console.ReadLine().Split();
                Car car = carParse(carData);
                cars.Add(car.Model, car);
            }

            string[] move;

            while ((move = Console.ReadLine().Split())[0] != "End")
            {
                var car = cars[move[1]];
                double km       = double.Parse(move[2]);

                if (car.CanMove(km))
                {
                    car.Move(km);
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            cars.Values.ToList().ForEach(Console.WriteLine);
        }

        private static Car carParse(string[] carData)
        {
            string carModel = carData[0];
            double fuelAmount = double.Parse(carData[1]);
            double fuelPerKM = double.Parse(carData[2]);

            return new Car(carModel, fuelAmount, fuelPerKM);
        }
    }
}
