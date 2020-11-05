using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int people = int.Parse(Console.ReadLine());

        int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse).ToArray();

        // For cicle ( 0 to wagon count-1 ) AND ( while people > 0 )
        // Работи и едновременно и като While - спира ако people<=0
        for (int i = 0; i < arr.Length && people > 0; i++)
        {
            int seats = Math.Min(4 - arr[i], people); // free spaces = 4 - arr[i]
            arr[i] += seats;   // настанява 'seats' пътника във вагона
                               // ако има 2ма чакащи и 3 своб. места -> остава 1 свободно и цикъла 
                               // спира понеже няма други чакащи
                               // ако има 3 своб. места и 5 пътника -> настанява 3ма и 2ма остават за следващия вагон
            people -= seats;
        }

        if (arr[arr.Length - 1] < 4) // Ако в последния вагон има своб. място ...
        {
            Console.WriteLine("The lift has empty spots!");
        }
        else if (people > 0) // Ако след края на цикъла вагоните са пълни и има останали пътници ...
        {
            Console.WriteLine($"There isn't enough space! {people} people in a queue!");
        }

        Console.WriteLine(string.Join(" ", arr));

    }
}
