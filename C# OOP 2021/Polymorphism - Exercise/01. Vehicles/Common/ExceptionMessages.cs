namespace _01._Vehicles.Common
{
    public static class ExceptionMessages
    {
        public static string NotEnoughFuelExceptionMessage = "{0} needs refueling";
        public static string InvalidTypeExceptionMessage = "Invalid vehicle type!";
        public static string InvalidFuelQuantityMessage = "Fuel must be a positive number";
        public static string InvalidFuelConsumptionMessage = "Fuel cpnsumption must be a positive number";
        public static string InvalidTankCapacity = "Tank capacity must be a positive number";
        public static string InsufficientTankCapacity = "Cannot fit {0} fuel in the tank";
    }
}
