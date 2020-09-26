using System;
using System.Globalization;
using System.Linq;

namespace _03._05.LongestSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[] len = new int[arr.Length];
            int[] prev = new int[arr.Length];


            prev[0] = -1;
            len[0] = 1;

            int maxLength = 0;
            int currIndex = -1;

            for (int i = 1; i < arr.Length; i++)
            {
                int num = arr[i];
                maxLength = 0;
                currIndex = -1;

                for (int j = 0; j < i; j++)
                {
                    if (len[j] > maxLength && arr[i] > arr[j])
                    {
                        maxLength = len[j];
                        currIndex = j;
                    }
                }

                if (currIndex == -1)
                {
                    len[i] = 1;
                    prev[i] = -1;
                }
                else
                {
                    len[i] = len[currIndex] + 1;
                    prev[i] = currIndex;
                }


            }

            maxLength = 1;
            currIndex = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (len[i] > maxLength)
                {
                    maxLength = len[i];
                    currIndex = i;
                }
            }

            int[] result = new int[maxLength];
            int index = maxLength - 1;

            while (currIndex != -1)
            {
                result[index--] = arr[currIndex];
                currIndex = prev[currIndex];
            }

            Console.WriteLine(string.Join(" ", result));



        }
    }
}
