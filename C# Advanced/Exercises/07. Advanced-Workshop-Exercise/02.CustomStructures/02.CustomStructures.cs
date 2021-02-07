using System;
using System.Linq;

namespace CustomDataStructures
{
    class StartUp // Test Class
    {
        static void Main(string[] args)
        {
//  List Tests
            Console.WriteLine("Custom List Tests:\n");

            CustomList list = new CustomList(1, 8);
            Console.WriteLine(list);

            var contain = list.Contains(2);
            Console.WriteLine(contain ? "\nContains : 2": "\nDasn't contain 2");

            list.RemoveAt(1);
            Console.WriteLine("\nAfter remove 2 at index 1");
            Console.WriteLine(list);

            contain = list.Contains(2);
            Console.WriteLine(contain ? "\nContains : 2" : "\nDasn't contain 2");

            int found = list.Find(4);
            Console.WriteLine(found>-1 ? $"\nFound 4 at {found}" : $"\nNot Found 4");

            found = list.Find(11);
            Console.WriteLine($"\nIndex of 11:  {found}");

            found = list.Find(5);
            Console.WriteLine($"\nIndex of 5:  {found}");

            Console.WriteLine($"\nFound 3 at: {list.Find(3)}");

            Console.WriteLine($"\nPrint ToString(): \n{list.ToString()}");

            Console.WriteLine($"\nPrint Where values are even:");
            Console.WriteLine(list.Where(i => i % 2 == 0));

            Console.WriteLine($"\nPrint ToArray: \n{string.Join("-",list.ToArray())}");

            Console.WriteLine($"\nPrint Doubled values with forEach:");
            list.ForEach(i => Console.Write((i * 2).ToString() + " "));

            list.Insert(0,9);
            Console.WriteLine("\n\nAfter Insert 9 at index 0");
            Console.WriteLine(list);

            list.Insert(4,15);
            Console.WriteLine("\nAfter Insert 15 at index 4");
            Console.WriteLine(list);

            list.Insert(list.Count,25);
            Console.WriteLine("\nAfter Insert 25 at index list.count");
            Console.WriteLine(list);

            Console.WriteLine($"\nElement at index 3 (using indexer) is: {list[3]}");
            Console.WriteLine($"\nSet Element at index 3 (using indexer) to: 27");
            list[3] = 27;
            Console.WriteLine(list);

            list.Swap(2,5);
            Console.WriteLine("\nAfter swap 2 and 5");
            Console.WriteLine(list);

            list.Reverse();
            Console.WriteLine("\nAfter reverse");
            Console.WriteLine(list);

            list.Clear();
            Console.WriteLine("\nAfter Clear");
            Console.WriteLine(list);

            Console.WriteLine("\nAfter 5 adds");
            list.Add(5); list.Add(10); list.Add(15); list.Add(20); list.Add(25);
            Console.WriteLine(list);

            Console.WriteLine("\nAfter 5 removes");
            list.RemoveAt(0); list.RemoveAt(0); list.RemoveAt(0); list.RemoveAt(0); list.RemoveAt(0);
            Console.WriteLine(list);



            Console.WriteLine($"\nList Count: {list.Count}");

//  Stack Tests
            Console.WriteLine("\n\nCustom Stack Tests:\n");

            CustomStack stack = new CustomStack(Enumerable.Range(1, 15).ToArray());
            Console.WriteLine(stack);

            stack.Push(34);
            Console.WriteLine("\nAfter Push 34");
            Console.WriteLine(stack);

            int ret = stack.Pop();
            Console.WriteLine($"\nAfter Pop {ret}");
            Console.WriteLine(stack);

            stack.Pop(); stack.Pop(); stack.Pop(); stack.Pop(); stack.Pop();
            stack.Pop(); stack.Pop(); stack.Pop(); stack.Pop(); stack.Pop();
            Console.WriteLine($"\nAfter Pop 10 times");
            Console.WriteLine(stack);

            stack.Pop(); stack.Pop(); stack.Pop(); stack.Pop(); 
            Console.WriteLine($"\nAfter Pop 4 times");
            Console.WriteLine(stack);

            stack.Pop();  
            Console.WriteLine($"\nAfter Pop 1 time");
            Console.WriteLine(stack);

            Console.WriteLine($"\nStack Reset");
            stack = new CustomStack(Enumerable.Range(1, 15).ToArray());
            Console.WriteLine(stack);

            ret = stack.Peek();
            Console.WriteLine($"\nAfter Peek {ret}");
            Console.WriteLine(stack);

            Console.WriteLine($"\nForEach doubled values:");
            stack.ForEach(i => Console.Write((i * 2).ToString() + " "));

            stack.Clear();
            Console.WriteLine($"\n\nAfter Clear");
            Console.WriteLine(stack);

//  Queue Tests
            Console.WriteLine("\n\nCustom Queue Tests:\n");

            CustomQueue queue = new CustomQueue();
            Console.WriteLine(queue);

            Console.WriteLine($"\nAfter Enquee 5:");
            queue.Enqueue(5);
            Console.WriteLine(queue);

            Console.WriteLine($"\nAfter Initialization with array range 3-11:");
            queue = new CustomQueue(Enumerable.Range(3, 9).ToArray());
            Console.WriteLine(queue);

            Console.WriteLine($"\nAfter Dequee {queue.Dequeue()}:");
            Console.WriteLine(queue);

            Console.WriteLine($"\nAfter Dequee {queue.Dequeue()}:");
            Console.WriteLine(queue);

            Console.WriteLine($"\nAfter Dequee {queue.Dequeue()}:");
            Console.WriteLine(queue);

            Console.WriteLine($"\nAfter Enquee 34:");
            queue.Enqueue(34);
            Console.WriteLine(queue);

            Console.WriteLine($"\nAfter Enquee 35:");
            queue.Enqueue(35);
            Console.WriteLine(queue);

            Console.WriteLine($"\nAfter Enquee 36:");
            queue.Enqueue(36);
            Console.WriteLine(queue);

            Console.WriteLine($"\nAfter Enquee 37:");
            queue.Enqueue(37);
            Console.WriteLine(queue);

            Console.WriteLine($"\nDoubled Values using ForEach:");
            queue.ForEach(i => Console.Write(((int)i * 2).ToString() + " "));

            Console.WriteLine($"\n\nPrint through ToArray:");
            Console.WriteLine(string.Join(" ", queue));

            queue.Dequeue(); queue.Dequeue(); queue.Dequeue(); queue.Dequeue();
            queue.Dequeue(); queue.Dequeue(); queue.Dequeue(); queue.Dequeue();
            Console.WriteLine($"\nAfter Dequeue 8 times:");
            Console.WriteLine(queue);

            Console.WriteLine($"\nAfter Clear:");
            queue.Clear();
            Console.WriteLine(queue);

            Console.WriteLine($"\nAfter Enqueue 34 to empty queue:");
            queue.Enqueue(34);
            Console.WriteLine(queue);

            Console.WriteLine($"\nPeek element: {queue.Peek()}");

            Console.WriteLine($"\nAfter Dequeue {queue.Dequeue()}:");
            Console.WriteLine(queue);


        }
    }
}
