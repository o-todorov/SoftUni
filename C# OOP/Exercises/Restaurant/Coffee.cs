
namespace Restaurant
{
    public class Coffee:HotBeverage
    {
        private const decimal coffeePrice       = 3.50M;
        private const double  coffeeMilliliters = 50.0;
        public Coffee(string name, double caffeine)
            : base(name, coffeePrice, coffeeMilliliters)
        {
            Caffeine = caffeine;
        }
        public double CoffeeMilliliters { get => base.Milliliters;}
        public decimal CoffeePrice { get => base.Price; }
        public double Caffeine { get; set; }
    }
}
