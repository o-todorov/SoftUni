
namespace VehiclesExtension
{
    class Truck:Vehicle
    {
        private const double SummerFuelConsIncrease = 1.6;
        private double fuelPerKm;

        public Truck(double fuel, double fuelPerKm, double tankCapacity) : base(fuel, fuelPerKm, tankCapacity) { }
        public override double FuelPerKm
        {
            get => fuelPerKm + SummerFuelConsIncrease;
            protected set => fuelPerKm = value;
        }
        public override void Refuel(double litres)
        {
            RefuelCheck(litres, TankCapacity - Fuel);

            Fuel += litres * 0.95;
        }
    }
}
