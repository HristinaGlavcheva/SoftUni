using System;

using P01.Vehicles.Models;
using P01.Vehicles.Factories;

namespace P01.Vehicles.Core
{
    public class Engine
    {
        private VehicleFactory vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }
        
        public void Run()
        {
            Vehicle car = ProduceVehicle();
            Vehicle truck = ProduceVehicle();
            Vehicle bus = ProduceVehicle();

            int countCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countCommands; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    ProcessCommand(car, truck, bus, cmdArgs);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ProcessCommand(Vehicle car, Vehicle truck, Vehicle bus, string[] cmdArgs)
        {
            string cmdType = cmdArgs[0];
            string vehicleType = cmdArgs[1];
            double value = double.Parse(cmdArgs[2]);

            if (cmdType == "Drive")
            {
                if (vehicleType == "Car")
                {
                    Console.WriteLine(car.Drive(value));
                }
                else if (vehicleType == "Truck")
                {
                    Console.WriteLine(truck.Drive(value));
                }
                else if (vehicleType == "Bus")
                {
                    Console.WriteLine(bus.Drive(value));
                }
            }
            else if(cmdType == "DriveEmpty")
            {
                Bus emptyBus = (Bus)bus;
                emptyBus.IsEmpty = true;

                Console.WriteLine(emptyBus.Drive(value));
            }
            else if (cmdType == "Refuel")
            {
                if (vehicleType == "Car")
                {
                    car.Refuel(value);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Refuel(value);
                }
                else if (vehicleType == "Bus")
                {
                    bus.Refuel(value);
                }
            }
        }

        private Vehicle ProduceVehicle()
        {
            string[] vehicleInfo = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = vehicleInfo[0];
            double fuelQuantity = double.Parse(vehicleInfo[1]);
            double fuelConsumption = double.Parse(vehicleInfo[2]);
            double tankCapacity = double.Parse(vehicleInfo[3]);

            Vehicle vehicle = this.vehicleFactory.ProduceVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);

            return vehicle;
        }

    }
}
