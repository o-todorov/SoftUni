using System;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {

            LinkedList list = new LinkedList();

            for (int i = 0; i < 9; i++)
            {
                list.AddHead(i);
            }

            Console.WriteLine("\nAfter added heads:");
            Console.WriteLine(list);

            for (int i = 0; i < 9; i++)
            {
                list.AddTail(i);
            }

            Console.WriteLine("\nAfter added tails:");
            Console.WriteLine(list);


            Console.WriteLine("\nValues > 3:");
            Console.WriteLine( list.Where(i => i > 3));

            Console.WriteLine($"\nFound Node {list.FindFirstOrDefault(4).Value}");

            Console.WriteLine((list.RemoveFirstFound(5)) ? "Removed 5" :"Not removed 5");
            Console.WriteLine((list.RemoveFirstFound(5)) ? "Removed 5" :"Not removed 5");
            Console.WriteLine((list.RemoveFirstFound(5)) ? "Removed 5" :"Not removed 5");

            Console.WriteLine("\nAfter remove first:");
            list.RemoveFirst();
            Console.WriteLine(list);

            Console.WriteLine("\nAfter remove last:");
            list.RemoveLast();
            Console.WriteLine(list);

            Console.WriteLine(list.Exist(7) ? "\nExist 7" : "\nNot Exist 7");

            Console.WriteLine("\nAfter remove All 7:");
            list.RemoveAll(7);
            Console.WriteLine(list);

            Console.WriteLine(list.Exist(7) ? "\nExist 7" : "\nNot Exist 7");

            int sum = 0;
            list.ForEach(i => sum += i);
            Console.WriteLine($"\nSum from forEach is: {sum}");

            Console.WriteLine("\nPrint as Array:");
            Console.WriteLine(string.Join("; ", list.ToArray()));

            Node t = list.FindFirstOrDefault(2);
            if (t != null)
            {
                if(t.Previous!=null)
                    Console.WriteLine($"\nPrevious of first 2 is: {t.Previous}");
                else Console.WriteLine($"\nPrevious of first 2 is: null");

                if(t.Next!=null)
                    Console.WriteLine($"\nNext of first 2 is: {t.Next}");
                else Console.WriteLine($"\nNext of first 2 is: null");
            }

            Console.WriteLine("\nDelete first 4 and 3");
            list.RemoveFirstFound(4);
            list.RemoveFirstFound(3);
            Console.WriteLine(list);

            Console.WriteLine("\nAfter Reverse:");
            list.Reverse();
            Console.WriteLine(list);

        }
    }
}
