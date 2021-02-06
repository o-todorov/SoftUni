using System.Collections.Generic;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;
        public Parking()
        {
            this.cars = new Dictionary<string, Car>();
        }
        public Parking(int capacity) : this()
        {
            this.capacity = capacity;
        }

        public Dictionary<string, Car> MyProperty { get => cars; set => cars = value; }
        public int Count { get => cars.Count; }
        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count == capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }

        }
        public string RemoveCar(string registrationNumber)
        {
            if (cars.ContainsKey(registrationNumber))
            {
                cars.Remove(registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            if (cars.ContainsKey(registrationNumber))
            {
                return cars[registrationNumber];
            }
            else
            {
                return null;
            }
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            registrationNumbers.ForEach(num =>
            {
                if (cars.ContainsKey(num)) cars.Remove(num);
            });
        }
    }
}
