using FightingArena;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tests
{
    public class WarriorTests
    {
        private const double MinAttackHP = 30;

        private const string Name = "warriorName";
        private const int Damage = 50;
        private const int HP = 100;
        
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior(Name, Damage, HP);
        }

        [Test]
        public void ConstructorShouldInitializeWarriorProperly()
        {
            Assert.That(warrior.Name.Equals("warriorName"));
            Assert.That(warrior.Damage.Equals(50));
            Assert.That(warrior.HP.Equals(100));
        }

        //[Test]
        //[TestCase(null, Damage, HP)]
        //[TestCase("", Damage, HP)]
        //[TestCase(" ", Damage, HP)]
        //[TestCase(Name, -10, HP)]
        //[TestCase(Name, 0, HP)]
        //[TestCase(Name, Damage, -20)]
        //public void AllPropertiesGettersShoudThrowArgumentExceptionForInvalidValues
        //    (string name, int damage, int hp)
        //{
        //    Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        //}

        [Test]
        [TestCase(null, Damage, HP)]
        [TestCase("", Damage, HP)]
        [TestCase(" ", Damage, HP)]
        public void NameSetterShouldThrowArgumentExceptionIfNameIsNullEmptyOrWhitespace
            (string name, int damage, int hp)
        {
            Assert.That(
                () => new Warrior(name, damage, hp),
                Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        [TestCase(Name, -10, HP)]
        [TestCase(Name, 0, HP)]
        public void DamageSetterShouldThrowArgumentExceptionIfDamageValueIsZeroOrNegative
            (string name, int damage, int hp)
        {
            Assert.That(
                () => new Warrior(name, damage, hp),
                Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        [TestCase(Name, Damage, -20)]
        public void HpSetterShouldThrowArgumentExceptionIfHpValueIsNegative
            (string name, int damage, int hp)
        {
            Assert.That(
                () => new Warrior(name, damage, hp),
                Throws.ArgumentException.With.Message.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void AttackShouldThrowExceptionIfHpIsLowerThanMinHp()
        {
            Warrior warrior = new Warrior(Name, Damage, 20);

            string enemyName = "enemyName";
            int enemyDamage = 20;
            int enemyHP = 50;

             Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHP);

             Assert.That(
                () => warrior.Attack(enemy),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackShouldThrowExceptionIfEnemyHpIsLowerThanMinHp()
        {
            string enemyName = "enemyName";
            int enemyDamage = 20;
            int enemyHP = 20;

            Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHP);

            Assert.That(
               () => warrior.Attack(enemy),
               Throws.InvalidOperationException
               .With.Message.EqualTo($"Enemy HP must be greater than {MinAttackHP} in order to attack him!"));
        }

        [Test]
        public void AttackShouldThrowExceptionIfTryingToAttackStrongerEnemy()
        {
            string enemyName = "enemyName";
            int enemyDamage = 120;
            int enemyHP = 50;

            Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHP);

            Assert.That(
               () => warrior.Attack(enemy),
               Throws.InvalidOperationException
               .With.Message.EqualTo($"You are trying to attack too strong enemy"));
        }

        [Test]
        public void AttackShouldDecreaseWarriorHpByEnemyDamage()
        {
            string enemyName = "enemyName";
            int enemyDamage = 70;
            int enemyHP = 50;

            Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHP);

            warrior.Attack(enemy);

            int expectedWarriorHP = HP - enemyDamage;

            Assert.That(warrior.HP.Equals(expectedWarriorHP));
        }

        [Test]
        public void AttackShouldDecreaseEnemyHpByWarriorDamageIfWarrionDamageIsBiggerThanEnemyHp()
        {
            string enemyName = "enemyName";
            int enemyDamage = 70;
            int enemyHP = 40;

            Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHP);

            warrior.Attack(enemy);

            int expectedEnemyHP = 0;

            Assert.That(enemy.HP.Equals(expectedEnemyHP));
        }

        [Test]
        public void AttackShouldDecreaseEnemyHpByWarriorDamageIfWarrionDamageIsSmallerThanEnemyHp()
        {
            string enemyName = "enemyName";
            int enemyDamage = 70;
            int enemyHP = 80;

            Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHP);

            int expectedEnemyHP = enemy.HP - warrior.Damage;

            warrior.Attack(enemy);

            Assert.That(enemy.HP.Equals(expectedEnemyHP));
        }
    }
}