namespace Vehicles
{
    public interface IVehicle
    {
        double Fuel { get; }
        double FuelPerKm { get; }
        bool IsSummer { get; set; }
        void Drive(double km);
        void Refuel(double litres);
    }
}