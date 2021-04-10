namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int startingSize  = 3;
        private const int increaseUnits = 3;

        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            base.startingSize   = startingSize;
            base.increaseUnits  = increaseUnits;
        }
    }
}
