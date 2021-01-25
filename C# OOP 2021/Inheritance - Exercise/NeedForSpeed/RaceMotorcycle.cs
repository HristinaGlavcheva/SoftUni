namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double raceMotorcycleDefaultFuelConsumtion = 8;

        public RaceMotorcycle(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
            this.FuelConsumption = raceMotorcycleDefaultFuelConsumtion;
        }
    }
}
