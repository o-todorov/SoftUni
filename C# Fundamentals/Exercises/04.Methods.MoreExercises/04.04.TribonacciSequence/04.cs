using System;

namespace _04._04.TribonacciSequence
{
    class Program
    {

        public static ulong[] tribonacci;

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            tribonacci = new ulong[num];
            tribonacci[0] = 1;
            getTribonacci(num - 1);

            Console.WriteLine(string.Join(" ", tribonacci));
        }

        private static ulong getTribonacci(int num)
        {
            if (num == -1 || num== -2) return 0;

            if (tribonacci[num] == 0)
            {
                tribonacci[num] = getTribonacci(num - 1) + getTribonacci(num - 2) + getTribonacci(num - 3);
                return tribonacci[num];
            }
            else
            {
                return tribonacci[num];
            }


        }
    }
}
