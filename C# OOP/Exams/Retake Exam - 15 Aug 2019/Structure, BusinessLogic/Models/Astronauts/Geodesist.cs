namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double GeodesistInitialOxygen = 50;

        public Geodesist(string name)
            : base(name, GeodesistInitialOxygen)
        {
        }
    }
}
