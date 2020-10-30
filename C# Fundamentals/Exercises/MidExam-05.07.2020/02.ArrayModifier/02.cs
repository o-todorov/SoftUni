using System;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                       .Split(" ")
                       .Select(int.Parse).ToArray();

            string[] commArr;

            while ((commArr = Console.ReadLine().Split())[0].ToLower() != "end")
            {
                string command = commArr[0];

                if (command == "swap")
                {
                    int idx1 = int.Parse(commArr[1]);
                    int idx2 = int.Parse(commArr[2]);
                    int tmp = arr[idx1];
                    arr[idx1] = arr[idx2];
                    arr[idx2] = tmp;
                }
                else if (command == "multiply")
                {
                    int idx1 = int.Parse(commArr[1]);
                    int idx2 = int.Parse(commArr[2]);
                    arr[idx1] = arr[idx1] * arr[idx2];
                }
                else if (command == "decrease")
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] -= 1;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", arr));

        }
    }
}
