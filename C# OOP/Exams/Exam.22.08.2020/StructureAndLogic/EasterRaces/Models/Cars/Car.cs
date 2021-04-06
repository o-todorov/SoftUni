using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        private             string  model;
        private             int     horsePower;
        private readonly    int     minHorsePower;
        private readonly    int     maxHorsePower;
        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model               = model;
            CubicCentimeters    = cubicCentimeters;
            this.minHorsePower  = minHorsePower;
            this.maxHorsePower  = maxHorsePower;
            HorsePower          = horsePower;

        }
        public string Model 
        { 
            get => model; 
            private set
            {

                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    string message = string.Format(ExceptionMessages.InvalidModel, value, 4);
                    throw new ArgumentException(message);
                }

                model = value;
            }
        }
        public  int HorsePower 
        {
            get => horsePower;
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    string message = string.Format(ExceptionMessages.InvalidHorsePower, value);
                    throw new ArgumentException(message);
                }

                horsePower = value;
            }
        }
        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps) => CubicCentimeters / HorsePower * laps;
    }
}
