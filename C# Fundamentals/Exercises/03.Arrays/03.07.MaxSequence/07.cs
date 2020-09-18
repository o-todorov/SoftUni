using System;
using System.Linq;

namespace _03._07.MaxSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int maxCount = 1, currMaxCount = 1;
            int maxNum = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != arr[i - 1])
                {
                    if (currMaxCount > maxCount)
                    {
                        maxCount = currMaxCount;
                        maxNum = arr[i - 1];
                    }
                    currMaxCount = 1;

                    if ((arr.Length - i) <= maxCount) break;
                }

                else currMaxCount++;
            }

            if (currMaxCount > maxCount)
            {
                maxCount = currMaxCount;
                maxNum = arr[arr.Length - 1];
            }


            for (int i = 0; i < maxCount; i++)
            {
                Console.Write($"{maxNum} ");
            }
        }
    }
}
