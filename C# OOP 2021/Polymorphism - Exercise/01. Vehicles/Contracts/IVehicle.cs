namespace _01._Vehicles.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        double FuelConsumptionEmpty { get; }

        double KeepedFuelCoeficient { get; }

        string Drive(double distance, double fuelConsumption);

        void Refuel(double liters, double keepedFuelCoeficient);
    }
}
