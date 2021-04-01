using NUnit.Framework;

namespace Tests
{
    using ExtendedDatabase;
    using System;

    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase    database;
        private Person              testPerson;
        private const int           startPersonCount    = 5;
        private const int           capacity            = 16;
        [SetUp]

        public void Setup()
        {
            Person[] persons    = CreatePersonsArray(startPersonCount);
            database            = new ExtendedDatabase(persons);
            testPerson          = new Person(1000, "TestPerson");
        }

        private Person[] CreatePersonsArray(int count)
        {
            Person[] persons = new Person[count];
            for (int i = 0; i < count; i++)
            {
                persons[i] = new Person(i, $"Person-{i}");
            }
            return persons;
        }

        [Test]
        public void FindByUsername_ShouldThrow_ArgumentNullException_WhenArgumentIsNullOrEmpty()
        {
            Person person;
            Assert.Throws<ArgumentNullException>(() => person = database.FindByUsername(null));
            Assert.Throws<ArgumentNullException>(() => person = database.FindByUsername(""));
        }

        [Test]
        public void FindByUsername_ShouldThrow_InvalidOperationException_WhenUserNameDoesNotExist()
        {
            Person person;
            Assert.Throws<InvalidOperationException>(() => person = database.FindByUsername(testPerson.UserName));
        }

        [Test]
        public void FindByUsername_ShouldReturnPersonIfFound()
        {
            database.Add(testPerson);
            Person person = database.FindByUsername(testPerson.UserName);
            Assert.AreSame(testPerson, person);
        }

        [Test]
        public void FindById_ShouldThrow_ArgumentOutOfRangeException_WhenArgumentIsNegative()
        {
            Person person;
            Assert.Throws<ArgumentOutOfRangeException>(() => person = database.FindById(-1));
        }

        [Test]
        public void FindById_ShouldThrow_InvalidOperationException_WhenUsersIdDoesNotExist()
        {
            Person person;
            Assert.Throws<InvalidOperationException>(() => person = database.FindById(testPerson.Id));
        }

        [Test]
        public void FindById_ShouldReturnPersonIfFound()
        {
            database.Add(testPerson);
            Person person = database.FindById(testPerson.Id);
            Assert.AreSame(testPerson, person);
        }

        [Test]
        public void Add_ShouldThrow_InvalidOperationException_WhenCapacityIsExceded()
        {
            database = new ExtendedDatabase(CreatePersonsArray(capacity));
            Assert.Throws<InvalidOperationException>(() => database.Add(testPerson));
        }

        [Test]
        public void Add_ShouldThrow_InvalidOperationException_WhenNameExist()
        {
            database.Add(testPerson);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(testPerson.Id + 1, testPerson.UserName)));
        }

        [Test]
        public void Add_ShouldThrow_InvalidOperationException_WhenIdExist()
        {
            database.Add(testPerson);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(testPerson.Id, $"{testPerson.UserName}1")));
        }

        [Test]
        public void Add_ShouldIncreaseCountByOne_WhenOperationSuccsessfull()
        {
            database.Add(testPerson);
            Assert.AreEqual(startPersonCount + 1, database.Count);
        }

        [Test]
        public void Add_AddedPersonShouldExist_WhenOperationSuccsessfull()
        {
            database.Add(testPerson);
            Person checkPerson = database.FindByUsername(testPerson.UserName);
            Assert.AreEqual(testPerson, checkPerson);
        }

        [Test]
        public void Ctor_ShouldThrow_ArgumentException_WhenInputArrayIsOverCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            database = new ExtendedDatabase(CreatePersonsArray(capacity + 1))
            );
        }

        [Test]
        public void Ctor_SetsCountCorrectly()
        {
            Assert.AreEqual(startPersonCount, database.Count);
        }

        [Test]
        public void Remove_ShouldThrowInvalidOperationException_WhenCollIsEmpty()
        {
            database = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_ShouldDecreaseCountByOne_WhenOperationSuccsessfull()
        {
            database.Remove();
            Assert.AreEqual(startPersonCount - 1, database.Count);
        }

        [Test]
        public void Remove_RemovedPersonShouldNotExist()
        {
            database.Add(testPerson);
            database.Remove();
            Assert.Throws<InvalidOperationException>(() => database.FindById(testPerson.Id));
        }
    }
}