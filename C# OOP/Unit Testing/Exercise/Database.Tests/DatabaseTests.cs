using NUnit.Framework;
using System;
using System.Reflection.Metadata.Ecma335;

namespace Tests
{
    public class DatabaseTests
    {
        private const int DatabaseCapacity = 16;
        private readonly int[] data = new int[] { 1, 2, 3 };

        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(data);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        public void TestIfConstructorWorksCorrectly(int[] data)
        {
            //// Arrange
            //int[] data = new int[] { 1, 2, 3 };

            // Act
            Database.Database database = new Database.Database(data);

            // Assert
            int expectedCount = data.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfInitializedDatabaseWithBiggeroCollection()
        {
            // Arrange
            int[] data = new int[DatabaseCapacity + 1];

            // Assert
            Assert
                .Throws<InvalidOperationException>(() => new Database.Database(data));
        }

        [Test]
        public void AddOperationShouldIncreasesCount()
        {
            //// Arrange
            //int[] data = new int[3] { 1, 2, 3 };
            //Database.Database database = new Database.Database(data);

            // Act
            database.Add(15);

            // Assert

            int expectedCount = 4;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddOperationShouldAddAnElementAtTheNextFreeCell()
        {
            //// Arrange
            //int[] data = new int[3] { 1, 2, 3 };
            //Database.Database database = new Database.Database(data);

            // Act
            database.Add(15);

            // Assert

            int expectedElement = 15;
            int actualElement = database.Fetch()[database.Count - 1];

            Assert.AreEqual(expectedElement, actualElement);
        } 

        [Test]
        public void AddOperationShouldThrowExceptionWhenTryToExceedMaxCapacity()
        {
            // Arrange
            int[] data = new int[DatabaseCapacity];
            Database.Database database = new Database.Database(data);

            // Assert
            Assert.That(
                () => database.Add(15), // Act
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void RemoveOperationShouldDecreasesCount()
        {
            //// Arrange
            //int[] data = new int[] { 1, 2, 3 };
            //Database.Database database = new Database.Database(data);

            // Act
            database.Remove();

            int expectedCount = 2;
            int actualCount = database.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveOperationShouldRemoveLastElement()
        {
            //// Arrange
            //int[] data = new int[] { 1, 2, 3 };
            //Database.Database database = new Database.Database(data);

            // Act
            database.Remove();

            int expectedElement = 2;
            int actualElement = database.Fetch()[database.Count - 1];

            // Assert
            Assert.AreEqual(expectedElement, actualElement);
        }
        
        [Test]
        public void RemoveOperationShouldThrowExceptionWhenTryingToRemoveFromEmptyCollection()
        {
            // Arrange
            Database.Database databese = new Database.Database();

            // Assert
            Assert.That(() =>
            databese.Remove(), // Act
            Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void FetchMethodShouldReturnAllElementsAsArray()
        {
            //// Arrange
            //int[] data = new int[] { 1, 2, 3 };
            //Database.Database database = new Database.Database(data);

            // Act
            int[] expectedResult = { 1, 2, 3 };
            int [] actualResult = database.Fetch();

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);

            Assert.IsTrue(actualResult.GetType().IsArray);
        }
    }
}