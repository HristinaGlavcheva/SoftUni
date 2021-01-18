using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{ 
    public class Car
    {
        private string make;

        private string model;

        private int year;

        private double fuelQuantity;

        private double fuelConsumption;

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }

            set { this.fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }

            set { this.fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            double necessaryFuel = distance * FuelConsumption / 100;

            if(necessaryFuel > FuelQuantity)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                FuelQuantity -= necessaryFuel;
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.Append($"Fuel: {this.FuelQuantity:F2}L");

            return sb.ToString();
        }
    }
}
