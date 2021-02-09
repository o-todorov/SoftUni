using System;

namespace TupleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var tuple = new MyTuple<string, string>($"{input[0]} {input[1]}", input[2]);
            Console.WriteLine($"{tuple.item1} -> {tuple.item2}");

            input = Console.ReadLine().Split();
            var tupleOne = new MyTuple<string, int>(input[0], int.Parse(input[1]));
            Console.WriteLine($"{tupleOne.item1} -> {tupleOne.item2}");

            input = Console.ReadLine().Split();
            var tupleTwo = new MyTuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine($"{tupleTwo.item1} -> {tupleTwo.item2}");
        }
    }
}
