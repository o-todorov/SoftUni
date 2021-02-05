using System.Text;

namespace CarSalesman
{

    class Car
    {
        public Car(string model, Engine engine, int weight = 0, string color = "")
        {
            Model   = model;
            Engine  = engine;
            Weight  = weight;
            Color   = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        private string ToPrint(int x) => x > 0 ? x.ToString() : "n/a";
        private string ToPrint(string x) => x != "" ? x : "n/a";

        public override string ToString()
        {

            var sb = new StringBuilder();
            sb.AppendLine($"{ Model}:")
              .Append(Engine.ToString())
              .AppendLine($"  Weight: { ToPrint(Weight)}")
              .AppendLine($"  Color: { ToPrint(Color)}");
            return sb.ToString();
        }

    }
}

