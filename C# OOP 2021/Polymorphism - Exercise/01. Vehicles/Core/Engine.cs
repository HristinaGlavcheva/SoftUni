using _01._Vehicles.Commands;
using _01._Vehicles.Factories;
using _01._Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Vehicles.Core
{
    public class Engine
    {
        private VehicleFactory vehicleFactory;
        private Dictionary<string, ICommand> commands;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
            this.commands = new Dictionary<string, ICommand>();
            this.commands.Add("Drive", new DriveCommand());
            this.commands.Add("DriveEmpty", new DriveEmptyCommand());
            this.commands.Add("Refuel", new RefuelCommand());
        }

        public void Run()
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int countCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countCommands; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                try
                {
                    string commandType = commandArgs[0];

                    if (this.commands.ContainsKey(commandType))
                    {
                        ICommand command = this.commands[commandType];
                        command.Execute(car, truck, bus, commandArgs);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); ;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private Vehicle CreateVehicle()
        {
            string[] vehicleInput = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

            string type = vehicleInput[0];
            double fuelQuantity = double.Parse(vehicleInput[1]);
            double fuelConsumption = double.Parse(vehicleInput[2]);
            double tankCapacity = double.Parse(vehicleInput[3]);

            Vehicle vehicle = this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);
            return vehicle;
        }
    }
}
