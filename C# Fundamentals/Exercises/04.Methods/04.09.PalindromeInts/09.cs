using System;

namespace _04._09.PalindromeInts
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (isPalindrome(input))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }



        }

        private static bool isPalindrome(string input)
        {
            for (int i = 0; i < input.Length/2; i++)
            {
                if (input[i] != input[input.Length - 1 - i]) return false;
            }
            return true;
        }
    }
}
