using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int removes = int.Parse(Console.ReadLine().Trim());
            var collections = new List<IAddCollection<string>>() 
                { new AddCollection<string>(), new AddRemoveCollection<string>(), new MyList<string>() };

            foreach (var collection in collections)
            {
                input.ForEach(str => Console.Write($"{collection.Add(str)} "));
                Console.WriteLine();
            }

            for (int i = 1; i <= 2; i++)
            {
                for (int j = 0; j < removes; j++)
                {
                    Console.Write($"{(collections[i] as IAddRemoveCollection<string>).Remove()} ");
                }

                Console.WriteLine();
            }
        }
    }
}
