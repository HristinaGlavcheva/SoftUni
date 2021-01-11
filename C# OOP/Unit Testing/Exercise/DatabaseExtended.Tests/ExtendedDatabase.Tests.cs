using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person firstPerson;
        private Person secondPerson;

        private ExtendedDatabase.ExtendedDatabase database;

        private Person[] persons;

        [SetUp]
        public void Setup()
        {
            this.firstPerson = new Person(123, "firstPerson");
            this.secondPerson = new Person(456, "secondPerson");
            this.persons = new Person[] { firstPerson, secondPerson };

            this.database = new ExtendedDatabase.ExtendedDatabase (persons);
        }

        [Test]
        public void ConstructorShouldSetProperlyCount()
        {
            // Arrange, Act
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(persons);

            int expectedCount = persons.Count();
            int actualCount = database.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorShouldSetProperlyUsernameAndId()
        {
            // Assert
            Assert.That(this.firstPerson.UserName == "firstPerson");
            Assert.That(this.firstPerson.Id == 123);
        }

        [Test]
        public void AddOperationShouldAddPersonIfCollectionIsNotFull()
        {
            // Act
            database.Add(new Person(789, "thirdPerson"));

            int expectedCount = 3;
            int actualCount = database.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddOperationShouldThrowExceptionIfCollectionIsFull()
        {
            // Arrange
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();

            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, $"Test {i}"));
            }

            // Assert
            Assert.That(
                () => database.Add(new Person(17, "Test 17")), // Act
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddOperationShouldThrowExceptionIfUsernameAlreadyExists()
        {
            // Assert
            Assert.That(
                () => database.Add(new Person(555, "firstPerson")), // Act
                Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddOperationShouldThrowExcepitonIfIdAlreadyExists()
        {
            // Assert
            Assert.That(
                () => database.Add(new Person(123, "someName")), // Act
                Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void RemoveOperationShouldRemovesPersonIfCollectionIsNotEmpty()
        {
            // Act
            database.Remove();

            int expectedCount = 1;
            int actualCount = database.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveOperationShouldThrowExceptionIfCollectionIsEmpty()
        {
            // Arrange
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();

            // Assert
            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
           
            //Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FindByUsernameOperatonShouldReturnCorrectPerson()
        {
            // Act
            Person expectedPerson = firstPerson;
            Person actualPerson = database.FindByUsername("firstPerson");

            // Assert
            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void FindByUsernameOperatonThrowsArgumentNullExceptionIfUsernameIsNull()
        {
            // Assert
            Assert.That(
                () => database.FindByUsername(null), // Act
                Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsernameOperatonThrowsExceptionIfSuchUsernameDoesNotExist()
        {
            // Arrange
            string name = "Pesho";

            // Assert
            Assert.That(
                () => database.FindByUsername(name), // Act
                Throws.InvalidOperationException);
        }

        [Test]
        public void FindByIdOperatonShouldReturnCorrectPerson()
        {
            // Act
            Person expectedPerson = firstPerson;
            Person actualPerson = database.FindById(123);

            // Assert
            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void FindByIdOperatonThrowsArgumentExceptionIfIdIsNegativeNumber()
        {
            long negativeIdToFind = -123;

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(negativeIdToFind));
        }

        [Test]
        public void FindByIdOperatonThrowsExceptionIfSuchIdDoesNotExist()
        {
            // Arrange
            long idToFind = 999;

            // Assert
            Assert.That(
                () => database.FindById(idToFind), // Act
                Throws.InvalidOperationException);

            Assert.That(
                () => database.FindById(idToFind),
                Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }
    }
}