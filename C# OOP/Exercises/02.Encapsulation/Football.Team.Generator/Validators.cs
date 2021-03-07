
using System;

namespace Football.Team.Generator
{
    public static class Validators
    {
        // String validators
        public static string StringNotNullEmptyOrWhitespace(string value, string message = "String is empty, null or whitespace")
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(message);
            return value;
        }
        public static string ValidateStrMaxLen(string value, int maxLen, string message = "String is too long")
        {
            if (value.Length > maxLen) throw new ArgumentException(message);
            return value;
        }
        public static string ValidateStrMinLen(string value, int minLen, string message = "String is too short")
        {
            if (value.Length < minLen) throw new ArgumentException(message);
            return value;
        }
        public static string ValidateStrLen(string value, int minLen, int maxLen, string message = "String length out of range")
        {
            if (value.Length < minLen || value.Length > maxLen) throw new ArgumentException(message);
            return value;
        }

        // Generic check is in range
        public static T ValidateIsInRange<T>(T value, T minValue, T maxValue, string message = "Value out of range")
            where T : IComparable
        {
            if (value.CompareTo(minValue) < 0 || value.CompareTo(maxValue) > 0) throw new ArgumentException(message);
            return value;
        }
        public static T ValidateMinValue<T>(T value, T minValue, string message = "Value is under minValue")
            where T : IComparable
        {
            if (value.CompareTo(minValue) < 0) throw new ArgumentException(message);
            return value;
        }
        public static T ValidateMaxValue<T>(T value, T maxValue, string message = "Value is above maxValue")
            where T : IComparable
        {
            if (value.CompareTo(maxValue) > 0) throw new ArgumentException(message);
            return value;
        }

        //  Checks if object is null
        public static T ValidateNotNull<T>(T value, string message = "Object is null") where T : class
        {
            if (value == null) throw new ArgumentException(message);
            return value;
        }

    }
}
