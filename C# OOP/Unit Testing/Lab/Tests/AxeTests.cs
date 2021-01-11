using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    class AxeTests
    {
        private const int AtackPoints = 10;

        private Dummy dummy;

        [SetUp]
        public void SetDummy()
        {
            this.dummy = new Dummy(100, 100);
        }
        
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            // Arrange
            Axe axe = new Axe(AtackPoints, 10);

            // Act
            axe.Attack(this.dummy);

            // Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability dosn't change after attack");
        }

        [Test]
        public void CannotAttackWithBrokenAxe()
        {
            // Arrange
            Axe axe = new Axe(AtackPoints, 0);

            // Assert
            Assert.That(
                () => axe.Attack(this.dummy), // Act
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."),
                "Axe should throw exception if an attack is made with broken weapon.");
        }
    }
}
