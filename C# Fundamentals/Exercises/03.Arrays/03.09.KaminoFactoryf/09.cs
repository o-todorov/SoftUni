using System;
using System.Linq;

namespace _03._09.KaminoFactoryf
{
    class Programg
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[]   resultArr       = new int[size];
            int     resultSum       = 0;
            int     resultIndex     = size;
            int     resultLength    = 0;

            int     bestSeqIDX      = 0;
            int     currSeqIDX      = 0;

            string  input;

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                currSeqIDX++;

                int[] currArr = input.Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currSum     = 0;
                int currIDX     = size;
                int currLength  = 0;

                int tmpIDX      = size;
                int tmpLength   = 0;

                for (int i = 0; i < size; i++)
                {
                    if (currArr[i] == 1)
                    {
                        if (i < tmpIDX) tmpIDX = i;

                        tmpLength++;
                    }
                    else
                    {
                        if (tmpLength > currLength)
                        {
                            currLength  = tmpLength;
                            currIDX     = tmpIDX;
                        }

                        tmpLength   = 0;
                        tmpIDX      = size;
                    }

                }

                if (tmpLength > currLength)
                {
                    currLength  = tmpLength;
                    currIDX     = tmpIDX;
                }

                currSum = currArr.Sum();

                if (currLength > resultLength
                    || currLength == resultLength && (currIDX < resultIndex || (currIDX == resultIndex && currSum > resultSum)))
                {
                    Array.Copy(currArr, resultArr, size);

                    bestSeqIDX = currSeqIDX;
                    resultLength = currLength;
                    resultIndex = currIDX;
                    resultSum = currArr.Sum();
                }

            }

            Console.WriteLine($"Best DNA sample {bestSeqIDX} with sum: {resultSum}.");
            Console.WriteLine(string.Join(" ", resultArr));

        }
    }
}
