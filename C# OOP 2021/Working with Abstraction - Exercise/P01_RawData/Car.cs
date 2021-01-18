using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Car
    {
        private ICollection<Tire> tires;

        public Car(string model, Engine engine, Cargo cargo, ICollection<Tire> tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.tires = tires;
        }

        public string Model { get; }

        public Engine Engine { get; }

        public Cargo Cargo { get; }

        public IReadOnlyCollection<Tire> Tires
        {
            get
            {
                return (IReadOnlyCollection<Tire>)tires;
            }
        }
    }
}
