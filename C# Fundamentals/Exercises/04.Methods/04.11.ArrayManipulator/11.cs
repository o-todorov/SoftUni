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

            int currCount = 0;
            int[] res = new int[count];

            if (even)
            {
                for (int i = arr.Length - 1; i >= 0 && currCount < count; i--)
                {
                    if (isEven(arr[i]))
                    {
                        res[currCount] = arr[i];
                        currCount++;
                    }
                }
            }
            else
            {
                for (int i = arr.Length - 1; i >= 0 && currCount < count; i--)
                {
                    if (!isEven(arr[i]))
                    {
                        res[currCount] = arr[i];
                        currCount++;
                    }
                }
            }

            int[] outArr = new int[currCount ];
            Array.Copy(res, 0, outArr, 0, currCount );
            Array.Reverse(outArr);

            printArr(outArr);
        }

        private static void findFirst(int count, bool even)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int currCount = 0;
            int[] res = new int[count];

            if (even)
            {
                for (int i = 0; i < arr.Length && currCount < count; i++)
                {
                    if (isEven(arr[i]))
                    {
                        res[currCount] = arr[i];
                        currCount++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr.Length && currCount < count; i++)
                {
                    if (!isEven(arr[i]))
                    {
                        res[currCount] = arr[i];
                        currCount++;
                    }
                }
            }

            int[] outArr = new int[currCount ];
            Array.Copy(res, 0, outArr, 0, currCount );

            printArr(outArr);
        }

        private static void findMin(bool even)
        {
            {
                int min = int.MaxValue;
                int idx = -1;

                if (even)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (isEven(arr[i]) && arr[i] <= min)
                        {
                            min = arr[i];
                            idx = i;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (!isEven(arr[i]) && arr[i] <= min)
                        {
                            min = arr[i];
                            idx = i;
                        }
                    }
                }


                if (idx == -1) Console.WriteLine("No matches");
                else Console.WriteLine(idx);
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
