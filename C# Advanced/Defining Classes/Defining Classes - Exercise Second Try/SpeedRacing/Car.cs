using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;

        private double fuelAmount;

        private double fuelConsumptionPerKilometer;

        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = travelledDistance;
        }


        public string Model
        {
            get { return this.model; }

            set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }

            set { this.fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return this.fuelConsumptionPerKilometer; }

            set { this.fuelConsumptionPerKilometer = value; }
        }

        public double TravelledDistance
        {
            get { return this.travelledDistance; }

            set { this.travelledDistance = value; }
        }

        public void GetChangesFromTravel(double amountOfKm)
        {
            double neccesaryFuel = amountOfKm * this.FuelConsumptionPerKilometer;

            if(neccesaryFuel <= this.FuelAmount)
            {
                this.FuelAmount -= neccesaryFuel;
                this.TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
