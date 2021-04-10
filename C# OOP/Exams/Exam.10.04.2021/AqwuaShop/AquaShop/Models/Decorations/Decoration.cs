using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {
        private decimal price;
        private int comfort;

        protected Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }
        public int Comfort
        {
            get => comfort;
            set
            {
                comfort = value;
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                price = value;
            }
        }
    }
}
