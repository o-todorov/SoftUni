using System;

namespace _02._06.TriplesLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int lettersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < lettersCount; i++)
            {
                for (int j = 0; j < lettersCount; j++)
                {
                    for (int k = 0; k < lettersCount; k++)
                    {
                        Console.WriteLine($"{(char)('a' + i)}{(char)('a' + j)}{(char)('a' + k)}");
                    }

                }
            }

            Console.WriteLine();

        }
    }
}
