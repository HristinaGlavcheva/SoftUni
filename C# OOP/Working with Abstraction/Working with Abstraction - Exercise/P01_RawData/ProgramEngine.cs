using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    class ProgramEngine
    {
        private readonly List<Car> cars;
        private readonly Tire[] tires;

        public ProgramEngine()
        {
            this.cars = new List<Car>();
            this.tires = new Tire[4];
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
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                double tire1Pressure = double.Parse(parameters[5]);
                int tire1age = int.Parse(parameters[6]);
                double tire2Pressure = double.Parse(parameters[7]);
                int tire2age = int.Parse(parameters[8]);
                double tire3Pressure = double.Parse(parameters[9]);
                int tire3age = int.Parse(parameters[10]);
                double tire4Pressure = double.Parse(parameters[11]);
                int tire4age = int.Parse(parameters[12]);

                Engine engine = this.CreateEngine(engineSpeed, enginePower);
                Cargo cargo = this.CreateCargo(cargoWeight, cargoType);

                Tire tire1 = this.CreateTire(tire1age, tire1Pressure);
                Tire tire2 = this.CreateTire(tire2age, tire2Pressure);
                Tire tire3 = this.CreateTire(tire3age, tire3Pressure);
                Tire tire4 = this.CreateTire(tire4age, tire4Pressure);

                Tire[] tires = new Tire[] { tire1, tire2, tire3, tire4 };

                Car car = this.CreateCar(model, engine, cargo, tires);
                this.cars.Add(car);
            }
        }

        private Cargo CreateCargo(int weight, string type)
        {
            return new Cargo(weight, type);
        }

        private Engine CreateEngine(int speed, int power)
        {
            return new Engine(speed, power);
        }

        private Tire CreateTire(int age, double pressure)
        {
            return new Tire(age, pressure);
        }

        private Car CreateCar(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            return new Car(model, engine, cargo, tires);
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

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                    .Select(c => c.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
