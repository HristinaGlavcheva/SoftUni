using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_CarsSalesman
{
    public class ProgramEngine
    {
        private ICollection<Car> cars;
        private ICollection<Engine> engines;

        public ProgramEngine()
        {
            cars = new List<Car>();
            engines = new List<Engine>();
        }

        public void Run()
        {
            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Engine engine = this.CreateEngine(parameters);

                engines.Add(engine);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = this.CreateCar(parameters);

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private Car CreateCar(string[] parameters)
        {
            string model = parameters[0];
            string engineModel = parameters[1];

            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

            Car car = new Car(model, engine);

            int weight = -1;

            if (parameters.Length == 3)
            {
                bool hasWeight = int.TryParse(parameters[2], out weight);

                if (hasWeight)
                {
                    car = new Car(model, engine, weight);
                }
                else
                {
                    string color = parameters[2];
                    car = new Car(model, engine, color);
                }
            }
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                weight = int.Parse(parameters[2]);
                car = new Car(model, engine, weight, color);
            }

            return car;
        }

        private Engine CreateEngine(string[] parameters)
        {
            string model = parameters[0];
            int power = int.Parse(parameters[1]);

            Engine engine = new Engine(model, power);

            int displacement = -1;

            if (parameters.Length == 3)
            {
                bool hasDisplacement =  int.TryParse(parameters[2], out displacement);

                if (hasDisplacement)
                {
                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    string efficiency = parameters[2];
                    engine = new Engine(model, power, efficiency);
                }
            }
            else if (parameters.Length == 4)
            {
                displacement = int.Parse(parameters[2]);
                string efficiency = parameters[3];
                engine = new Engine(model, power, displacement, efficiency);
            }

            return engine;
        }
    }
}
