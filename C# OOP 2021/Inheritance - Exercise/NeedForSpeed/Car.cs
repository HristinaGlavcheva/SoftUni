namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double carDefaultFuelConsumption = 3;

        public Car(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
            this.FuelConsumption = carDefaultFuelConsumption;
        }
    }
}
