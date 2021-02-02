/* Write a program that executes some mathematical operations on a given collection. On the first line you are given a list of numbers. On the next lines you are passed different commands that you need to apply to all the numbers in the list:
    • "add"->add 1 to each number
    • "multiply" -> multiply each number by 2
    • "subtract" -> subtract 1 from each number
    • "print" -> print the collection
    • "end" -> ends the input 
Use functions.*/
    
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._05.Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var ops = new Dictionary<string, Func<int, int>>()
                    {
                        {"add",         x => x + 1},
                        {"multiply",    x => x * 2 },
                        {"subtract",    x => x - 1}
                    };

            Action<int[]> print = ar => Console.WriteLine(string.Join(" ", ar));

            int[] arr = Console.ReadLine()
                       .Split(" ")
                       .Select(int.Parse)
                       .ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine().ToLower()) != "end")
            {

                if (ops.ContainsKey(command))
                {
                    arr = arr.Select(ops[command]).ToArray();

                }
                else if (command == "print")
                {
                    print(arr);
                }
            }
        }
    }
}
