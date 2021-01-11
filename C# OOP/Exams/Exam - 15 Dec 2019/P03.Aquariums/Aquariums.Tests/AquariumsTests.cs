namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        //[Test]
        //public void TestIfCtorWorks()
        //{
        //    var aquarium = new Aquarium("Varna", 5);

        //    Assert.AreEqual("Varna", aquarium.Name);
        //    Assert.AreEqual(5, aquarium.Capacity);
        //    Assert.AreEqual(0, aquarium.Count);
        //}

        //[Test]
        //public void TestIfCtorThrows()
        //{
        //    Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 1));
        //    Assert.Throws<ArgumentNullException>(() => new Aquarium("", 2));
        //    Assert.Throws<ArgumentException>(() => new Aquarium("Varba", -3));
        //}

        //[Test]
        //public void TestAdd()
        //{
        //    var aquarium = new Aquarium("Varna", 1);
        //    aquarium.Add(new Fish("Nemo"));
        //    Assert.AreEqual(1, aquarium.Count);
        //    Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Ivanka")));
        //}

        //[Test]
        //public void TestRemove()
        //{
        //    var aquarium = new Aquarium("Varna", 1);
        //    aquarium.Add(new Fish("Nemo"));
        //    Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Pesho"));
        //    Assert.AreEqual(1, aquarium.Count);
        //    aquarium.RemoveFish("Nemo");
        //    Assert.AreEqual(0, aquarium.Count);
        //}

        //[Test]
        //public void TestSell()
        //{
        //    var aquarium = new Aquarium("Varna", 1);
        //    aquarium.Add(new Fish("Nemo"));
        //    Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Pesho"));
        //    Assert.AreEqual(false, aquarium.SellFish("Nemo").Available);
        //}

        //[Test]
        //public void TestReport()
        //{
        //    var aquarium = new Aquarium("Varna", 1);
        //    aquarium.Add(new Fish("Nemo"));
        //    Assert.That(() => aquarium.Report() == "Fish available at Varna: Nemo");
        //}

        private const string AquariumName = "aquariumName";
        private const int Capacity = 3;

        private Fish firstFish;
        private Fish secondFish;

        private Aquarium aquarium;

        [SetUp]
        public void Setup()
        {
            this.firstFish = new Fish("firstFish");
            this.secondFish = new Fish("secondFish");

            this.aquarium = new Aquarium(AquariumName, Capacity);

            this.aquarium.Add(firstFish);
            this.aquarium.Add(secondFish);
        }

        
        [Test]
        public void AquariumConstructorSetsCountProperly()
        {
            int expectedCount = 2;
            int actualCount = this.aquarium.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AquariumConstuctorSetsProperlyNameAndCapacity()
        {
            Assert.That(this.aquarium.Name.Equals(AquariumName));
            Assert.That(this.aquarium.Capacity.Equals(Capacity));
        }

        [Test]
        public void FishConstuctorSetsProperlyNameAndAvailability()
        {
            Assert.That(firstFish.Name.Equals("firstFish"));
            Assert.That(firstFish.Available.Equals(true));

            Assert.That(secondFish.Name.Equals("secondFish"));
            Assert.That(secondFish.Available.Equals(true));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void NameSetterShouldThrowArgumentExceptionIfNameIsNullOrEmpty(string name)
        {
            Assert.That(
                () => new Aquarium(name, Capacity),
                Throws.ArgumentNullException);
        }

        [Test]
        public void CapacitySetterShouldThrowArgumentExceptionIfCapacityIsNegative()
        {
            Assert.That(
                () => new Aquarium("aquariumName", -5),
                Throws.ArgumentException);
        }

        [Test]
        public void AddOperationIncreasesCount()
        {
            Fish thirdFish = new Fish("thirdFish");

            this.aquarium.Add(thirdFish);

            int expectedCount = 3;
            int actualCount = this.aquarium.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddOperationThrowsInvalidOperationExceptionIfAquariumIsFull()
        {
            Fish thirdFish = new Fish("thirdFish");

            this.aquarium.Add(thirdFish);

            Fish fourthFish = new Fish("fourthFish");

            Assert.That(
                () => this.aquarium.Add(fourthFish),
                Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveOperationDecreasesCount()
        {
            this.aquarium.RemoveFish("firstFish");

            int expectedCount = 1;
            int actualCount = this.aquarium.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        
        [Test]
        public void RemoveOperationThrowsInvalidOperationExceptionIfFishDoesNotExist()
        {
            Assert.That(
                () => this.aquarium.RemoveFish("thirdFish"),
                Throws.InvalidOperationException);
        }

        [Test]
        public void SellOperationWorksCorrectly()
        {
            //this.aquarium.SellFish("firstFish");

            //Assert.That(firstFish.Available.Equals(false));

            Assert.AreEqual(false, aquarium.SellFish("firstFish").Available);
        }

        [Test]
        public void SellOperationThrowsInvalidOperationExcepitonIfFishDoesNotExist()
        {
            Assert.That(
               () => this.aquarium.SellFish("thirdFish"),
               Throws.InvalidOperationException);
        }

        [Test]
        public void ReportOperationWorksProperly()
        {
            Assert.That(
                () => this.aquarium.Report().Equals($"Fish available at {this.aquarium.Name}: firstFish, secondFish"));
        }
    }
}
