using System;

namespace _01._03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {

            double money = double.Parse(Console.ReadLine());
            double balance = money;

            string game = Console.ReadLine();
            double gamePrice = 0.0;

            while (game != "Game Time")
            {
                switch (game)
                {
                    case "OutFall 4":

                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99;
                        break;

                    case "CS: OG":
                        gamePrice = 15.99;
                        break;

                    case "Zplinter Zell":
                        gamePrice = 19.99;
                        break;

                    case "Honored 2":
                        gamePrice = 59.99;
                        break;

                    case "RoverWatch":
                        gamePrice = 29.99;
                        break;

                    default:
                        Console.WriteLine("Not Found");
                        game = Console.ReadLine();
                        continue;
                }

                if (balance >= gamePrice)
                {
                    balance -= gamePrice;
                    Console.WriteLine("Bought " + game);

                    if (balance == 0)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }
                game = Console.ReadLine();

            }

            if (balance == 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${(money - balance):f2}. Remaining: ${balance:f2}");
            }
        }
    }
}
