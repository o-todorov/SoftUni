using System;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input;

            while ((input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries))[0] != "End")
            {
                var citizen = new Citizen(input[0], input[1], int.Parse(input[2]));
                Console.WriteLine(citizen.Name);
                Console.WriteLine((citizen as IResident).GetName());
            }

        }
    }
}
