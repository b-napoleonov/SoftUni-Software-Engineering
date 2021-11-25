namespace FakeAxeAndDummy.Tests
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints => 1000;

        public int DurabilityPoints => 1000;

        public void Attack(ITarget target)
        {
            target.TakeAttack(AttackPoints);
        }
    }
}
