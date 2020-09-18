using System;
using System.Linq;
using System.Security.Principal;

namespace _03._06.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int left = 0, rigth = 0;
            int index = 0;
            bool exist=false;

            for (int i = 0; i < arr.Length; i++)
            {
                left = 0; rigth = 0;

                for (int j = 0; j < i ; j++) left += arr[j];
                for (int j = i + 1; j < arr.Length; j++) rigth += arr[j];

                if (left == rigth)
                {
                    index = i;
                    exist = true;
                    break;
                }
            }



            if (exist)
                Console.WriteLine(index);
            else
                Console.WriteLine("no");


        }
    }
}
