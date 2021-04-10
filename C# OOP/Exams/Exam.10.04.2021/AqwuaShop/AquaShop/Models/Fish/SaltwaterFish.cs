namespace AquaShop.Models.Fish
{
    public class SaltwaterFish:Fish
    {
        private const int startingSize  = 3;
        private const int increaseUnits = 3;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            base.startingSize   = startingSize;
            base.increaseUnits  = increaseUnits;
        }
    }
}
