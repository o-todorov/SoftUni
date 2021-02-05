using System;
using System.Collections.Generic;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();

            for (int i = 0; i < count; i++)
            {
                string[] input  = Console.ReadLine().Split();
                string  model   = input[0];
                int power       = int.Parse(input[1]);

                int displacement = 0;
                string efficiency = "";

                GetOthers(input, ref displacement,ref efficiency);

                engines[model] = new Engine(model, power, displacement, efficiency);
            }

            count = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                string[] input  = Console.ReadLine().Split();
                string  Model   = input[0];
                string  engine  = input[1];

                int weight = 0;
                string color = "";

                GetOthers(input, ref weight,ref color);

                var car = new Car(Model, engines[engine], weight, color);
                cars.Add(car);
            }

            cars.ForEach(Console.Write);
        }

        private static void GetOthers(string[] input, ref int retInt, ref string retStr)
        {
            int tmp = 0;

            if (input.Length >= 3)
            {
                bool success = int.TryParse(input[2], out tmp);

                if (success)
                {
                    retInt = tmp;
                }
                else
                {
                    retStr = input[2];
                }
            }
            
            if (input.Length == 4)
            {
                retStr = input[3];
            }
        }
    }
}
