using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Races;
using EasterRaces.Repositories.Entities;
using System;
using System.Linq;

namespace EasterRaces.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository          carRepository;
        private DriverRepository    driverRepository;
        private RaceRepository        raceRepository;

        public ChampionshipController()
        {
            this.carRepository      = new CarRepository();
            this.driverRepository   = new DriverRepository();
            this.raceRepository     = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = driverRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new ArgumentException($"Driver {driverName} could not be found.");
            }

            var car = carRepository.GetByName(carModel);

            if (car == null)
            {
                throw new ArgumentException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new ArgumentException($"Race {raceName} could not be found.");
            }

            var driver = driverRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new ArgumentException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);

            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            var car = carRepository.GetByName(model);
            type += "Car";

            if (car != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            if (type == typeof(MuscleCar).Name)
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == typeof(SportsCar).Name)
            {
                car = new SportsCar(model, horsePower);
            }

            carRepository.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            var driver = driverRepository.GetByName(driverName);

            if (driver != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            driver = new Driver(driverName);
            driverRepository.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var race = raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            race = new Race(name, laps);
            raceRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count() < 3 )
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var drivers = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps));

            var winner  = drivers.First();
            var second  = drivers.Skip(1).First();
            var third   = drivers.Skip(2).First();

            winner.WinRace();
            raceRepository.Remove(race);

            string ret  = $"Driver {winner.Name} wins {raceName} race." + Environment.NewLine;
            ret         += $"Driver {second.Name} is second in {raceName} race." + Environment.NewLine;
            ret         += $"Driver {third.Name} is third in {raceName} race.";

            return ret;
        }
    }
}
