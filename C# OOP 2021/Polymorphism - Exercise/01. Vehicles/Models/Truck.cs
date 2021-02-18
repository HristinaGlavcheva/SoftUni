namespace _01._Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditionerFuelConsumptionIncreasment = 1.6;
        private const double KeepedFuelCoeficient = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption 
            => base.FuelConsumption + AirConditionerFuelConsumptionIncreasment;

        public override void Refuel(double liters)
        {
            base.Refuel(liters * KeepedFuelCoeficient);
        }
    }
}
