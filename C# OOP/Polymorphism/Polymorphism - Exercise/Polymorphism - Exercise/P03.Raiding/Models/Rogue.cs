namespace P03.Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int DefaultPower = 80;

        public Rogue(string name, string type)
            : base (name, type)
        {
            this.Power = DefaultPower;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
