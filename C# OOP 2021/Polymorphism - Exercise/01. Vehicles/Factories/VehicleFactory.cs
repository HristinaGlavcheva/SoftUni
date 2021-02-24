using _01._Vehicles.Common;
using _01._Vehicles.Models;
using System;

namespace _01._Vehicles.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type, double fuelQunatity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle = null;
            
            if(type == "Car")
            {
                vehicle = new Car(fuelQunatity, fuelConsumption, tankCapacity);
            }
            else if(type == "Truck")
            {
                vehicle = new Truck(fuelQunatity, fuelConsumption, tankCapacity);
            }
            else if(type == "Bus")
            {
                vehicle = new Bus(fuelQunatity, fuelConsumption, tankCapacity);
            }

            if(vehicle == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidTypeExceptionMessage);
            }

            return vehicle;
        }
    }
}
