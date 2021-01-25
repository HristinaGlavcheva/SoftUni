namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double sportCarDefaultFuelConsumption = 10;

        public SportCar(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
            this.FuelConsumption = sportCarDefaultFuelConsumption;
        }
    }
}
