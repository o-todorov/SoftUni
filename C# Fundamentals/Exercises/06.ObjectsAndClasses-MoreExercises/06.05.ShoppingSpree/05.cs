using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._05.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people     = new List<Person>();
            List<Product> products  = new List<Product>();

            Console.ReadLine()
                    .Split(";",StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .ForEach(str =>  people.Add(new Person(str.Split("="))));
            
            Console.ReadLine()
                    .Split(";",StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .ForEach(str => products.Add(new Product(str.Split("="))));

            string[] shoping = Console.ReadLine().Split();


            while (shoping[0].ToUpper()!="END")
            {
                Person person   = people.Find(p => p.name   == shoping[0]);
                Product product = products.Find(p => p.name == shoping[1]);

                if (person != null && product != null)
                {
                    if (!person.BuyProduct(product))
                    {
                        Console.WriteLine($"{person.name} can't afford {product.name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.name} bought {product.name}");
                    }
                }

                shoping = Console.ReadLine().Split();
            }

            people.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }

    class Person
    {
        public string           name;
        public double           money;
        private List<Product>   bag;

        public Person(string []person)
        {
            name    = person[0];
            money   = int.Parse(person[1]);
            bag     = new List<Product>();
        }
        public bool BuyProduct(Product product)
        {
            if (product.price <= money)
            {
                bag.Add(product);
                money -= product.price;
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (bag.Count == 0)
            {
                return $"{name} - Nothing bought";
            }
            else
            {
                sb.Append($"{name} - ")
                    .Append(string.Join(", ", bag));

                return sb.ToString();
            }
        }
    }

    class Product
    {
        public string name;
        public double price;
        public Product(string[] product)
        {
            name    = product[0];
            price   = double.Parse(product[1]);
        }
        public override string ToString()
        {
            return name;
        }
    }
}
