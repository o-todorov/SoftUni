namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RaceMotorcycle car = new RaceMotorcycle(200, 30);
            car.Drive(10);
            System.Console.WriteLine(car.Fuel);
        }
    }
}
