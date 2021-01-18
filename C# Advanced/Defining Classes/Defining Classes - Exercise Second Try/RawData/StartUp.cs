using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];

                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                double tire1Pressure = double.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                double tire2Pressure = double.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);
                double tire3Pressure = double.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                double tire4Pressure = double.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire[] tires = new Tire[4]
                {
                    new Tire(tire1Age, tire1Pressure),
                    new Tire(tire2Age, tire2Pressure),
                    new Tire(tire3Age, tire3Pressure),
                    new Tire(tire4Age, tire4Pressure)
                };

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars = cars
                    .Where(car => car.Cargo.CargoType == "fragile")
                    .Where(car => car.IsPressureLessThanOne(car))
                    .ToList();

                //cars = cars
                //    .Where(car => car.Cargo.CargoType == "fragile" &&
                //                  car.Tires.Any(t => t.TirePressure < 1))
                //                  .ToList();
            }

            if (command == "flamable")
            {
                cars = cars
                    .Where(car => car.Cargo.CargoType == "flamable")
                    .Where(car => car.Engine.EnginePower > 250)
                    .ToList();
            }

            //cars.ForEach(car => Console.WriteLine(car.Model));

            Console.WriteLine(String.Join(Environment.NewLine, cars));
        }
    }
}
