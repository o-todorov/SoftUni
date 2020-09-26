using System;

namespace _04._03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = (char)Console.Read();
            Console.ReadLine();
            char b = (char)Console.Read();

            printCharRange(a, b);
        }

        private static void printCharRange(char a, char b)
        {
            if (b < a)
            {
                char c = a;
                a = b;
                b = c;
            }

            while (++a != b)
            {
                Console.Write($"{a} ");
            }
        }
    }
}
