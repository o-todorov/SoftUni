using Validators;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string site)
        {
            return$"Browsing: {Validate.ValidatedURL(site)}!";
        }

        public string Call(string number)
        {
            return $"Calling... {Validate.ValidatedNumber(number)}";
        }
    }
}
