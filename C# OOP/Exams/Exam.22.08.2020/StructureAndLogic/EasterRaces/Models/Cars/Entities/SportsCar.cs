namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        public SportsCar(string model, int horsePower)
            : base(model, horsePower, 3000d, 250, 450)
        {
        }
    }
}
