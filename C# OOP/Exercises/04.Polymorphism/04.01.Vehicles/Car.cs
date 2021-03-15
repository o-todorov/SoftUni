using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Car : Vehicle
    {
        private const double SummerFuelConsIncrease = 0.9;
        private double fuelPerKm;

        public Car(double fuel, double fuelPerKm) : base(fuel, fuelPerKm) { }
        public override double FuelPerKm 
        {
            get => IsSummer ? fuelPerKm + SummerFuelConsIncrease : fuelPerKm;
            protected set => fuelPerKm = value; 
        }
    }
}
