namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int SleepyDwarfIntialEnergy = 50;
        private const int SleepyDwarfEnergyDecreasement = 15;

        public SleepyDwarf(string name)
            : base(name, SleepyDwarfIntialEnergy)
        {
        }

        public override void Work()
        {
            this.Energy -= SleepyDwarfEnergyDecreasement;

            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}
