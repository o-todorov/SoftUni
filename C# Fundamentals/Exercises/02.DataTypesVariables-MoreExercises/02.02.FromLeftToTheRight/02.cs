using System;

namespace _02._02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {

            int steps = int.Parse(Console.ReadLine());
            long maxxNum;

            for (int i = 0; i < steps; i++)
            {
                string input = Console.ReadLine();
                maxxNum = long.Parse(input.Split(" ")[0]);
                long j= long.Parse(input.Split(" ")[1]);

                if (j > maxxNum) maxxNum = j;

                maxxNum = Math.Abs(maxxNum);
                int sum = 0;

                while (maxxNum != 0)
                {
                    sum += (int)(maxxNum % 10);
                    maxxNum /= 10;
                }
                Console.WriteLine(sum);
            }
        }
    }
}
