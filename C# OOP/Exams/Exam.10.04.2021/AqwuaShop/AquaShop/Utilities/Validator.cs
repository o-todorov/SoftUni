using System;

namespace AquaShop.Utilities
{
    class Validator
    {
        /// <summary>
        /// Validate string value for null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>Throws Exception if value is null or empty string, 
        /// otherwise returns value</returns>
        public static string StringNotNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
            }

            return value;
        }


        /// <summary>
        /// Validate numeric value for less than zero or equal to zero
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>Throws Exception if value less or equal to zero, 
        /// otherwise returns value</returns>
        public static TValue LessOrEqualToZero<TValue>(TValue value, string message)
            where TValue:IComparable, IConvertible
        {
            if (Convert.ToDouble(value) <= 0)
            {
                throw new ArgumentException(message);
            }

            return value;
        }
    }
}
