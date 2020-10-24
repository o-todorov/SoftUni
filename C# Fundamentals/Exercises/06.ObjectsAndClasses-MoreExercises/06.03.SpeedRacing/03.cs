using System;

namespace _06._03.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int carCount    = int.Parse(Console.ReadLine());
            Car[] cars      = new Car[carCount];

            for (int i = 0; i < carCount; i++)
            {
                cars[i] = ReadCar();
            }

            string[] input;

            while ((input = Console.ReadLine().Split())[0].ToUpper() != "END")
            {
                Array.Find(cars, c => c.model == input[1])
                            .Drive(int.Parse(input[2]));
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString()); ;
            }

        }

        private static Car ReadCar()
        {
            string[] car = Console.ReadLine().Split();

            return new Car(car[0], double.Parse(car[1]), double.Parse(car[2]));
        }
    }

    class Car
    {
        public string model;
        public double fuelAmount;
        public double fuelPerKM;
        public double kilometers;

        public Car(string _model, double _fuelAmount, double _fuelPerKM)
        {
            this.model      = _model;
            this.fuelAmount = _fuelAmount;
            this.fuelPerKM  = _fuelPerKM;
            this.kilometers = 0;
        }

        public void Drive(double km)
        {
            double neededFuel = km * fuelPerKM;

            if (neededFuel <= fuelAmount)
            {
                fuelAmount -= neededFuel;
                kilometers += km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{model} {fuelAmount:f2} {kilometers}";
        }
    }





}
