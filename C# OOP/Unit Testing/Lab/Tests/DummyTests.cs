using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int AliveDummyHealth = 100;
        private const int DeadDummyHealth = 0;
        private const int Experience = 100;
        private const int AttackPoints = 10;
        
        private Dummy aliveDummy;
        private Dummy deadDummy;

        [SetUp]
        public void SetDummies()
        {
            this.aliveDummy = new Dummy(AliveDummyHealth, Experience);
            this.deadDummy = new Dummy(DeadDummyHealth, Experience);
        }
        
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            // Act
            this.aliveDummy.TakeAttack(AttackPoints);

            // Assert
            Assert.That(this.aliveDummy.Health, Is.EqualTo(90));
        }

        [Test]
        public void CannotAttackDeadDummy()
        {
            // Assert
            Assert.That(
                () => this.deadDummy.TakeAttack(AttackPoints), // Act
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyGivesExperience()
        {
            // Act
            this.deadDummy.GiveExperience();

            // Assert
            Assert.That(this.deadDummy.GiveExperience().Equals(Experience));
        }

        [Test]
        public void AliveDummyCannotGiveExperience()
        {
            // Assert
            Assert.That(
                () => this.aliveDummy.GiveExperience(), // Act
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
