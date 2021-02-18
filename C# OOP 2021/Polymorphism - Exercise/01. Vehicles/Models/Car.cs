namespace _01._Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AirConditionerFuelConsumptionIncreasment = 0.9;
        
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption 
            => base.FuelConsumption + AirConditionerFuelConsumptionIncreasment;
    }
}
