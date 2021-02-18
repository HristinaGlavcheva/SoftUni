using _01._Vehicles.Common;
using _01._Vehicles.Contracts;
using System;

namespace _01._Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        
        public double FuelQuantity { get; private set; }

        public virtual double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if(neededFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughFuelExceptionMessage, this.GetType().Name));
            }

            this.FuelQuantity -= this.FuelConsumption * distance;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
