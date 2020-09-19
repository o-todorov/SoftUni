using System;

namespace _01._01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int t;

            if (b > a)
            {
                t = a;
                a = b;
                b = t;
            }

            if (c > b)
            {
                t = c;
                c = b;

                if (t > a)
                {
                    b = a;
                    a = t;
                }
                else
                {
                    b = t;
                }
            }

            Console.WriteLine($"{a}\n{b}\n{c}");


        }
    }
}

