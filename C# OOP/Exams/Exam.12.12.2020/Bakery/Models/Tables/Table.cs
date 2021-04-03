using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private List<IBakedFood> FoodOrders;
        private List<IDrink> DrinkOrders;
        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber     = tableNumber;
            Capacity        = capacity;
            PricePerPerson  = pricePerPerson;
            FoodOrders      = new List<IBakedFood>();
            DrinkOrders     = new List<IDrink>();
        }
        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                capacity = value;
            }

        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set => numberOfPeople = Validators.ValidateIsGeaterThanZero(value, ExceptionMessages.InvalidNumberOfPeople);
        }


        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => NumberOfPeople * PricePerPerson;

        public void Clear()
        {
            FoodOrders.Clear();
            DrinkOrders.Clear();
            IsReserved = false;
            NumberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal foodBill  = FoodOrders.Sum(f => f.Price);
            decimal drinkBill = DrinkOrders.Sum(d => d.Price);

            return foodBill + drinkBill;
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.Append($"Price per Person: {PricePerPerson}");

            return sb.ToString();
        }

        public void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }
    }
}
