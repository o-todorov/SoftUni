using System;

namespace _08._08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double total = 0.00;

            foreach (var str in input)
            {
                int number = int.Parse(str.Substring(1, str.Length - 2));
                double temp = 0.00;
                char letter = str[0];
                
                if (char.IsUpper(letter))
                {
                    int position = letter - 'A' + 1;
                    temp = (double)number / position;
                }
                else
                {
                    int position = letter - 'a' + 1;
                    temp = number * position;
                }

                letter = str[str.Length-1];
                
                if (char.IsUpper(letter))
                {
                    int position = letter - 'A' + 1;
                    temp -=  position;
                }
                else
                {
                    int position = letter - 'a' + 1;
                    temp +=  position;
                }

                total += temp;
            }

            Console.WriteLine($"{total:f2}");
        }
    }
}
