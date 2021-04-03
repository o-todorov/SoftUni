using System;

namespace Bakery.Utilities
{
    public static class Validators
    {
        public static T ValidateIsGeaterThanZero<T>(T value, string message)
        where T : IComparable
        {
            if (value.CompareTo(0) <= 0)
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
