namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double BiologistInitialOxygen = 70;
        private const double BiologistOxygentDecreasment = 5;

        public Biologist(string name)
            : base(name, BiologistInitialOxygen)
        {
        }

        public override void Breath()
        {
            this.Oxygen -= BiologistOxygentDecreasment;

            if (this.Oxygen < 0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
