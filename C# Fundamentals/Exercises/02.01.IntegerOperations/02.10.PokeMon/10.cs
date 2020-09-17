using System;

namespace _02._10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int dist = int.Parse(Console.ReadLine());
            int factor = int.Parse(Console.ReadLine());
            int count = 0;
            int currPower = power;

            while (dist <= currPower)
            {
                count++;
                currPower -= dist;
                if ((double)power / currPower == 2.0 && factor > 0) currPower /= factor;
            }

            Console.WriteLine(currPower);
            Console.WriteLine(count);

        }
    }
}
