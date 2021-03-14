using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            {
                string ID = Console.ReadLine();
                List<Creature> passers = new List<Creature>();

                while (ID.ToLower() != "end")
                {
                    var info = ID.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    AddHavingBirthday(passers, info);

                    ID = Console.ReadLine();
                }

                var yearToCompare = int.Parse( Console.ReadLine().Trim());

                passers.Where(p => p.Birthday.Year.Equals(yearToCompare))
                       .ToList()
                       .ForEach(p => Console.WriteLine($"{p.Birthday.ToString("dd/MM/yyyy")}"));
            }
        }
        private static void AddHavingBirthday(List<Creature> passers, string[] info)
        {
            switch (info[0])
            {
                case "Citizen":
                    passers.Add(new Citizen(info[1], int.Parse(info[2]), info[3], DateTime.ParseExact(info[4], "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                    break;
                case "Pet":
                    passers.Add(new Pet(info[1], DateTime.ParseExact(info[2], "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                    break;
                default:
                    break;
            }
        }

    }
}
