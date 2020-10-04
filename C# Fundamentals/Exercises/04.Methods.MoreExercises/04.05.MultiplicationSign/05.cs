using System;
using System.Reflection.Metadata.Ecma335;

namespace _04._05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = new double[3];

            for (int i = 0; i < 3; i++)
            {
                arr[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine(checkSign(arr));
        }

        private static string checkSign(double[] arr)
        {
            bool positive = true;

            foreach (double num in arr)
            {
                if (num == 0)
                {
                    return "zero";
                }

                if (num < 0)
                {
                    positive = !positive;
                }

            }

            if (positive)
            {
                return "positive";
            }
            else
            {
                return "negative";
            }
        }
    }
}
