namespace FakeAxeAndDummy
{
    public interface ITarget
    {
        public int Health { get; }

        public bool IsDead();

        public void TakeAttack(int attackPoints);

        public int GiveExperience();
    }
}
