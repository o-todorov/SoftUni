using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities;
using AquaShop.Utilities.Messages;
namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string      name;
        private string      species;
        private decimal     price;
        protected int       increaseUnits;
        protected int       startingSize;
        protected Fish(string name, string species, decimal price)
        {
            Name        = name;
            Species     = species;
            Price       = price;
            Size        = startingSize;
        }

        public string Name 
        { 
            get => name;

            private set => name = Validator.StringNotNullOrEmpty(value, ExceptionMessages.InvalidFishName);
        }

        public string Species 
        { 
            get => species;
            private set => species = Validator.StringNotNullOrEmpty(value, ExceptionMessages.InvalidFishSpecies);
        }

        public int Size { get ; private set; }

        public decimal Price 
        { 
            get => price;

            private set => price = Validator.LessOrEqualToZero(value, ExceptionMessages.InvalidFishPrice);
        }

        public virtual void Eat()
        {
            Size += increaseUnits;
        }
    }
}
