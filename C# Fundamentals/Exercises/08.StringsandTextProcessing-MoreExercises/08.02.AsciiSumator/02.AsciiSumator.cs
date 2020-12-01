using System;

namespace _08._02.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            int     a       = char.Parse(Console.ReadLine());
            int     b       = char.Parse(Console.ReadLine());
            string  input   = Console.ReadLine();

            if (b < a)
            {
                int t = a;
                a = b;
                b = t;
            }

            int totalSum = 0;

            foreach (var ch in input)
            {
                if (ch > a & ch < b)
                {
                    totalSum += ch;
                }
            }

            Console.WriteLine(totalSum);
        }
    }
}
