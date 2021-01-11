using System;

namespace P01.Vehicles.Models
{
    public abstract class Vehicle
    {
        private double tankCapacity;
        private double fuelQuantity;
        private double fuelConsumption;
        
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }
        
        public double FuelQuantity { get; protected set; }
        
        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; private set; }

        public virtual string Drive(double distance)
        {
            double neededFuel = this.FuelConsumption * distance;

            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double refuelQuantity)
        {
            if(refuelQuantity <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            
            double availableSpace = this.TankCapacity - this.FuelQuantity;

            if(refuelQuantity > availableSpace)
            {
                throw new ArgumentException($"Cannot fit {refuelQuantity} fuel in the tank");
            }
            
            this.FuelQuantity += refuelQuantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
