using System;

using _01._Vehicles.Models;

namespace _01._Vehicles.Commands
{
    public class RefuelCommand : ICommand
    {
        public void Execute(Vehicle car, Vehicle truck, string[] commandArgs)
        {
            string vehicleType = commandArgs[1];
            double value = double.Parse(commandArgs[2]);

            if (vehicleType == "Car")
            {
                car.Refuel(value);
            }
            else if (vehicleType == "Truck")
            {
                truck.Refuel(value);
            }
        }
    }
}
