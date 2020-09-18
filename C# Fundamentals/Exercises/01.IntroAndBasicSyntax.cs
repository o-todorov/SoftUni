using System;

namespace CSTestProject
{
    class Program
    {
        static void Main.01.Ages(string[] args)
        {
            string outputstr = "";

            int ages = int.Parse(Console.ReadLine());
            if (ages >= 0 && ages <= 2) outputstr = "baby";
            else if (ages <= 13) outputstr = "child";
            else if (ages <= 19) outputstr = "teenager";
            else if (ages <= 65) outputstr = "adult";
            else if (ages >= 66) outputstr = "elder";

            Console.WriteLine(outputstr);
        }

        /// <summary>
        /// 
        static void Main.02.Division(string[] args)
        {
            int divider = 0;

            int number = int.Parse(Console.ReadLine());

            if (number % 10 == 0) divider = 10;
            else if (number % 7 == 0) divider = 7;
            else if (number % 6 == 0) divider = 6;
            else if (number % 3 == 0) divider = 3;
            else if (number % 2 == 0) divider = 2;

            if (divider != 0)
                Console.WriteLine($"The number is divisible by {divider}");
            else
                Console.WriteLine("Not divisible");
        }


        static void Main.03.Vacation(string[] args)
        {
            int peoples = int.Parse(Console.ReadLine());
            string group = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0.0;

            if (group == "Students")
            {
                if (day == "Friday")
                    price = 8.45;
                else if (day == "Saturday")
                    price = 9.80;
                else if (day == "Sunday")
                    price = 10.46;

                if (peoples >= 30) price *= 0.85;
            }
            else if (group == "Business")
            {
                if (day == "Friday")
                    price = 10.90;
                else if (day == "Saturday")
                    price = 15.60;
                else if (day == "Sunday")
                    price = 16;

                if (peoples >= 100) peoples -= 10;

            }
            else if (group == "Regular")
            {
                if (day == "Friday")
                    price = 15;
                else if (day == "Saturday")
                    price = 20;
                else if (day == "Sunday")
                    price = 22.50;

                if (peoples >= 10 && peoples <= 20) price *= 0.95;

            }

            double total = peoples * price;

            Console.WriteLine("Total price: {total:f2}");


        }


        static void Main.04.Printandsum(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int sum = 0;

            for (; start <= end; start++)
            {
                sum += start;
                Console.Write($"{start} ");
            }
            Console.WriteLine();

            Console.Write($"Sum: {sum}");

        }


        static void Main.05.Login(string[] args)
        {
            string username = Console.ReadLine();
            string pass = "";
            for (int i = (username.Length - 1); i >= 0; i--)
                pass += username[i];

            int tries = 0;
            bool blocked = false;
            string next = Console.ReadLine();

            while (next != pass)
            {
                tries++;

                if (tries == 4)
                {
                    blocked = true;
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");
                next = Console.ReadLine();
            }
            if (!blocked)
                Console.WriteLine($"User {username} logged in.");

        }


        static void Main.06.StrongNumber(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int curr = number;
            int sum = 0;

            while (curr > 0)
            {
                int n = curr % 10;
                int product = 1;

                for (int i = 1; i <= n; i++) product *= i;

                sum += product;
                curr /= 10;
            }

            if (sum == number)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");

        }




        static void Main.07.VendingMachine(string[] args)
        {
            double coins = 0;
            string input = Console.ReadLine();

            while (input != "Start")
            {
                double coin = double.Parse(input);

                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                    coins += coin;
                else
                    Console.WriteLine($"Cannot accept {coin}");

                input = Console.ReadLine();
            }

            string drink = Console.ReadLine();

            while (drink != "End")
            {
                double price = 0;
                string name = "";

                if (drink == "Nuts") { price = 2.0; name = "nuts"; }
                else if (drink == "Water")  { price = 0.7; name = "water"; }
                else if (drink == "Crisps") { price = 1.5; name = "crisps"; }
                else if (drink == "Soda")   { price = 0.8; name = "soda"; }
                else if (drink == "Coke")   { price = 1.0; name = "coke"; }
                else
                    Console.WriteLine("Invalid product");

                if (name != "")
                    if (coins >= price)
                    {
                        coins -= price;
                        Console.WriteLine($"Purchased {name}");
                    }
                    else
                        Console.WriteLine("Sorry, not enough money");

                drink = Console.ReadLine();
            }

            Console.WriteLine($"Change: {coins:f2}");
        }




        static void Main.08.Triangle(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                    Console.Write($"{i} ");

                Console.WriteLine();
            }
        }


        static void Main.09.PadawanEquipment(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double saber_price = double.Parse(Console.ReadLine());
            double robe_price = double.Parse(Console.ReadLine());
            double belt_price = double.Parse(Console.ReadLine());

            int sabers = (int)Math.Ceiling(students * 1.1);
            int belts = students - students / 6;

            double money_needed = sabers * saber_price + students * robe_price + belts * belt_price;

            double diff = money - money_needed;

            if (diff >= 0)
                Console.WriteLine($"The money is enough - it would cost {money_needed:f2)}lv.");
            else
                Console.WriteLine($"Ivan Cho will need {(-diff):f2)}lv more.");

        }


        static void Main.10.RageExpenses(string[] args)
        {
            int games = int.Parse(Console.ReadLine());
            double headset_price = double.Parse(Console.ReadLine());
            double mouse_price = double.Parse(Console.ReadLine());
            double keyboard_price = double.Parse(Console.ReadLine());
            double display_price = double.Parse(Console.ReadLine());

            double price = 0;
            bool jump = true;

            for (int i = 1; i <= games; i++)
            {
                if (i % 2 == 0) price += headset_price;

                if (i % 3 == 0)
                {
                    price += mouse_price;

                    if (i % 2 == 0)
                    {
                        price += keyboard_price;

                        if (!jump)
                        {
                            price += display_price;
                            jump = true;
                        }
                        else
                            jump = false;
                    }
                }

            }

            Console.WriteLine($"Rage expenses: {price:f2} lv.");

        }



    }
}



