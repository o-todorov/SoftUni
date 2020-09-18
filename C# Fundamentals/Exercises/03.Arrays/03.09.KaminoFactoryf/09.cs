using System;

namespace _03._09.KaminoFactoryf
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[] currArr = new int[size + 1];
            int[] maxArr = new int[size];

            string input = Console.ReadLine();

            int maxSum = 0;
            int minIndex = size - 1;
            int maxLength = 0;

            int bestSeqIDX = 0;
            int currSeqIDX = 0;

            while (input != "Clone them!")
            {
                currSeqIDX++;

                int currIndex = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] != '!')
                    {
                        currArr[currIndex++] = input[i] - '0';
                    }
                }

                int currSum = 0;

                int currMinIDX = size - 1;
                int currLength = 0;

                int tmpMinIDX = size - 1;
                int tmpLength = 0;

                for (int i = 0; i < currArr.Length; i++)
                {
                    if (currArr[i] == 1)
                    {
                        currSum++;

                        if (i < tmpMinIDX) tmpMinIDX = i;

                        tmpLength++;
                    }
                    else
                    {
                        if (tmpLength > currLength)
                        {
                            currLength = tmpLength;
                            currMinIDX = tmpMinIDX;
                        }

                        tmpLength = 0;
                        tmpMinIDX = size;
                    }

                }

                if (currLength > maxLength
                    || currLength == maxLength && (currMinIDX < minIndex || (currMinIDX == minIndex && currSum > maxSum)))
                {
                    for (int i = 0; i < size; i++) maxArr[i] = currArr[i];

                    bestSeqIDX = currSeqIDX;
                    maxLength = currLength;
                    minIndex = currMinIDX;
                    maxSum = currSum;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSeqIDX} with sum: {maxSum}.");
            Console.WriteLine(string.Join(" ", maxArr));

        }
    }
}
