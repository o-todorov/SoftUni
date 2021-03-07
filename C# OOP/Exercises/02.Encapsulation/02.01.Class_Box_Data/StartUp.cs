using System;

namespace ClassBox
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box box;

            try
            {
                box = new Box(GetDim(), GetDim(), GetDim());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine($"Surface Area - {box.SurfaceArea:f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea:f2}");
            Console.WriteLine($"Volume - {box.Volume:f2}");
        }

        private static double GetDim()
        {
            return double.Parse(Console.ReadLine());
        }
    }
}
