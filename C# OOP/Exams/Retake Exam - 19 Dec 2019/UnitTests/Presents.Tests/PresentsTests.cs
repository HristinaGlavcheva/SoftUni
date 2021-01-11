namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PresentsTests
    {
        private Present firstPresent;
        private Present secondPresent;
        
        private Bag bag;
        private IReadOnlyCollection<Present> presents;

        [SetUp]
        public void Setup()
        {
            this.firstPresent = new Present("firstPresent", 10);
            this.secondPresent = new Present("secondPresent", 20);

            this.bag = new Bag();

            this.bag.Create(firstPresent);
            this.bag.Create(secondPresent);

            this.presents = this.bag.GetPresents();
        }

        [Test]
        public void PresentConstructorWorksCorrectly()
        {
            Assert.AreEqual("firstPresent", firstPresent.Name);
            Assert.AreEqual(10, firstPresent.Magic);

            Assert.AreEqual("secondPresent", secondPresent.Name);
            Assert.AreEqual(20, secondPresent.Magic);
        }

        [Test]
        public void BagConstructorWorksCorrectrly()
        {
            int expectedCount = 2;
            int actualCount = this.presents.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CreateShouldAddPresents()
        {
            Present thirdPresent = new Present("secondtPresent", 20);
            this.bag.Create(thirdPresent);

            int expectedCount = 3;
            int actualCount = this.presents.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CreateShouldThrowArgumentNullExceptionIfPresentIsNull()
        {
            Present thirdPresent = null;

            Assert.That(
                () => this.bag.Create(thirdPresent),
                Throws.ArgumentNullException);
        }

        [Test]
        public void CreateShouldThrowInvalidOperationExceptionIfPresentAlreadyExists()
        {
            Assert.That(
                () => this.bag.Create(secondPresent),
                Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            this.bag.Remove(firstPresent);

            int expectedCount = 1;
            int actualCount = this.presents.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveWorksCorrectly()
        {
            this.bag.Remove(firstPresent);

            Assert.That(!this.presents.Any(p => p == firstPresent));
        }

        [Test]
        public void GetPresentWithLeastMagicWorksCorrectly()
        {
            Assert.That(
                () => this.bag.GetPresentWithLeastMagic() == firstPresent);
        }

        [Test]
        public void GetPresentWorksCorrectly()
        {
            Assert.That(
                () => this.bag.GetPresent("firstPresent") == firstPresent);
        }

        [Test]
        public void GetPresentsWorksCorrectly()
        {
            Assert.That(
                () => this.bag.GetPresents().Count == this.presents.Count);
        }
    }
}
