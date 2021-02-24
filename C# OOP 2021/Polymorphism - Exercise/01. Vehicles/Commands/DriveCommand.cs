using System;

using _01._Vehicles.Models;

namespace _01._Vehicles.Commands
{
    public class DriveCommand : ICommand
    {
        public void Execute(Vehicle car, Vehicle truck, Vehicle bus, string[] commandArgs)
        {
            string vehicleType = commandArgs[1];
            double value = double.Parse(commandArgs[2]);

            if (vehicleType == "Car")
            {
                Console.WriteLine(car.Drive(value, car.FuelConsumption));
            }
            else if (vehicleType == "Truck")
            {
                Console.WriteLine(truck.Drive(value, truck.FuelConsumption));
            }
            else if (vehicleType == "Bus")
            {
                Console.WriteLine(bus.Drive(value, bus.FuelConsumption));
            }
        }
    }
}
