using NUnit.Framework;

namespace Tests
{
    using CarManager;
    using System;

    public class CarTests
    {
        private const string carMake            = "Renault";
        private const string carModel           = "Laguna";
        private const double carFuelConsumption = 9.0;
        private const double carFuelCapacity    = 45.0;
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car(carMake, carModel, carFuelConsumption, carFuelCapacity); 
        }

        [Test]
        public void Ctor_CreatesCarWithZeroFuelAmount()
        {
            Assert.That(0.0, Is.EqualTo(car.FuelAmount));
        }

        [Test]
        public void Ctor_InitializeCarPropertiesCorrectly()
        {
            Assert.That(carMake             ,Is.EqualTo(car.Make)               );
            Assert.That(carModel            ,Is.EqualTo(car.Model)              );
            Assert.That(carFuelConsumption  ,Is.EqualTo(car.FuelConsumption)    );
            Assert.That(carFuelCapacity     ,Is.EqualTo(car.FuelCapacity)       );
        }

        [Test]
        [TestCase(null      , carModel  , carFuelConsumption    , carFuelCapacity)  ]
        [TestCase(""        , carModel  , carFuelConsumption    , carFuelCapacity)  ]
        [TestCase(carMake   , null      , carFuelConsumption    , carFuelCapacity)  ]
        [TestCase(carMake   , ""        , carFuelConsumption    , carFuelCapacity)  ]
        [TestCase(carMake   , carModel  , 0                     , carFuelCapacity)  ]
        [TestCase(carMake   , carModel  , -1                    , carFuelCapacity)  ]
        [TestCase(carMake   , carModel  , carFuelConsumption    , 0              )  ]
        [TestCase(carMake   , carModel  , carFuelConsumption    , -1             )  ]
        public void Ctor_ThrowsExeption_WhenInvalidArgument(string make, string model, double fuelconsumption, double fuelcapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelconsumption, fuelcapacity));
        }

        [Test]
        [TestCase(-1.0)]
        [TestCase(0.0)]
        public void Refuel_ThrowsExeption_WhenRefuelArgIsZeroOrNegativ(double invalidRefuelValue)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(invalidRefuelValue));
        }

        [Test]
        public void Refuel_UpdateFuelAmountCorrectly()
        {
            double fuelToAdd = carFuelCapacity / 2.0;
            car.Refuel(fuelToAdd);
            Assert.That(car.FuelAmount, Is.EqualTo(fuelToAdd));
        }

        [Test]
        public void Refuel_UpdateFuelAmountCorrectlyWhenOverRefuel()
        {
            car.Refuel(car.FuelCapacity * 1.2);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void Drive_ThrowsException_WhenFuelNotEnough()
        {
            car.Refuel(car.FuelCapacity);
            double distanceToDrive = (car.FuelCapacity / car.FuelConsumption) * 100 * 1.2;

            Assert.Throws<InvalidOperationException>(() => car.Drive(distanceToDrive));
        }

        [Test]
        public void Drive_UpdatesFuelAmountCorrectlyAfterDrive()
        {
            double fuelToUse        = car.FuelCapacity / 2;
            car.Refuel(fuelToUse);
            double distanceToDrive  = (fuelToUse / car.FuelConsumption) * 100;
            car.Drive(distanceToDrive);

            Assert.That(car.FuelAmount, Is.EqualTo(0.0));
        }
    }
}