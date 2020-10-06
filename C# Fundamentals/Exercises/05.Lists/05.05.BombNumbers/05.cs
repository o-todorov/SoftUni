using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(" ")
                    .Select(int.Parse)
                    .ToList();

            int[] bomb = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();

            int bombNum     = bomb[0];
            int bombPower   = bomb[1];
            int bombIDX;
            int startPos    = 0;

            while ((bombIDX = list.IndexOf(bombNum, startPos)) != -1)
            {

                int lPos = Math.Max(0, bombIDX - bombPower);
                int rPos = Math.Min(bombIDX + bombPower, list.Count - 1);

                for (int i = rPos; i > bombIDX; i--)
                {
                    list.RemoveAt(i);
                }

                for (int i = bombIDX - 1; i >= lPos; i--)
                {
                    list.RemoveAt(i);
                }

                startPos = lPos + 1;
            }

            int sum = 0;

            foreach (var i in list)
            {
                if (i != bombNum) sum += i;
            }

            Console.WriteLine(sum);

        }
    }
}
