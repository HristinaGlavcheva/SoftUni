namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private const double vehicleDefaultFuelConsumption = 1.25;
        
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.FuelConsumption = vehicleDefaultFuelConsumption;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double kilometers)
        {
            bool haveEnouhgFuel = this.Fuel - kilometers * this.FuelConsumption >= 0;

            if (haveEnouhgFuel)
            {
                this.Fuel -= kilometers * this.FuelConsumption;
            }
        }
    }
}
