using Skeleton;

namespace Tests.Fakes
{
    public class FakeTarget : ITarget
    {
        public const int DefaultExpreience = 100;

        public int Health => 0;

        public int GiveExperience() => DefaultExpreience;

        public bool IsDead() => true;

        public void TakeAttack(int attackPoints)
        {
            
        }
    }
}
