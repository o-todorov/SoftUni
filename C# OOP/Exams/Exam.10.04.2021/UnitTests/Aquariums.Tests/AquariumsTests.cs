namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private const string    correctName         = "Name";
        private const int       correctCapacity     = 50;
        private const int       incorrectCapacity   = -1;

        [SetUp]
        public void Setup()
        {
            aquarium = new Aquarium(correctName, correctCapacity);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PropName_ShouldThrowForInvalidName(string name)
        {
            Assert.That(()=>aquarium = new Aquarium(name, correctCapacity), Throws.ArgumentNullException);
        }

        [Test]
        public void Ctor_CorrectlySetName()
        {
            aquarium = new Aquarium(correctName, correctCapacity);

            Assert.That(aquarium.Name, Is.EqualTo(correctName));
        }

        [Test]
        public void PropCapacity_ShouldThrowForLessZero()
        {
            Assert.That(() => aquarium = new Aquarium(correctName, incorrectCapacity), Throws.ArgumentException);
        }

        [Test]
        public void Ctor_CorrectlySetCapacity()
        {
            aquarium = new Aquarium(correctName, correctCapacity);

            Assert.That(aquarium.Capacity, Is.EqualTo(correctCapacity));
        }


        [Test]
        public void Add_ShouldThrowIfCapacityExceded()
        {
            aquarium = new Aquarium(correctName, 1);
            aquarium.Add(new Fish("fish"));

            Assert.That(() => aquarium.Add(new Fish("fishTwo")), Throws.InvalidOperationException);
        }

        [Test]
        public void Add_ShouldIncreaseCountByOne()
        {
            aquarium.Add(new Fish("fish"));

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_ThrowsIfFisnDoesNotExist()
        {
            string fishToRemove = "NonExist";

            for (int i = 0; i < correctCapacity; i++)
            {
                aquarium.Add(new Fish($"fish{i}"));
            }

            Assert.That(()=>aquarium.RemoveFish(fishToRemove), Throws.InvalidOperationException);
        }

        [Test]
        public void Remove_ShouldDecreaseCountByOne()
        {
            string fishToRemove = "fish1";

            aquarium.Add(new Fish(fishToRemove));
            aquarium.Add(new Fish("fish"));

            Assert.That(aquarium.Count, Is.EqualTo(2));
            aquarium.RemoveFish(fishToRemove);
            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void SellFish_ThrowsIfFisnDoesNotExist()
        {
            string fishToSell = "NonExist";

            for (int i = 0; i < correctCapacity; i++)
            {
                aquarium.Add(new Fish($"fish{i}"));
            }

            Assert.That(() => aquarium.SellFish(fishToSell), Throws.InvalidOperationException);
        }

        [Test]
        public void SellFish_ShouldReturnCorrectFish()
        {
            string fishToSell = "fish";

            aquarium.Add(new Fish(fishToSell));
            Fish fish = aquarium.SellFish(fishToSell);

            Assert.That(fish.Name, Is.EqualTo(fishToSell));
            Assert.That(fish.Available, Is.EqualTo(false));
        }

        [Test]
        public void Report_ShouldReturnCorrectString()
        {
            string fishOne = "fishOne";
            string fishTwo = "fishTwo";

            aquarium.Add(new Fish(fishOne));
            aquarium.Add(new Fish(fishTwo));

            string fishes = $"{fishOne}, {fishTwo}";
            string expected = $"Fish available at {correctName}: {fishes}";

            Assert.That(aquarium.Report, Is.EqualTo(expected));
        }
    }
}
