using System;
using System.Linq;

namespace _05._05.Applied_Arithmetics
{
    class Program
    {
        public delegate int Operation(int x);

        static void Main(string[] args)
        {
            Operation addOne        = x => x + 1;
            Operation mupliplyByTwo = x => x * 2;
            Operation subtractOne   = x => x - 1;

            Func<int[], Operation, int[]> calculate = (ar, operation) =>
                            ar.Select(x => operation(x)).ToArray();

            Action<int[]> print = ar =>
                             Console.WriteLine(string.Join(" ", ar));

            int[] arr = Console.ReadLine()
                       .Split(" ")
                       .Select(int.Parse)
                       .ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                switch (command)
                {
                    case "add":
                        arr = calculate(arr, addOne);
                        break;
                    case "multiply":
                        arr = calculate(arr, mupliplyByTwo);
                        break;
                    case "subtract":
                        arr = calculate(arr, subtractOne);
                        break;
                    case "print":
                        print(arr);
                        break;
                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }
            }
        }
    }
}
