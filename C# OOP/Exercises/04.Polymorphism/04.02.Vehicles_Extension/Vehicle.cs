
using System;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuel;

        protected Vehicle(double fuel, double fuelPerKm, double tankCapacity)
        {
            FuelPerKm    = fuelPerKm;
            TankCapacity = tankCapacity;
            Fuel         = fuel > TankCapacity ? 0 : fuel;
        }

        public double Fuel 
        { 
            get => fuel;

            protected set 
            {
                if (value <= (TankCapacity))
                {
                    fuel = value;
                }
            } 
        }
        public virtual double FuelPerKm { get; protected set; }
        public double TankCapacity { get; set; }
        public void Drive(double km)
        {
            var fuelNeeded = km * FuelPerKm;

            if (fuelNeeded > fuel)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            Fuel -= fuelNeeded;
        }
        public virtual void Refuel(double litres)
        {
            RefuelCheck(litres, TankCapacity - Fuel);
            Fuel += litres;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {Fuel:f2}";
        }
        protected static void RefuelCheck(double litres, double freeTankVolume)
        {
            if (litres <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (litres > freeTankVolume)
            {
                throw new ArgumentException($"Cannot fit {litres} fuel in the tank");
            }
        }
    }
}
