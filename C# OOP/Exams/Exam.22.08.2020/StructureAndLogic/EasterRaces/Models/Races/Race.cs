using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace EasterRaces.Models.Races
{
    public class Race : IRace
    {
        private string                  name;
        private ICollection<IDriver>    drivers;
        private int                     laps;

        public Race(string name, int laps)
        {
            this.name       = name;
            this.laps       = laps;
            this.drivers    = new List<IDriver>();
        }

        public string Name
        {
            get => name;
            private set
            {
                string message = string.Format(ExceptionMessages.InvalidName, value, 5);

                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(message);
                }

                name = value;
            }
        }

        public int Laps
        {
            get => laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }

                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.ToImmutableList();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (driver.CanParticipate == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (drivers.Any(d=>d.Name.Equals(driver.Name)))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            drivers.Add(driver);
        }
    }
}
