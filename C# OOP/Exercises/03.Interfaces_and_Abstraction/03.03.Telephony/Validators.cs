using System;
using System.Linq;

namespace Validators
{
    public static class Validate
    {
        public static string ValidatedNumber(string number)
        {
            if (number.All(char.IsDigit)) return number;

            throw new ArgumentException("Invalid number!");
        }

        public static string ValidatedURL(string site)
        {
            if (site.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return site;
        }

    }
}
