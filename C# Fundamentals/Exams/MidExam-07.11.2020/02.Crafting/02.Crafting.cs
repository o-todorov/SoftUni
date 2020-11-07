using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _02.Crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] patterns = Console.ReadLine()
                        .Split('|', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

            string[] commandLine;

            while ((commandLine = Console.ReadLine().Split())[0].ToLower() != "done")
            {
                string command = commandLine[0];

                switch (command.ToLower())
                {
                    case "move":
                        int     idx         = int.Parse(commandLine[2]);
                        string  direction   = commandLine[1].ToLower();

                        if (direction == "left")
                        {
                            movePattern(patterns, idx, idx - 1);
                        }
                        else
                        {
                            movePattern(patterns, idx, idx + 1);
                        }
                        break;
                    case "check":
                        string chkType = commandLine[1].ToLower();

                        if (chkType == "even")
                        {
                            PrintPatterns(patterns, 0);
                        }
                        else
                        {
                            PrintPatterns(patterns, 1);
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"You crafted {string.Join("",patterns)}!");

        }

        private static void PrintPatterns(string[] arr, int start)
        {
            List<string> toPrint = new List<string>();

            for (int i = start; i < arr.Length; i+=2)
            {
                toPrint.Add(arr[i]);
            }

            Console.WriteLine(string.Join(" ",toPrint));
        }

        private static void movePattern(string[] arr, int Idx, int newIdx)
        {
            if (Exist(arr, Idx) && Exist(arr, newIdx))
            {
                string tmp  = arr[newIdx];
                arr[newIdx] = arr[Idx];
                arr[Idx]    = tmp;
            }
        }

        private static bool Exist(string[] arr, int idx)
        {
            return idx >= 0 && idx < arr.Length;
        }
    }
}
