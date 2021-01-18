using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;

        private Engine engine;

        private Cargo cargo;

        private Tire[] tires;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model
        {
            get { return this.model; }

            set { this.model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }

            set { this.engine = value; }
        }

        public Cargo Cargo
        {
            get { return this.cargo; }

            set { this.cargo = value; }
        }

        public Tire[] Tires
        {
            get { return this.tires; }

            set { this.tires = value; }
        }

        public override string ToString()
        {
            return this.Model;
        }

        public Func<Car, bool> IsPressureLessThanOne = (Car car) =>
        {
            bool isPressureLessThanOne = false;

            foreach (var tire in car.tires)
            {
                if (tire.TirePressure < 1)
                {
                    isPressureLessThanOne = true;
                }
            }

            return isPressureLessThanOne;
        };
    }
}
