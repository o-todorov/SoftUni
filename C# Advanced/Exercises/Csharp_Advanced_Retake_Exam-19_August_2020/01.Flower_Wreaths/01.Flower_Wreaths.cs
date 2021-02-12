using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        { 
            int[] arr = Console.ReadLine()
                      .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();
            var lilies = new Stack<int>(arr);

            arr = Console.ReadLine()
                      .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();
            var roses = new Queue<int>(arr);

            int wreaths       = 0;
            int storedFlowers = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int curr = lilies.Pop() + roses.Dequeue();
                curr = curr > 15 ? 15 - (curr - 15) % 2 : curr;

                if (curr == 15)
                {
                    wreaths++;
                }
                else
                {
                    storedFlowers += curr;
                }
            }

            wreaths += storedFlowers / 15;

            string output = wreaths >= 5 ? 
                    $"You made it, you are going to the competition with {wreaths} wreaths!" :
                    $"You didn't make it, you need {5 - wreaths} wreaths more!";

            Console.WriteLine(output);
        }
    }
}
