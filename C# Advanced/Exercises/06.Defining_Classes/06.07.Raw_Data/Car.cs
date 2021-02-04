
namespace RawData
{
    enum CargoType
    {
        Fragile,
        Flamable,
        Unknown
    }
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tyre[] Tyres { get; set; }
        public Car()
        {
            Model = "No Model";
            Engine = new Engine();
            Cargo = new Cargo();
            Tyres = new Tyre[4];
        }

        public Car(string model, Engine engine, Cargo cargo, Tyre[] tyres)
        {
            Model   = model;
            Engine  = engine;
            Cargo   = cargo;
            Tyres   = tyres;
        }
    }
}
