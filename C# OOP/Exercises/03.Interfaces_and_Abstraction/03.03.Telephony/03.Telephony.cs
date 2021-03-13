using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var phone = new StationaryPhone();
            var smart = new Smartphone();
            var numbers   = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        Console.WriteLine(smart.Call(number));
                    }
                    else 
                    {
                        Console.WriteLine(phone.Call(number));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var sites   = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(smart.Browse(site));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
