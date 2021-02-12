using System;
using System.Linq;

namespace Stack
{
    class CustomStackSturtUp
    {
        static void Main(string[] args)
        {
            {
                string[] input;
                var stack = new CustomStack<int>();

                while ((input = Console.ReadLine().Split(" ",2))[0] != "END")
                {
                    switch (input[0])
                    {
                        case "Push":
                            input[1].Split(", ")    
                                    .Select(int.Parse)
                                    .ToList()
                                    .ForEach(stack.Push);
                            break;
                        case "Pop":
                            try
                            {
                                stack.Pop();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("No elements");
                            }
                            break;
                        default:
                            Console.WriteLine("Unknown command!");
                            break;
                    }
                }

                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }

                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
