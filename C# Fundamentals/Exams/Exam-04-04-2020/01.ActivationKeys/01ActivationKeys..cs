using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string key  = Console.ReadLine();
            string[] command;

            while ((command = Console.ReadLine().Split(">>>"))[0]!= "Generate")
            {
                switch (command[0])
                {
                    case "Contains":
                        string checkString = command[1];
                        CheckSubstring(key, checkString);
                        break;
                    case "Flip":
                        bool Capitals = (command[1] == "Upper");
                        int start   = int.Parse(command[2]);
                        int end     = int.Parse(command[3]);

                        var sb  = new StringBuilder(key.Substring(0, start));
                        
                        if (Capitals)
                        {
                            sb.Append(key.Substring(start, end - start).ToUpper());
                        }
                        else
                        {
                            sb.Append(key.Substring(start, end - start).ToLower());
                        }

                        sb.Append(key.Substring(end));
                        Console.WriteLine(key = sb.ToString());
                        break;
                    case "Slice":
                        start   = int.Parse(command[1]);
                        end     = int.Parse(command[2]);
                        Console.WriteLine(key = key.Remove(start,end-start));
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {key}"); 

        }

        private static void CheckSubstring(string key, string checkString)
        {
            if (Regex.Match(key, checkString).Success)
            {
                Console.WriteLine($"{key} contains {checkString}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
        }
    }
}
