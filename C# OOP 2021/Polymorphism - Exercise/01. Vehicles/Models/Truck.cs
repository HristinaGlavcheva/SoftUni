namespace _01._Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditionerFuelConsumptionIncreasment = 1.6;
        private const double KeepedFuelCoeficientConst = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption 
            => base.FuelConsumption + AirConditionerFuelConsumptionIncreasment;

        public override double KeepedFuelCoeficient => KeepedFuelCoeficientConst;

        //public override void Refuel(double liters)
        //{
        //    base.Refuel(liters * KeepedFuelCoeficient);
        //}

        //public override void Refuel(double liters)
        //{
        //    if (liters <= 0)
        //    {
        //        throw new ArgumentException(ExceptionMessages.InvalidFuelQuantityMessage);
        //    }

        //    double freeTankSpace = this.TankCapacity - this.FuelQuantity;

        //    if (liters > freeTankSpace)
        //    {
        //        throw new ArgumentException(string.Format(ExceptionMessages.InsufficientTankCapacity, liters));
        //    }

        //    this.FuelQuantity += liters;
        //}
    }
}
