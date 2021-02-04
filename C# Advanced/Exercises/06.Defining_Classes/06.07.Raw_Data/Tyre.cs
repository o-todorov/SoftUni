
namespace RawData
{
    class Tyre
    {
        public Tyre()
        {
            Pressure = 0.00;
            Age = 0;
        }
        public Tyre(double pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }

        public double Pressure { get; set; }
        public int Age { get; set; }

    }
}
