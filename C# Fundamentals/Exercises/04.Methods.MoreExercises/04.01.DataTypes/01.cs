using System;

namespace _04._01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string dtype = Console.ReadLine();

            switch (dtype)
            {
                case "int":
                    proceeed(int.Parse(Console.ReadLine()));
                    break;
                case "real":
                    proceeed(double.Parse(Console.ReadLine()));
                    break;
                case "string":
                    proceed(Console.ReadLine());
                    break;
            }


        }

        private static void proceed(string s)
        {
            Console.WriteLine('$' + s + '$');
        }

        private static void proceeed(double v)
        {
            Console.WriteLine($"{v * 1.5:f2}"); 
        }

        private static void proceeed(int v)
        {
            Console.WriteLine(v * 2); ;
        }
    }
}
