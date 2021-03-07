
namespace Restaurant
{
    public class Cake:Dessert
    {
        private const double  defaultCalories   = 1000.0;
        private const double  defaultGrams      = 250.0;
        private const decimal defaultCakePrice  = 5M;
        public Cake(string name)
            : base(name, defaultCakePrice, defaultGrams, defaultCalories)
        {

        }
    }
}
