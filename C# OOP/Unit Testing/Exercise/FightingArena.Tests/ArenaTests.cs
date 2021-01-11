using FightingArena;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private Warrior firstWarrior;
        private Warrior secondWarrior;

        private List<Warrior> warriors;

        private Arena arena;
        
        [SetUp]
        public void Setup()
        {
            this.firstWarrior = new Warrior("firstWarrior", 50, 100);
            this.secondWarrior = new Warrior("secondWarrior", 70, 80);

            this.arena = new Arena();

            this.arena.Enroll(firstWarrior);
            this.arena.Enroll(secondWarrior);
        }

        [Test]
        public void ConstructorSetsProperlyCount()
        {
            int expectedCount = 2;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorSetsProperlyNameDamageAndHP()
        {
            Assert.That(firstWarrior.Name.Equals("firstWarrior"));
            Assert.That(firstWarrior.Damage.Equals(50));
            Assert.That(firstWarrior.HP.Equals(100));

            //или
            //Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollOperationIncreasesCount()
        {
            Warrior thirdWarrior = new Warrior("thirdWarrior", 120, 300);
            arena.Enroll(thirdWarrior);

            int expectedCount = 3;

            Assert.AreEqual(expectedCount, arena.Count);

            //или
            //Assert.That(arena.Warriors, Has.Member(firstWarrior));
        }

        [Test]
        public void EnrollOperationThrowsExceptionIfWarriorIsAlreadyEnrolled()
        {
            Warrior thirdWarrior = new Warrior("thirdWarrior", 120, 300);
            arena.Enroll(thirdWarrior);

            Assert.That(
                () => arena.Enroll(thirdWarrior),
                Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void FightOperationWorksProperly()
        {
            arena.Fight("firstWarrior", "secondWarrior");

            Assert.That(firstWarrior.HP.Equals(30));
            Assert.That(secondWarrior.HP.Equals(30));
        }

        [Test]
        [TestCase("someWarrior", "secondWarrior")]
        [TestCase("firstWarrior", "someWarrior")]
        public void FightOperationThrowsExceptionIfOneOfTheWarriorsIsNotEnrolled
            (string attackerName, string defenderName)
        {
            Assert.That(
                () => arena.Fight(attackerName, defenderName),
                Throws.InvalidOperationException);
        }
    }
}
