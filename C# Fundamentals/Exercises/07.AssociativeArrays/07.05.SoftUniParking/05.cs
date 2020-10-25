using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _07._05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            var validated = new Dictionary<string, User>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] comm = Console.ReadLine().Split();
                string userName = comm[1];

                if(comm[0]== "register")
                {
                    string numPlate = comm[2];

                    if (validated.ContainsKey(userName)){
                        Console.WriteLine($"ERROR: already registered with plate number {numPlate}");
                    }
                    else
                    {
                        validated[userName] = new User(userName,numPlate);
                        Console.WriteLine($"{userName} registered {numPlate} successfully");
                    }
                }
                else
                {
                    if (validated.ContainsKey(userName)){
                        validated.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                }
            }

            foreach (var user in validated.Values)
            {
                Console.WriteLine($"{user.Name} => {user.PlateNumber}");
            }

        }
    }

    class User
    {
        public User(string name, string plateNumber)
        {
            Name        = name;
            PlateNumber = plateNumber;
        }

        public string Name { get; set; }
        public string PlateNumber { get; set; }

    }
}
