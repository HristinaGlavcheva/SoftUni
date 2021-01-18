using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int countEngines = int.Parse(Console.ReadLine());

            HashSet<Engine> engines = new HashSet<Engine>();
            HashSet<Car> cars = new HashSet<Car>();

            for (int i = 0; i < countEngines; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                Engine engine = null;

                if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else if(engineInfo.Length == 3)
                {
                    int displacement;
                    bool thereIsDisplacement = int.TryParse(engineInfo[2], out displacement);

                    if (thereIsDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else 
                    {
                        string efficiency = engineInfo[2];
                        engine = new Engine(model, power, efficiency);
                    }
                }
                else if(engineInfo.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                engines.Add(engine);
            }

            int countCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < countCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = null;

                string model = carInfo[0];
                string engineModel = carInfo[1];

                Engine engine = engines.First(e => e.Model == engineModel);

                if (carInfo.Length == 4)
                {
                    int weight = int.Parse(carInfo[2]);
                    string color = carInfo[3];

                    car = new Car(model, engine, weight, color);
                }
                else if (carInfo.Length == 3)
                {
                    int weight;

                    bool thereIsWeight = int.TryParse(carInfo[2], out weight);

                    if (thereIsWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        string color = carInfo[2];

                        car = new Car(model, engine, color);
                    }
                }
                else if (carInfo.Length == 2)
                {
                    car = new Car(model, engine);
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
