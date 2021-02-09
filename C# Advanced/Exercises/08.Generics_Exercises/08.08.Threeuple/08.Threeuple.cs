using System;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            /*{first name} {last name} {address} {town}
            • The second line is holding a name, beer liters, and a boolean variable with value - drunk or not. Format:
            {name} {liters of beer} {drunk or not}
            • The last line will hold a name, a bank balance (double) and a bank name. Format:
            {name} {account balance} {bank name}*/
            // {firstElement} -> {secondElement} -> {thirdElement}

            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var fullName = $"{input[0]} {input[1]}";
            var threupleOne = new Threeuple<string, string, string>(fullName,input[2],input[3]);

            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            bool drunk = input[2] == "drunk" ? true : false;
            var threupleTwo = new Threeuple<string, int, bool>(input[0], int.Parse(input[1]), drunk);

            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var threupleThree = new Threeuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);

            PrintThreuple(threupleOne);
            PrintThreuple(threupleTwo);
            PrintThreuple(threupleThree);
        }
        public static void PrintThreuple<T1, T2, T3>(Threeuple<T1, T2, T3> threuple)
        {
            Console.WriteLine(string.Join(" -> ", threuple.ToStringArray()));
        }
    }
}
