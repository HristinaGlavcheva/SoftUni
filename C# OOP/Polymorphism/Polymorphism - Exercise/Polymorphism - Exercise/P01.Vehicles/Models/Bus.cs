namespace P01.Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double FuelConsumptionIncreasement = 1.4;
        private double defaultFuelConsumption;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.defaultFuelConsumption = fuelConsumption;
        }

        public bool IsEmpty { get; set; }

        public override string Drive(double distance)
        {
            if (!this.IsEmpty)
            {
                this.FuelConsumption += FuelConsumptionIncreasement;
            }

            double neededFuel = this.FuelConsumption * distance;

            this.FuelConsumption = defaultFuelConsumption;

            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }

    }
}
