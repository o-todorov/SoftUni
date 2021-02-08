
namespace RawData
{
    enum CargoType
    {
        Fragile,
        Flamable,
        Unknown
    }
    class Cargo
    {
        public Cargo()
        {
            Type = CargoType.Unknown;
        }
        public Cargo(int weight, CargoType type)
        {
            Weight  = weight;
            Type    = type;
        }
        public Cargo(string weight, string type)
        {
            Weight  = int.Parse(weight);
            Type    = GetCargoType(type);
        }
        public int Weight { get; set; }
        public CargoType Type { get; set; }
        public static CargoType GetCargoType(string cargoType)
        {
            return cargoType == "fragile" ? CargoType.Fragile :
                   cargoType == "flamable" ? CargoType.Flamable :
                   CargoType.Unknown;
        }
    }

}
