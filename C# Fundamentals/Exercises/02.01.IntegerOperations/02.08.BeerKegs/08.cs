using System;

namespace _02._08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int kegsCount = int.Parse(Console.ReadLine());
            double maxVolume = 0;
            string nameMaxKeg = "";

            for (int i = 0; i < kegsCount; i++)
            {
                string kegName = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double volume = Math.PI * Math.Pow(radius, 2) * height;
                if (volume > maxVolume)
                {
                    maxVolume = volume;
                    nameMaxKeg = kegName;
                }
            }

            Console.WriteLine(nameMaxKeg);




        }
    }
}
