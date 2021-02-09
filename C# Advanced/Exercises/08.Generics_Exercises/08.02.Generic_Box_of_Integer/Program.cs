using System;

namespace _08._01.Generic_Box_of_String
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine().Trim()));
                Console.WriteLine(box);
            }
        }
    }
}
