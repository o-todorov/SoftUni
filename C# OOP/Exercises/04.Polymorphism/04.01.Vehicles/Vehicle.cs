
namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private const bool isSummerDefault = true;
        protected Vehicle(double fuel, double fuelPerKm)
        {
            Fuel = fuel;
            FuelPerKm = fuelPerKm;
            IsSummer = isSummerDefault;
        }

        public virtual double Fuel { get; protected set; }
        public virtual double FuelPerKm { get; protected set; }

        public bool IsSummer { get; set; }

        public virtual void Drive(double km)
        {
            var fuelNeeded = km * FuelPerKm;

            Fuel -= fuelNeeded;
        }
        public virtual void Refuel(double litres)
        {
            Fuel += litres;
        }
    }
}
