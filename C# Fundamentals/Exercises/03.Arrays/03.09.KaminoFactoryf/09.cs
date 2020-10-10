using System;
using System.Linq;

namespace _03._09.KaminoFactoryf
{
    class Programg
    {
        static void Main(string[] args)
        {
            int     size = int.Parse(Console.ReadLine());

            string  resulDnaSeq     = string.Empty;
            int     resultSum       = 0;
            int     resultIndex     = size;
            int     resultLength    = 0;

            int     bestSeqIDX = 0;
            int     currSeqIDX = 0;

            string input;

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                currSeqIDX++;

                string currDna      = input.Replace("!", "");

                int currLength  = 0;
                int tmpLength   = 0;
                int currSum     = 0;

                for (int i = 0; i < currDna.Length; i++)
                {
                    if (currDna[i] == '1')
                    {
                        if (++tmpLength > currLength)
                        {
                            currLength = tmpLength;
                        }
                        currSum++;
                    }
                    else
                    {
                        tmpLength = 0;
                    }

                }

                int currIDX = currDna.IndexOf(new string('1', currLength));

                if (currLength > resultLength
                    || currLength == resultLength && (currIDX < resultIndex || (currIDX == resultIndex && currSum > resultSum)))
                {

                    resulDnaSeq     = new string(currDna);
                    bestSeqIDX      = currSeqIDX;
                    resultLength    = currLength;
                    resultIndex     = currIDX;
                    resultSum       = currSum;
                }
            }

            Console.WriteLine($"Best DNA sample {bestSeqIDX} with sum: {resultSum}.");
            Console.WriteLine(string.Join(" ", resulDnaSeq.ToArray()));

        }
    }
}
