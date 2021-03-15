using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Truck:Vehicle
    {
        private const double SummerFuelConsIncrease = 1.6;
        private double fuelPerKm;

        public Truck(double fuel, double fuelPerKm) : base(fuel, fuelPerKm)
        {

        }
        public override double FuelPerKm
        {
            get => IsSummer ? fuelPerKm + SummerFuelConsIncrease : fuelPerKm;
            protected set => fuelPerKm = value;
        }
        public override void Refuel(double litres)
        {
            Fuel += litres * 0.95;
        }
    }
}
