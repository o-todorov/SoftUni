using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _05._01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] act = input.Split().ToArray();

                if (act[0] == "Add")
                {
                    train.Add(int.Parse(act[1]));
                }
                else
                {
                    int passToAdd = int.Parse(act[0]);

                    for (int i = 0; i < train.Count; i++)
                    {
                        if ((maxCapacity - train[i]) >= passToAdd)
                        {
                            train[i] += passToAdd;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", train));

        }
    }
}
