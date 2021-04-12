using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Races;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Linq;

namespace EasterRaces.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MinRaceParticipants = 3;
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
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            var car = carRepository.GetByName(carModel);

            if (car == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var driver = driverRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            type += "Car";

            if (type == typeof(MuscleCar).Name)
            {
                carRepository.Add(new MuscleCar(model, horsePower));
            }
            else if (type == typeof(SportsCar).Name)
            {
                carRepository.Add(new SportsCar(model, horsePower));
            }

            return string.Format(OutputMessages.CarCreated, type, model);
        }

        public string CreateDriver(string driverName)
        {

            if (driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            driverRepository.Add(new Driver(driverName));

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {

            if (raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            raceRepository.Add(new Race(name, laps));

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count() < MinRaceParticipants )
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, MinRaceParticipants));
            }

            var drivers = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                              .Take(3)
                              .ToArray();

            var winner = drivers[0];

            winner.WinRace();
            raceRepository.Remove(race);

            string ret = string.Format(OutputMessages.DriverFirstPosition, winner.Name, raceName)           + Environment.NewLine
                       + string.Format(OutputMessages.DriverSecondPosition, drivers[1].Name, raceName)      + Environment.NewLine
                       + string.Format(OutputMessages.DriverThirdPosition, drivers[2].Name, raceName);

            return ret;
        }
    }
}
