using System;
using System.Linq;

namespace _01._05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = string.Empty;
            int steps = int.Parse(Console.ReadLine());

            for (int i = 0; i < steps; i++)
            {
                string line = Console.ReadLine();

                int letter = (int)'a';

                if (line == "0") letter = 32;
                else
                {
                    int digit = (int.Parse(line[0].ToString()));

                    int offset = (digit - 2) * 3 + line.Length - 1;

                    if (digit == 8 || digit == 9) offset++;

                    letter += offset;
                }

                result+=(char)letter;

            }

            Console.WriteLine(result);

        }
    }
}
