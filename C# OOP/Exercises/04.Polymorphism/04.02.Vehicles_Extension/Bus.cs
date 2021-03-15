
namespace VehiclesExtension 
{ 
    class Bus : Vehicle
    {
        private double fuelPerKm;
        private const double LoadedFuelConsIncrease = 1.4;

        public Bus(double fuel, double fuelPerKm, double tankCapacity) : base(fuel, fuelPerKm, tankCapacity) { }
        public bool IsLoaded { get; set; }
        public override double FuelPerKm
        {
            get => IsLoaded ? fuelPerKm + LoadedFuelConsIncrease : fuelPerKm;
            protected set => fuelPerKm = value;
        }

    }
}
