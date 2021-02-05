using System;
using System.Text;

namespace CarSalesman
{
    class Engine
    {
        public Engine(string model, int power, int displacement = 0, string efficiency = "")
        {
            Model           = model;
            Power           = power;
            Displacement    = displacement;
            Efficiency      = efficiency;
        }

        public string   Model { get; set; }
        public int      Power { get; set; }
        public int      Displacement { get; set; }
        public string   Efficiency { get; set; }

        private string ToPrint(int x) => x > 0 ? x.ToString() : "n/a";
        private string ToPrint(string x) => x != "" ? x : "n/a";

        public override string ToString()
        {
            Func<int, string> toPrint = x => x > 0 ? x.ToString() : "n/a";

            var sb = new StringBuilder();
            sb.AppendLine($"  { Model}:")
              .AppendLine($"    Power: { Power}")
              .AppendLine($"    Displacement: { ToPrint(Displacement)}")
              .AppendLine($"    Efficiency: { ToPrint(Efficiency)}");
            return sb.ToString();
        }
    }
}

