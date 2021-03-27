using System;

namespace _05._01.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 0) throw new InvalidOperationException("The number must be pozitive");
                Console.WriteLine(Math.Sqrt(num));

            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
