using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._04.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] spec = Console.ReadLine().Split();

                cars.Add(new Car(spec[0],
                                int.Parse(spec[1]),
                                int.Parse(spec[2]),
                                int.Parse(spec[3]),
                                spec[4]));
            }


            string cargoType = Console.ReadLine();

            var filtred = cars.Where(car => car.cargo.type == cargoType);

            if (cargoType == "fragile")
            {
                filtred = filtred.Where(car => car.cargo.weight < 1000);
            }
            else
            {
                filtred = filtred.Where(car => car.engine.power > 250);
            }

            filtred.ToList().ForEach(car => Console.WriteLine(car.model));

        }
    }

    class Engine
    {
        public int speed;
        public int power;
        public Engine(int _speed, int _power)
        {
            speed = _speed;
            power = _power;
        }
    }
    class Cargo
    {
        public string   type;
        public int      weight;
        public Cargo(string ctype, int cweight)
        {
            type   = ctype;
            weight = cweight;
        }
    }
    class Car
    {
        public string   model;
        public Engine   engine;
        public Cargo    cargo;

        public Car( string _model, 
                    int espeed, 
                    int epower, 
                    int cweight, 
                    string ctype)
        {
            model   = new string(_model);
            engine  = new Engine(espeed, epower);
            cargo   = new Cargo(ctype, cweight);
        }
    }
}
