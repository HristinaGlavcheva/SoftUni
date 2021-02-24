using _01._Vehicles.Common;
using _01._Vehicles.Contracts;
using System;

namespace _01._Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private const double KeepedFuelCoeficientConst = 1;

        private double fuelQuantity;
        private double tankCapacity;
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.FuelConsumptionEmpty = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFuelQuantityMessage);
                }

                if (value > this.tankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption
        {
            get 
            {
                return this.fuelConsumption; 
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFuelConsumptionMessage);
                }

                this.fuelConsumption = value;
            }
        }

        public double FuelConsumptionEmpty { get; }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFuelConsumptionMessage);
                }

                this.tankCapacity = value;
            }
        }

        public virtual double KeepedFuelCoeficient => KeepedFuelCoeficientConst;

        public string Drive(double distance, double fuelConsumption)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (neededFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughFuelExceptionMessage, this.GetType().Name));
            }

            this.FuelQuantity -= this.FuelConsumption * distance;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters, double keepedFuelCoeficient)
        {
            if (liters <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidFuelQuantityMessage);
            }

            double freeTankSpace = this.TankCapacity - this.FuelQuantity;

            if(liters > freeTankSpace)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InsufficientTankCapacity, liters));
            }
            
            this.FuelQuantity += liters * keepedFuelCoeficient;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
