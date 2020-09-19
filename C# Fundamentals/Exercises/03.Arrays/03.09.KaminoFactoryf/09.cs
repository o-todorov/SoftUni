using System;

namespace _03._09.KaminoFactoryf
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[] resultArr = new int[size];
            int[] currArr   = new int[size + 1];

            string input = Console.ReadLine();

            int resultSum    = 0;
            int resultIndex  = size - 1;
            int resultLength = 0;

            int bestSeqIDX = 0;
            int currSeqIDX = 0;

            while (input != "Clone them!")
            {
                currSeqIDX++;

                int idx = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] != '!')   currArr[idx++] = input[i] - '0';
                }

                int currSum     = 0;

                int currIDX     = size - 1;
                int currLength  = 0;

                int tmpIDX      = size - 1;
                int tmpLength   = 0;

                for (int i = 0; i < currArr.Length; i++)
                {
                    if (currArr[i] == 1)
                    {
                        currSum++;

                        if (i < tmpIDX) tmpIDX = i;

                        tmpLength++;
                    }
                    else
                    {
                        if (tmpLength > currLength)
                        {
                            currLength = tmpLength;
                            currIDX = tmpIDX;
                        }

                        tmpLength = 0;
                        tmpIDX = size-1;
                    }

                }

                if (currLength > resultLength
                    || currLength == resultLength && (currIDX < resultIndex || (currIDX == resultIndex && currSum > resultSum)))
                {
                    for (int i = 0; i < size; i++) resultArr[i] = currArr[i];

                    bestSeqIDX = currSeqIDX;
                    resultLength = currLength;
                    resultIndex = currIDX;
                    resultSum = currSum;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSeqIDX} with sum: {resultSum}.");
            Console.WriteLine(string.Join(" ", resultArr));

        }
    }
}
