

using System;
using System.Collections.Generic;

namespace _02._03_Shopping_Spree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name  = name;
            this.Money = money;
            bag = new List<Product>();
        }

        public string Name
        {
            get => name;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get => money;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }
        public int BagCount => bag.Count;
        public IReadOnlyCollection<Product> Bag => bag.AsReadOnly();
        public void AddProduct(Product product)
        {
            bag.Add(product);
        }
        public override string ToString()
        {
            return this.Name;
        }

    }
}
