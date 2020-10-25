using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._07.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            var boxes = new List<Box>();

            string[] input;

            while ((input = Console.ReadLine().Split())[0] != "end")
            {
                string  serNum      = input[0];
                string  item        = input[1];
                int     quant       = int.Parse(input[2]);
                double  itemPrice   = double.Parse(input[3]);

                boxes.Add(new Box(serNum, new Item(item, itemPrice), quant));
            }

            boxes.OrderByDescending(b => b.Price)
                .ToList()
                .ForEach(b => Console.Write(b));

        }
    }

    class Item
    {
        public Item(string name, double price)
        {
            Name    = name;
            Price   = price;
        }

        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public Box(string serialNum, Item item, int itemQuantity)
        {
            SerialNum       = serialNum;
            Item            = item;
            ItemQuantity    = itemQuantity;
        }

        public string   SerialNum { get; set; }

        public Item     Item { get; set; }

        public int      ItemQuantity { get; set; }

        public double   Price { get { return Item.Price * ItemQuantity; } }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(SerialNum);
            sb.AppendLine($"-- {Item.Name} - ${Item.Price:f2}: {ItemQuantity}");
            sb.AppendLine($"-- ${Price:f2}");

            return sb.ToString();
        }
    }
}
