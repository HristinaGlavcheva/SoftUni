using _01._Vehicles.Models;
using System;

namespace _01._Vehicles.Commands
{
    public class DriveEmptyCommand : ICommand
    {
        public void Execute(Vehicle car, Vehicle truck, Vehicle bus, string[] commandArgs)
        {
            double value = double.Parse(commandArgs[2]);

            Console.WriteLine(bus.Drive(value, bus.FuelConsumptionEmpty));
        }
    }
}
