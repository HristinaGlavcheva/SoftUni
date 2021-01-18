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

        private Engine engine;

        private Tire[] tires;

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

        public Engine Engine
        {
            get { return this.engine; }

            set { this.engine = value; }
        }

        public Tire[] Tires
        {
            get { return this.tires; }

            set { this.tires = value; }
        }

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(
            string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(
            string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption,
            Engine engine,
            Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
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
            sb.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            sb.Append($"FuelQuantity: {this.FuelQuantity}");

            return sb.ToString();
        }

        public Func<Car, bool> SumTiresPressure = (Car car) =>
        {
            double sumTiresPressure = 0;

            foreach (var tire in car.Tires)
            {
                sumTiresPressure += tire.Pressure;
            }

            if(sumTiresPressure >= 9 && sumTiresPressure <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        };
    }
}
