namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, 5000d, 400, 600)
        {
        }
    }
}
