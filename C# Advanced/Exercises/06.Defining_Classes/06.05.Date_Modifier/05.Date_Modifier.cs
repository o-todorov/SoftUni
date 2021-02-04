using System;

namespace _06._05.Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            int dateDayDiff = DateModifier.DateDayDiff(dateOne, dateTwo);
            Console.WriteLine(dateDayDiff);
        }
    }
}
