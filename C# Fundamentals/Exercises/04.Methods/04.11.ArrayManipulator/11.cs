using System;
using System.Linq;

namespace _04._11.ArrayManipulator
{
    class Program
    {

        public static int[] arr;

        static void Main(string[] args)
        {
            arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            string line;
            int count;

            while ((line = Console.ReadLine()) != "end")
            {
                string[] commLine = line.Split().ToArray();
                string command = commLine[0];

                bool even;

                switch (command)
                {
                    case "exchange":
                        int index = int.Parse(commLine[1]);

                        if (index < 0 || index > arr.Length - 1)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            if (index < (arr.Length - 1)) exchange(index);
                        }
                        break;
                    case "max":
                        even = commLine[1] == "even";
                        findMax(even);
                        break;
                    case "min":
                        even = commLine[1] == "even";
                        findMin(even);
                        break;
                    case "first":
                        count = int.Parse(commLine[1]);
                        even = commLine[2] == "even";
                        findFirst(count, even);
                        break;
                    case "last":
                        count = int.Parse(commLine[1]);
                        even = commLine[2] == "even";
                        findLast(count, even);
                        break;
                    default:
                        break;
                }

            }

            printArr(arr);

        }

        private static void printArr(int[] outArr)
        {
            Console.Write('[');
            Console.Write(string.Join(", ", outArr));
            Console.WriteLine(']');
        }

        private static void findLast(int count, bool even)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int[] result;
            int[] newArr;

            if (even)
            {
                newArr = arr.Where(c => isEven(c)).ToArray();
            }
            else
            {
                newArr = arr.Where(c => !isEven(c)).ToArray();
            }

            count = Math.Min(count, newArr.Length);
            result = new int[count];
            Array.Copy(newArr, newArr.Length - count, result, 0, count);

            printArr(result);
        }

        private static void findFirst(int count, bool even)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int[] result;
            int[] newArr;

            if (even)
            {
                newArr = arr.Where(c => isEven(c)).ToArray();
            }
            else
            {
                newArr = arr.Where(c => !isEven(c)).ToArray();
            }

            count = Math.Min(count, newArr.Length);
            result = new int[count];
            Array.Copy(newArr, 0, result, 0, count);

            printArr(result);
        }

        private static void findMin(bool even)
        {

            int idx = -1;
            int[] newArr;

            if (even)
            {
                newArr = arr.Where(c => isEven(c)).ToArray();
            }
            else
            {
                newArr = arr.Where(c => !isEven(c)).ToArray();
            }

            if (newArr.Length > 0)
            {
                int minValue = newArr.Min();

                for (int i = arr.Length-1; i >= 0; i--)
                {
                    if (arr[i] == minValue)
                    {
                        idx = i;
                        break;
                    }
                }

            }

            if (idx == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(idx);
            }
        }



        private static void findMax(bool even)
        {
            int max = int.MinValue;
            int idx = -1;

            if (even)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (isEven(arr[i]) && arr[i] >= max)
                    {
                        max = arr[i];
                        idx = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!isEven(arr[i]) && arr[i] >= max)
                    {
                        max = arr[i];
                        idx = i;
                    }
                }
            }


            if (idx == -1) Console.WriteLine("No matches");
            else Console.WriteLine(idx);
        }

        private static void exchange(int i)
        {
            int lenToReplace = i + 1;
            int[] tmpArr = new int[lenToReplace];

            Array.Copy(arr, 0, tmpArr, 0, lenToReplace);

            for (int j = 0; j < arr.Length - lenToReplace; j++)
            {
                arr[j] = arr[j + lenToReplace];
            }

            Array.Copy(tmpArr, 0, arr, arr.Length - lenToReplace, lenToReplace);

        }

        private static bool isEven(int i)
        {
            return i % 2 == 0;
        }
    }
}
