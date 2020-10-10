using System;
using System.Linq;

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
            int mid = input.Length / 2;

            return  input.Substring(0, mid) == 
                    new String(input.Substring(input.Length - mid, mid)
                                                                        .ToCharArray()
                                                                        .Reverse()
                                                                        .ToArray());
        }
    }
}
