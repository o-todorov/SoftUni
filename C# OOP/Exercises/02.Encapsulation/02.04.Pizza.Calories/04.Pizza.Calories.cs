using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Pizza pizza = null;

            try
            {
                pizza = new Pizza(input[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }


            input = Console.ReadLine().Split();
            Dough dough = null;

            try
            {
                dough = new Dough(input[1], input[2], double.Parse(input[3]));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            pizza.Dough = dough;

            while ((input = Console.ReadLine().Split())[0] != "END")
            {
                try
                {
                    pizza.AddTopping(input[1], double.Parse(input[2]));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return;
                }
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
        }
    }
}
