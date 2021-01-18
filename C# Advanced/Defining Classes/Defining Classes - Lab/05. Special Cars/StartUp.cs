using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string receivedTires = Console.ReadLine();

            List<Tire[]> allTires = new List<Tire[]>();

            while(receivedTires != "No more tires")
            {
                string[] tireInfo = receivedTires
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] tires = new Tire[4]
                {
                    new Tire(int.Parse(tireInfo[0]), double.Parse(tireInfo[1])),
                    new Tire(int.Parse(tireInfo[2]), double.Parse(tireInfo[3])),
                    new Tire(int.Parse(tireInfo[4]), double.Parse(tireInfo[5])),
                    new Tire(int.Parse(tireInfo[6]), double.Parse(tireInfo[7]))
                };

                allTires.Add(tires);

                receivedTires = Console.ReadLine();
            }

            string enginesDone = Console.ReadLine();

            List<Engine> allEngines = new List<Engine>();

            while (enginesDone != "Engines done")
            {
                string[] engineInfo = enginesDone
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                allEngines.Add(engine);

                enginesDone = Console.ReadLine();
            }

            string receivedCar = Console.ReadLine();

            List<Car> allCars = new List<Car>();

            while (receivedCar != "Show special")
            {
                string[] carInfo = receivedCar
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Engine curEngine = allEngines[engineIndex];
                Tire[] curTires = allTires[tiresIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, curEngine, curTires);

                allCars.Add(car);

                receivedCar = Console.ReadLine();
            }

            List<Car> specialCars = allCars
                .Where(car => car.Year >= 2017)
                .Where(car => car.Engine.HorsePower >= 330)
                .Where(car => car.SumTiresPressure(car))
                .ToList();

            foreach (var car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
