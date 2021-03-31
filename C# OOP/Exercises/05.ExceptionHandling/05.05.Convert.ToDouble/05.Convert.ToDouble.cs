using System;

namespace _05._05.ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {

            var obj = Console.ReadLine();

            try
            {
                double dbl = Convert.ToDouble(obj);
                Console.WriteLine(dbl.ToString());
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
            catch (InvalidCastException ice)
            {
                Console.WriteLine(ice.Message);
            }

        }
    }
}
