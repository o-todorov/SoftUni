using System;

namespace _02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start   = ConsoleReadRange("Enter range start number:");
            int end     = ConsoleReadRange("Enter range end number:");

            int counter = 0;

            while (counter < 10)
            {
                try
                {
                    ReadNumber(start, end);
                    counter++;
                }
                catch (Exception)
                {
                }
            }

        }

        private static int ConsoleReadRange(string message)
        {
            Console.WriteLine(message);
            return int.Parse(Console.ReadLine());
        }

        public static void ReadNumber(int start, int end)
        {
            int num = int.Parse(Console.ReadLine());
            if (OutOfRange(num, start, end)) throw new InvalidOperationException($"Input number {num} out of bounds");

        }

        private static bool OutOfRange(int num, int start, int end)
        {
            return num < start || num > end;
        }
    }
}
