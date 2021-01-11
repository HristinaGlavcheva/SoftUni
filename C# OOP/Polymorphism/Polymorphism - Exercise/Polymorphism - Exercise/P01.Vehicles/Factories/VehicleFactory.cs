﻿using P01.Vehicles.Models;
using System;

namespace P01.Vehicles.Factories
{
    public class VehicleFactory
    {
        public Vehicle ProduceVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle = null;

            if(type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type!");
            }

            return vehicle;
        } 
    }
}
