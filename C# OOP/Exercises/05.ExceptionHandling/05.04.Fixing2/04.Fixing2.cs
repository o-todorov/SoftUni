using System;

namespace _05._04.Fixing2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            byte result;

            num1 = 30;
            num2 = 60;

            try
            {
                result = Convert.ToByte(num1 * num2);
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
                return;
            }

            Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
            Console.ReadLine();
        }
    }
}
