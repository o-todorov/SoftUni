using System;
using System.Text;

namespace _08._05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());
            if (multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            char[] result = new char[number.Length];
            int temp = 0;
            int k = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                k = (number[i] - '0') * multiplier + temp;

                result[i] = (char)(k % 10 + '0');
                temp = k / 10;
            }

            string toPrint = (char)(temp + '0') + new string(result);

            while (toPrint[0] == '0')
            {
                toPrint = toPrint.Remove(0, 1);
            }

            Console.WriteLine(toPrint);

        }
    }
}
