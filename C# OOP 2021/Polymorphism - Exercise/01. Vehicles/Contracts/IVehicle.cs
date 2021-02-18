namespace _01._Vehicles.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        string Drive(double kilometers);

        void Refuel(double liters);
    }
}
