using System.Collections.Generic;

namespace P01_RawData
{
    public class Tire
    {
        public Tire(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        public double Pressure { get; }

        public int Age { get; }
    }
}
