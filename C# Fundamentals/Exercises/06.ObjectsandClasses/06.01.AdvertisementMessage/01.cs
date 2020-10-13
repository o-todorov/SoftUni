using System;
using System.Text;

namespace _06._01.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] parts = new string[4][];

            parts[0] = new string[6];
            parts[1] = new string[6];
            parts[2] = new string[8];
            parts[3] = new string[5];

            loadArrays(parts[0], parts[1], parts[2], parts[3]);

            StringBuilder sb = new StringBuilder("");

            int count = int.Parse(Console.ReadLine());

            for (int j = 0; j < count; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    sb.Append(GetPart(parts[i])).Append(" ");
                }

                sb.Append("- ").Append(GetPart(parts[3]));

                Console.WriteLine(sb.ToString());

                sb.Clear();
            }

        }

        private static string GetPart(string[] arr)
        {
            Random rdm = new Random();
            int idx = rdm.Next(0, arr.Length - 1);

            return arr[idx];
        }

        private static void loadArrays(string[] phrases, string[] events, string[] authors, string[] cities)
        {
            Array.Copy(new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." }, 0, phrases, 0, 6);

            Array.Copy(new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" }, 0, events, 0, 6);

            Array.Copy(new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" }, 0, authors, 0, 8);

            Array.Copy(new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" }, 0, cities, 0, 5);
        }
    }
}
