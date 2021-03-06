using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string line;
            List<Animal> animals = new List<Animal>();

            while ((line = Console.ReadLine().Trim()) != "Beast!")
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Animal animal = null;

                try
                {
                    switch (line)
                    {
                        case "Cat":
                            animal = new Cat(info[0], int.Parse(info[1]), info[2]);
                            break;
                        case "Dog":
                            animal = new Dog(info[0], int.Parse(info[1]), info[2]);
                            break;
                        case "Frog":
                            animal = new Frog(info[0], int.Parse(info[1]), info[2]);
                            break;
                        case "Tomcat":
                            animal = new Tomcat(info[0], int.Parse(info[1]));
                            break;
                        case "Kitten":
                            animal = new Kitten(info[0], int.Parse(info[1]));
                            break;
                        default:
                            break;
                    }

                    animals.Add(animal);
                }
                catch (Exception )
                {
                        Console.WriteLine("Invalid input!");
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }

        }
    }
}
