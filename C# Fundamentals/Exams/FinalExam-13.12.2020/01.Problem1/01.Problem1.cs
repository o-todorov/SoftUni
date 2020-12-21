using System;
using System.Linq;

//Description: https://softwareuniversity-my.sharepoint.com/:w:/g/personal/ivet_atanasova_softuni_bg/ETe53OVI-_9JlrM5IO025XYBUMvbajKWrhMNeMvdcyNxjQ?rtime=kt17HD-f2Eg

namespace _01.Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] command;

            while ((command=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries))[0].ToLower()!="finish")
            {
                switch (command[0].ToLower())
                {
                    case "replace":
                        char currChar = command[1][0];
                        char newChar = command[2][0];
                        Console.WriteLine($"{input = input.Replace(currChar,newChar)}");
                        break;
                    case "cut":
                        int start = int.Parse(command[1]);
                        int end = int.Parse(command[2]);

                        if (NotValid(start,input) || NotValid(end,input))
                        {
                            Console.WriteLine("Invalid indices!");
                        }else
                            Console.WriteLine(input = input.Remove(start,end-start+1));
                        break;
                    case "make":
                        if (command[1].ToLower() == "upper")
                        {
                            Console.WriteLine(input = input.ToUpper());
                        }
                        else
                        {
                            Console.WriteLine(input = input.ToLower());
                        }
                        break;
                    case "check":
                        string check = command[1];

                        if (input.IndexOf(check) == -1)
                        {
                            Console.WriteLine($"Message doesn't contain {check}");
                        }
                        else
                        {
                            Console.WriteLine($"Message contains {check}");
                        }
                        break;
                    case "sum":
                        start = int.Parse(command[1]);
                        end = int.Parse(command[2]);

                        if (NotValid(start, input) || NotValid(end, input))
                        {
                            Console.WriteLine("Invalid indices!");
                        }
                        else
                            Console.WriteLine(input.Substring(start,end-start+1)
                                        .Select(ch=>(int)ch)
                                        .Sum());
                        break;
                    default:
                        break;
                }
            }
        }

        private static bool NotValid(int idx,string str)
        {
            return idx < 0 || idx >= str.Length;
        }
    }
}
