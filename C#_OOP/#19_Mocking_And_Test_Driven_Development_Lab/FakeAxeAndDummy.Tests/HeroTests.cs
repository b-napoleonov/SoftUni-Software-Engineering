using FakeAxeAndDummy;
using FakeAxeAndDummy.Tests;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void GainXPWhenTargetIsDead()
    {
        string name = "Pesho";

        IWeapon fakeAxe = new FakeWeapon();
        ITarget fakeTarget = new FakeTarget();
        Hero hero = new Hero(name, fakeAxe);

        hero.Attack(fakeTarget);
        Assert.AreEqual(20, hero.Experience);
    }
}