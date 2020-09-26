using System;

namespace _02._11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            //{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})
            //(snowballSnow / snowballTime) ^ snowballQuality
            int snowBallCount = int.Parse(Console.ReadLine());

            string output = "";
            double maxQuality = 0;

            for (int i = 0; i < snowBallCount; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                double quality = Math.Pow(snowballSnow / snowballTime, snowballQuality);

                if (quality > maxQuality)
                {
                    maxQuality = quality;
                    output = $"{snowballSnow} : {snowballTime} = { quality} ({snowballQuality})";
                }
            }

            Console.WriteLine(output);

        }
    }
}
