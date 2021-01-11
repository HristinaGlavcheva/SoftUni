using System;

namespace P01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionIncreasement = 1.6;
        private const double RefuelEffectivenessPercentage = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption = fuelConsumption + FuelConsumptionIncreasement;

            //другият вариант е да се ресетва чрез override на пропъртито - имплементиран е в клас Car
        }

        public override void Refuel(double refuelQuantity)
        {
            if (refuelQuantity <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            double availableSpace = this.TankCapacity - this.FuelQuantity;

            if (refuelQuantity > availableSpace)
            {
                throw new ArgumentException($"Cannot fit {refuelQuantity} fuel in the tank");
            }

            this.FuelQuantity += refuelQuantity * RefuelEffectivenessPercentage;
        }
    }
}
