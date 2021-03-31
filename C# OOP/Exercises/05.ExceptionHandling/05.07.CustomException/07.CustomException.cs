using System;

namespace _05._07.CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            var st = new Student("Petko", "petko@gmail.com");
            st = new Student("Petko1", "petko@gmail.com");
            st = new Student("-Petko", "petko@gmail.com");
            st = new Student("Pe*tko", "petko@gmail.com");

            }
            catch (InvalidPersonNameException ipne)
            {

                Console.WriteLine(ipne.Message);
            }

        }
    }
}
