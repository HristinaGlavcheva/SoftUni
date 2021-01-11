namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)  //, double fuelConsumption = DefaultFuelConsumption - ако FuelConsumption не е virtual)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual double FuelConsumption
        {
            get { return DefaultFuelConsumption; }
        }

        public double Fuel { get; set; }

        public int HorsePower { get; private set; }

        public virtual void Drive(double kilometers)
        {
            bool canDrive = this.Fuel - this.FuelConsumption * kilometers >= 0;

            if (canDrive)
            {
                this.Fuel -= this.FuelConsumption * kilometers;
            }
        }
    }
}
