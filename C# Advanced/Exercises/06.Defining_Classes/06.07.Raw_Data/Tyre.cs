
namespace RawData
{
    class Tyre
    {
        public Tyre() { }
        public Tyre(double pressure, int age)
        {
            Pressure    = pressure;
            Age         = age;
        }
        public Tyre(string pressure, string age)
        {
            Pressure    = double.Parse(pressure);
            Age         = int.Parse(age);
        }

        public double Pressure { get; set; }
        public int Age { get; set; }

    }
}
