namespace P03.Raiding.Models
{
    public abstract class BaseHero
    {
        public BaseHero(string name, string type)
        {
            this.Name = name;
            this.Type = type; 
        }
        
        public string Name { get; private set; }

        public string Type { get; private set; }

        public int Power { get; protected set; }

        public abstract string CastAbility();
    }
}
