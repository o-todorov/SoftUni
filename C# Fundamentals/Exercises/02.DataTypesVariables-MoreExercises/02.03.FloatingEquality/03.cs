using System;

namespace _02._03.FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double precision = 0.000001;
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            if(Math.Abs(a-b)<= precision){
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }


        }
    }
}
