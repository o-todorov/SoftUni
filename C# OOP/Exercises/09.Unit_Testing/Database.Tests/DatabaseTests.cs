using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    using Database;

    public class DatabaseTests
    {
        private Database emptydatabase;
        private Database database;
        private int[] arr;
        private const int count = 16;

        [SetUp]
        public void Setup()
        {
            arr = new int[count];

            for (int i = 0; i < count; i++)
            {
                arr[i] = i;
            }

            database = new Database(arr);
            emptydatabase = new Database();
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationException_WhenCapacityIsExceded()
        {
            Assert.Throws<InvalidOperationException>(() => database.Add(20));
        }

        [Test]
        public void Add_ShouldIncreaseDatabaseCount_WhenCapacityIsNotExceded()
        {
            emptydatabase.Add(1);
            emptydatabase.Add(2);
            Assert.AreEqual(2, emptydatabase.Count);
        }

        [Test]
        public void Add_NewValueShouldExist_WhenCapacityIsNotExceded()
        {
            int check = 3;
            emptydatabase.Add(1);
            emptydatabase.Add(check);
            int[] arr = emptydatabase.Fetch();
            Assert.IsTrue( arr.Contains(check));
        }

        [Test]
        public void Ctor_ShouldSetCountCorrectly()
        {
            Assert.AreEqual(0, emptydatabase.Count, "Incorrect Count value after constructor initialization");
            Assert.AreEqual(count, database.Count, "Incorrect Count value after constructor initialization");
        }

        [Test]
        public void Remove_ShouldThrowInvalidOperationException_WhenCollIsIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => emptydatabase.Remove());
        }

        [Test]
        public void Remove_ShouldDecreaseCount_WhenCollIsNotEmpty()
        {
            database.Remove();
            Assert.AreEqual(count - 1, database.Count);
        }

        [Test]
        public void Remove_ShouldRemoveValue_WhenCollIsNotEmpty()
        {
            int check = 20;
            emptydatabase.Add(10);
            emptydatabase.Add(check);
            emptydatabase.Remove();
            Assert.That(emptydatabase.Fetch(), !Contains.Item(check));
        }

        [Test]
        public void Fetch_ShouldNewArrayCountBeEqualToPresentCount()
        {
            int[] arr = database.Fetch();

            Assert.That(database.Count, Is.EqualTo(arr.Length));
        }

        [Test]
        public void Fetch_NewArrayShouldNotBeReferenceToDatabase()
        {
            int[] arrOne = database.Fetch();
            database.Remove();
            int[] arrTwo = database.Fetch();

            Assert.That(arrOne, !Is.EquivalentTo(arrTwo));
        }
    }
}