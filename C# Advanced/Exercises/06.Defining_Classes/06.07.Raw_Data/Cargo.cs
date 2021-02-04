
namespace RawData
{
    class Cargo
    {
        public Cargo()
        {
            Weight = 0;
            Type = CargoType.Unknown;
        }
        public Cargo(int weight, CargoType type)
        {
            Weight = weight;
            Type = type;
        }
        public Cargo(string weight, CargoType type)
        {
            Weight = int.Parse(weight);
            Type = type;
        }

        public int Weight { get; set; }
        public CargoType Type { get; set; }
    }
}
