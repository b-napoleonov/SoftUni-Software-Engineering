using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void InitializeTest()
    {
        axe = new Axe(10, 2);
        dummy = new Dummy(30, 5);
    }

    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        axe.Attack(dummy);

        Assert.AreEqual(1, axe.DurabilityPoints, "Axe durability doesn't change after attack");
    }

    [Test]
    public void AttackingWithBrokenWeapon()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);

        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}