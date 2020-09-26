using System;

namespace _03._01.EncryptArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int[] encrypted = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                string word = Console.ReadLine();
                int len = word.Length;
                int code = 0;

                for (int j = 0; j < len; j++)
                {
                    if ("aeiouAEIOU".Contains(word[j]))
                        code += (int)word[j] * len;
                    else
                        code += (int)word[j] / len;
                }

                encrypted[i] = code;
            }

            Array.Sort(encrypted);

            foreach (int i in encrypted)
            {
                Console.WriteLine(i);
            }

        }
    }
}
