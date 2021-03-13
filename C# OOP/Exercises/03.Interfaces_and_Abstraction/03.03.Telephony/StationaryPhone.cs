using Validators;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            return$"Dialing... {Validate.ValidatedNumber(number)}";
        }
    }
}
