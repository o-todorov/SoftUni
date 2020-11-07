using System;
using System.Linq;

namespace _03.AngryPet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] items = Console.ReadLine()
                       .Split(" ")
                       .Select(int.Parse).ToArray();

            int     entryPoint  = int.Parse(Console.ReadLine());
            string  itemType    = Console.ReadLine();
            string  priceType   = Console.ReadLine();

            int leftDamages     = 0;
            int rightDamages    = 0;
            int entryPrice      = items[entryPoint];

            var left    = items[..entryPoint]       .Where(i => IsInPriceType(i, priceType));
            var right   = items[(entryPoint + 1)..] .Where(i => IsInPriceType(i, priceType));

            switch (itemType)
            {
                case "cheap":
                    leftDamages     = left  .Where(i => i < entryPrice).Sum();
                    rightDamages    = right .Where(i => i < entryPrice).Sum();
                    break;
                case "expensive":
                    leftDamages     = left  .Where(i => i >= entryPrice).Sum();
                    rightDamages    = right .Where(i => i >= entryPrice).Sum();
                    break;
                default:
                    break; 
            }

            if (leftDamages >= rightDamages)
            {
                Console.WriteLine($"Left - {leftDamages}");
            }
            else
            {
                Console.WriteLine($"Right - {rightDamages}");
            }
        }

        private static bool IsInPriceType(int i, string priceType)
        {
            switch (priceType.ToLower())
            {
                case "positive":
                    return (i > 0);
                case "negative":
                    return (i < 0);
                default:
                    return true;
            }

        }
    }
}
