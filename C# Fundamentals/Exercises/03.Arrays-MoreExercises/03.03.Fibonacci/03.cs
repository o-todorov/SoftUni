using System;

namespace _03._03.Fibonacci
{
    class Program
    {
        static ulong[] arr;
        static ulong[] memoArr;
        static ulong getFibonacci(int position)
        {
            if (position == 1 || position == 2) return 1;

            if(memoArr[position - 1] == 0) memoArr[position - 1] = getFibonacci(position - 1); 
            if(memoArr[position - 2] == 0) memoArr[position - 2] = getFibonacci(position - 2); 

            return memoArr[position - 1]+ memoArr[position - 2];
        }

        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());

            memoArr = new ulong[num+1];

            Console.WriteLine(getFibonacci(num));


        }
    }
}
