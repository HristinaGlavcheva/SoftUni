namespace P01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FuelConsumptionIncreasement = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption //другият вариант е да се ресетва през конструктора - имплементиран е в клас Truck
        {
            get
            {
                return base.FuelConsumption;
            }
            protected set
            {
                base.FuelConsumption = value + FuelConsumptionIncreasement;
            } 
        }
    }
}
