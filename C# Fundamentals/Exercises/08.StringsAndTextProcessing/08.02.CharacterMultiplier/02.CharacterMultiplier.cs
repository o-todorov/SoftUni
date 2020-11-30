using System;

namespace _08._02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[]input=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);    
            string one = input[0];
            string two = input[1];

            int sum = 0;

            if (one.Length <= two.Length)
            {
                sum = Calculate(one, two);
            }
            else
            {
                sum = Calculate(two, one);
            }

            Console.WriteLine(sum);
        }

        private static int Calculate(string one, string two)
        {
            int total = 0;

            for (int i = 0; i < one.Length; i++)
            {
                total += (int)one[i] * (int)two[i];
            }

            for (int i = one.Length; i < two.Length; i++)
            {
                total += (int)two[i];
            }

            return total;
        }
    }
}
