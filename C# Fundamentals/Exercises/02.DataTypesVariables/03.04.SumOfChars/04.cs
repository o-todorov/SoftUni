using System;

namespace _02._04.SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= steps; i++)
            {
                sum += Console.Read();
                Console.ReadLine();
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
