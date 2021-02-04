using System.Text;

namespace SpeedRacing
{
    class Car
    {
        private double travelledDistance;
        public Car()
        {
            this.travelledDistance = 0;
        }
        public Car(string model, double fuelAmount, double fuelPerKilometer)
            :this()
        {
            FuelAmount = fuelAmount;
            Model = model;
            FuelPerKilometer = fuelPerKilometer;
        }

        public string Model { get; set; }
        public double FuelPerKilometer { get; set; }
        public double FuelAmount { get; set; }
        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }
        public bool CanMove(double km)
        {
            return km <= FuelAmount / FuelPerKilometer;
        }
        public void Move(double km)
        {
            travelledDistance += km;
            FuelAmount -= km * FuelPerKilometer;
        }
        public override string ToString()
        {
            return new StringBuilder($"{this.Model} { this.FuelAmount:f2} { this.TravelledDistance}").ToString();
        }

    }
}
