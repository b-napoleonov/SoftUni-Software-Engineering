using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository heroRep;
    private Hero hero;

    [SetUp]
    public void SetUp()
    {
        heroRep = new HeroRepository();
        hero = new Hero("Pesho", 100);
    }

    [Test]
    public void CreateThrowsExceptionWhenHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => heroRep.Create(null));
    }

    [Test]
    public void CreateThrowsExceptionWhenHeroAlreadyExists()
    {
        heroRep.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heroRep.Create(hero));
    }

    [Test]
    public void CreateReturnsRightMessage()
    {
        Assert.AreEqual("Successfully added hero Pesho with level 100", heroRep.Create(hero));
    }

    [Test]
    public void HeroesReturnsRightData()
    {
        heroRep.Create(hero);

        Assert.AreEqual(1, heroRep.Heroes.Count);
    }

    [Test]
    public void RemoveThrowsExceptionWhenHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => heroRep.Remove(null));
    }

    [Test]
    public void RemoveWorksRight()
    {
        heroRep.Create(hero);
        heroRep.Remove("Pesho");

        Assert.AreEqual(0, heroRep.Heroes.Count);
    }

    [Test]
    public void GetHeroWithHighestLevelWorksRight()
    {
        heroRep.Create(hero);
        heroRep.Create(new Hero("Gosho", 50));

        Assert.AreSame(hero, heroRep.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroReturnsRightHero()
    {
        Hero newHero = new Hero("Gosho", 50);

        heroRep.Create(hero);
        heroRep.Create(newHero);

        Assert.AreSame(newHero, heroRep.GetHero("Gosho"));
    }
}