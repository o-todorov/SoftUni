using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Drivers
{
    public class Driver : IDriver
    {
        private string name;

        public Driver(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {

                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    string message = string.Format(ExceptionMessages.InvalidName, value, 5);
                    throw new ArgumentException(message);
                }

                name = value;
            }
        }

        public ICar Car { get; private set; } = null;

        public int NumberOfWins { get; private set; } = 0;

        public bool CanParticipate => Car != null;

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            Car = car;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
