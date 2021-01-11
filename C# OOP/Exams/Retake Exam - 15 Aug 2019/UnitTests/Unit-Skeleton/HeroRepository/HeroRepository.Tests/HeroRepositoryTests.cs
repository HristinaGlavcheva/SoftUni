using System;
using System.Collections.Generic;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero firstHero;
    private Hero secondHero;

    private HeroRepository data;

    [SetUp]
    public void Setup()
    {
        this.firstHero = new Hero("firstHero", 1);
        this.secondHero = new Hero("secondHero", 2);

        this.data = new HeroRepository();
        this.data.Create(firstHero);
        this.data.Create(secondHero);
    }

    [Test]
    public void HeroConstructorShouldWorkCorrectly()
    {
        Assert.That(firstHero.Name.Equals("firstHero"));
        Assert.That(firstHero.Level.Equals(1));

        Assert.That(secondHero.Name.Equals("secondHero"));
        Assert.That(secondHero.Level.Equals(2));
    }

    [Test]
    public void HeroRepositoryConstructorSetsCountCorrectly()
    {
        int expectedCount = 2;
        int actualCount = this.data.Heroes.Count;

        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    public void CreateShouldIncreaseCount()
    {
        Hero thirdHero = new Hero("thirdtHero", 3);

        this.data.Create(thirdHero);

        int expectedCount = 3;
        int actualCount = this.data.Heroes.Count;

        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    public void CreateShoudThrowArgumentNullExceptionIfHeroIsNull()
    {
        Hero thirdHero = null;

        Assert.That(
            () => this.data.Create(thirdHero),
            Throws.ArgumentNullException);
    }

    [Test]
    public void CreateShoudThrowInvalidOperationExceptionIfHeroExist()
    {
        Assert.That(
            () => this.data.Create(firstHero),
            Throws.InvalidOperationException);
    }

    [Test]
    public void RemoveShouldIncreaseCount()
    {
        this.data.Remove("firstHero");

        int expectedCount = 1;
        int actualCount = this.data.Heroes.Count;

        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    public void RemoveShoudThrowArgumentNullExceptionIfHeroNameIsNullOrWhitespace(string name)
    {
        Assert.That(
            () => this.data.Remove(name),
            Throws.ArgumentNullException);
    }

    [Test]
    public void GetHeroWithHighestLevelWorksProperly()
    {
        Hero expectedHero = secondHero;
        Hero actualHero = this.data.GetHeroWithHighestLevel();

        Assert.AreEqual(expectedHero, actualHero);
    }

    [Test]
    public void GetHerWorksProperly()
    {
        Hero expectedHero = secondHero;
        Hero actualHero = this.data.GetHero("secondHero");

        Assert.AreEqual(expectedHero, actualHero);
    }
}