using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities;
using Bakery.Utilities.Messages;

namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood :IBakedFood
    {
        private string  name;
        private int     portion;
        private decimal price;
        protected BakedFood(string name, int portion, decimal price)
        {
            this.Name       = name;
            this.Portion    = portion;
            this.Price      = price;
        }
        public virtual string Name
        {
            get => name;
            private set => name = Validators.ValidateIsNotNullOrWhiteSpace(value, ExceptionMessages.InvalidName);
        }

        public virtual int Portion
        {
            get => portion;

            private set => portion = Validators.ValidateIsGeaterThanZero(value, ExceptionMessages.InvalidPortion);
        }

        public virtual decimal Price
        {
            get => price;

            private set => price = Validators.ValidateIsGeaterThanZero(value, ExceptionMessages.InvalidPrice);
        }

        public override string ToString()
        {
            return $"{Name}: {Portion}g - {Price:f2}";
        }
    }

}
