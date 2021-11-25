namespace FakeAxeAndDummy.Tests
{
    public class FakeTarget : ITarget
    {
        public int Health => 10;

        public int GiveExperience() => 20;

        public bool IsDead() => true;

        public void TakeAttack(int attackPoints)
        {
            
        }
    }
}
