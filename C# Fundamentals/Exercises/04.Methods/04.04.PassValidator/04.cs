
using System;

namespace _04._04.PassValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();

            if (isValidPassword(pass))
            {
                Console.WriteLine("Password is valid");
            }

        }


        private static bool isValidPassword(string pass)
        {
            bool isValid = true;

            if (pass.Length < 6 || pass.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }


            int digitsCount = 0;
            bool isLetter = true;

            foreach (char ch in pass)
            {
                if (ch >= '0' && ch <= '9')
                {
                    digitsCount++;
                }
                else if (isLetter && (ch < 'A' || (ch > 'Z' & ch < 'a') || ch > 'z'))
                {
                    isLetter = false;
                }
            }

            if (!isLetter)
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }

            if (digitsCount < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            return isValid;
        }
    }
}

