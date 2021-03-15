using System;
using System.Collections.Generic;

namespace WildFarm
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string[] input;

            while ((input = Console.ReadLine().Split())[0].ToLower() != "end")
            {
                var animal  = ReadAnimal(input);
                input       = Console.ReadLine().Split();
                var food    = ReadFood(input);

                Console.WriteLine(animal.Ask());

                try
                {
                    animal.Feed(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                animals.Add(animal);
            }

            animals.ForEach(a => Console.WriteLine(a));

        }

        private static Animal ReadAnimal(string[] info)
        {
            Type classType = Type.GetType($"WildFarm.{info[0]}"); 

            if (classType != null)
            {
                object[] constructorArgs;

                switch (classType.BaseType.Name)
                {
                    case "Bird":
                        constructorArgs = new object[] { info[1], double.Parse(info[2]), double.Parse(info[3]) };
                        break;
                    case "Feline":
                        constructorArgs = new object[] { info[1], double.Parse(info[2]), info[3], info[4] };
                        break;
                    default:
                        constructorArgs = new object[] { info[1], double.Parse(info[2]), info[3] };
                        break;
                }

               return  Activator.CreateInstance(classType, constructorArgs) as Animal;
            }

            return null;
        }

        private static Food ReadFood(string[] info)
        {
            Type classType = Type.GetType($"WildFarm.{info[0]}");

            if (classType != null)
            {
                return Activator.CreateInstance(classType, int.Parse(info[1])) as Food;
            }

            return null;
        }
    }
}
