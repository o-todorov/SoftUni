using System;

namespace Bakery.Utilities
{
    public static class Validators
    {
        public static int ValidateIsGeaterThanZero(int value, string message)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message);
            }

            return value;
        }
        public static decimal ValidateIsGeaterThanZero(decimal value, string message)
        {
            if (value <= 0m)
            {
                throw new ArgumentException(message);
            }

            return value;
        }

        public static string ValidateIsNotNullOrWhiteSpace(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(message);
            }

            return value;
        }
    }

}
