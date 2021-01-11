namespace Computers.Tests
{
    using NuGet.Frameworks;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class ComputerTests
    {
        private Part firstPart;
        private Part secondPart;

        private List<Part> parts;

        private Computer computer;

        [SetUp]
        public void Setup()
        {
            this.firstPart = new Part("firstPart", 10);
            this.secondPart = new Part("secondPart", 20);

            this.parts = new List<Part>();

            this.parts.Add(firstPart);
            this.parts.Add(secondPart);

            this.computer = new Computer("computer");

            this.computer.AddPart(firstPart);
            this.computer.AddPart(secondPart);
        }

        [Test]
        public void PartConstructorShouldWorksCorrectly()
        {
            Assert.That(firstPart.Name.Equals("firstPart"));
            Assert.That(firstPart.Price.Equals(10));

            Assert.That(secondPart.Name.Equals("secondPart"));
            Assert.That(secondPart.Price.Equals(20));
        }

        [Test]
        public void ComputerConstructorWorksCorrectly()
        {
            int expectedCount = 2;
            int actualCount = this.parts.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void NameSetterWorksCorrectly()
        {
            Assert.AreEqual("computer", this.computer.Name);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void NameSetterThrowsExceptionIfNameIsNullEmptyOrWhitespace(string name)
        {
            Assert.That(
                () => computer = new Computer(name),
                Throws.ArgumentNullException);
        }

        [Test]
        public void PartsWorksCorrectly()
        {
            Assert.AreEqual(2, this.computer.Parts.Count);
        }

        [Test]
        public void TotalPriceWorksCorrectly()
        {
            Assert.AreEqual(30, this.computer.TotalPrice);
        }

        [Test]
        public void AddPartWorksCorrectly()
        {
            Part thirdPart = new Part("thirtPart", 30);
            this.computer.AddPart(thirdPart);
            
            Assert.AreEqual(3, this.computer.Parts.Count);
        }

        [Test]
        public void AddPartThrowsExcepitonIfPartIsNull()
        {
            Part thirdPart = null;

            Assert.That(
                () => this.computer.AddPart(thirdPart),
                Throws.InvalidOperationException);
        }

        [Test]
        public void RemovePartWorksCorrectly()
        {
            this.computer.RemovePart(firstPart);

            Assert.AreEqual(1, this.computer.Parts.Count);
        }

        [Test]
        public void GetPartWorksCorrectly()
        {
            Part foundPart = this.computer.GetPart("firstPart");

            Assert.AreEqual(firstPart, foundPart);
        }
    }
}