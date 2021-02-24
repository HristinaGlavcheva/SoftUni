namespace _01._Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AirConditionerFuelConsumptionIncreasment = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
            => base.FuelConsumption + AirConditionerFuelConsumptionIncreasment;
    }
}
