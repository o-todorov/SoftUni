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

            int left = 0, rigth = arr.Sum();
            int index = 0;
            bool exist=false;


            for (int i = 0; i < arr.Length; i++)
            {
                rigth -= arr[i];

                if (left == rigth)
                {
                    index = i;
                    exist = true;
                    break;
                }

                left += arr[i];
            }



            if (exist)
                Console.WriteLine(index);
            else
                Console.WriteLine("no");


        }
    }
}
