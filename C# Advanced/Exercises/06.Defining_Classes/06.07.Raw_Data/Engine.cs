
namespace RawData
{
    class Engine
    {
        public Engine()
        {
            Speed = 0;
            Power = 0;
        }
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
        public Engine(string speed, string power)
        {
            Speed = int.Parse(speed);
            Power = int.Parse(power);
        }

        public int Speed { get; set; }
        public int Power { get; set; }
    }
}
