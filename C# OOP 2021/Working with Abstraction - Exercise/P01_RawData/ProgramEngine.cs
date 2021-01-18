using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class ProgramEngine
    {
        private readonly List<Car> cars;
        private readonly List<Tire> tires;

        public ProgramEngine()
        {
            this.cars = new List<Car>();
            this.tires = new List<Tire>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());
            ParseInput(lines);
            PrintOutput();
        }

        private void ParseInput(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                Engine engine = this.CreateEngine(engineSpeed, enginePower);
                Cargo cargo = this.CreateCargo(cargoWeight, cargoType);
                this.CreateTires(parameters);

                Car car = this.CreateCar(model, engine, cargo, tires);

                this.cars.Add(car);
            }
        }

        private Engine CreateEngine(int engineSpeed, int enginePower)
        {
            return new Engine(engineSpeed, enginePower);
        }

        private Cargo CreateCargo(int cargoWeight, string cargoType)
        {
            return new Cargo(cargoWeight, cargoType);
        }

        private Tire CreateTire(double firstTirePressure, int firstTireAge)
        {
            return new Tire(firstTirePressure, firstTireAge);
        }

        private void CreateTires(string[] parameters)
        {
            for (int i = 5; i <= 12; i += 2)
            {
                double pressure = double.Parse(parameters[i]);
                int age = int.Parse(parameters[i + 1]);
                Tire tire = CreateTire(pressure, age);
                this.tires.Add(tire);
            }
        }

        private Car CreateCar(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            Car car = new Car(model, engine, cargo, tires.ToArray());

            return car;
        }

        private void PrintModels(List<string> cars)
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private void PrintOutput()
        {
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                    .Select(c => c.Model)
                    .ToList();

                PrintModels(fragile);
            }
            else
            {
                List<string> flamable = cars
                    .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                    .Select(c => c.Model)
                    .ToList();

                PrintModels(flamable);
            }
        }

    }
}
