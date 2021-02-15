using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            Type     = type;
            Capacity = capacity;
            data     = new List<Car>();
        }
        private List<Car> data { get; set; }
        public string     Type { get; set; }
        public int        Capacity { get; set; }
        public int        Count => data.Count;

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            var carToRemove = GetCar(manufacturer, model);

            if (carToRemove != null)
            {
                data.Remove(carToRemove);
                return true;
            }

            return false;
        }
        public Car GetCar(string manufacturer, string model)
        {
            return data.FirstOrDefault(car => car.Manufacturer == manufacturer && car.Model == model);
        }
        public Car GetLatestCar()
        {
            return data.OrderByDescending(car => car.Year).FirstOrDefault();
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            sb.AppendLine(string.Join(Environment.NewLine, data));
            return sb.ToString();
        }
    }
}
