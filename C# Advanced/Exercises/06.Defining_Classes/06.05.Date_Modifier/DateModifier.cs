using System;
using System.Linq;

namespace _06._05.Date_Modifier
{
    public static class DateModifier
    {
        public static int DateDayDiff(string dateOne,string dateTwo)
        {
            DateTime dateA = GetDate(dateOne);
            DateTime dateB = GetDate(dateTwo);
            return Math.Abs((dateA - dateB).Days);
        }

        private static DateTime GetDate(string strDate) // Format "yyyy mm dd"
        {
            var date = strDate.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();
            return new DateTime(date[0], date[1], date[2]);
        }
    }
}
