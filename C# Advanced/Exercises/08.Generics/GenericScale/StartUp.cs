using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int>      scale   = new EqualityScale<int>(2, 6);
            EqualityScale<int>      scale1  = new EqualityScale<int>(2, 2);
            EqualityScale<string>   scale3  = new EqualityScale<string>("Ivan", "Ivan");
            EqualityScale<string>   scale4  = new EqualityScale<string>("Ivan", "Ivana");

            Console.WriteLine(scale.AreEqual());
            Console.WriteLine(scale1.AreEqual());
            Console.WriteLine(scale3.AreEqual());
            Console.WriteLine(scale4.AreEqual());

        }
    }
}
