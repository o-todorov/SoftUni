namespace VehiclesExtension
{
    class Car : Vehicle
    {
        private const double SummerFuelConsIncrease = 0.9;
        private double fuelPerKm;

        public Car(double fuel, double fuelPerKm, double tankCapacity) : base(fuel, fuelPerKm, tankCapacity) { }
        public override double FuelPerKm 
        {
            get => fuelPerKm + SummerFuelConsIncrease;
            protected set => fuelPerKm = value; 
        }
    }
}
