using Bakery.Models.Drinks.Contracts;
using Bakery.Utilities;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private     string  name;
        private     int     portion;
        private     decimal price;
        private     string  brand;

        protected Drink(string name, int portion, decimal price, string brand)
        {
            this.Name       = name;
            this.Portion    = portion;
            this.Price      = price;
            this.Brand      = brand;
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
        public virtual string Brand
        {
            get => brand;
            private set => brand = Validators.ValidateIsNotNullOrWhiteSpace(value, ExceptionMessages.InvalidBrand);
        }

        public override string ToString()
        {
            return $"{Name} {Brand} - {Portion}ml - {Price:f2}lv";
        }
    }

}
