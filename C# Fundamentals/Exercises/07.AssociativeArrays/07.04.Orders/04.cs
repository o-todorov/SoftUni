using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._01.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, Product>();
            string[] input;

            while ((input = Console.ReadLine().Split())[0] != "buy")
            {
                string  prodName    = input[0];
                double  price       = double.Parse(input[1]);
                int     quant       = int.Parse(input[2]);

                if (products.ContainsKey(prodName))
                {
                    products[prodName].Add(quant, price);
                }
                else
                {
                    products[prodName] = new Product(prodName, price, quant);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, products.Values.ToList()));

        }
    }

    class Product
    {
        public Product(string name, double price, int quantity)
        {
            Name    = name;
            Price   = price;
            Quantity = quantity;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public void Add(int quantity, double price)
        {
            if (Price != price) Price = price;
            Quantity += quantity;
        }
        public override string ToString()
        {
            return $"{Name} -> {Price * Quantity:f2}";
        }
    }
}
