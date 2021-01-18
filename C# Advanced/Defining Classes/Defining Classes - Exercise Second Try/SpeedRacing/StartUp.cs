using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int countOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < countOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]); 
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);
                double travelledDistance = 0;

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer, travelledDistance);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            while(command != "End")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = cmdArgs[1];
                double amountOfKm = double.Parse(cmdArgs[2]);

                var currCars = cars.Where(c => c.Model == carModel).ToList();

                Car currCar = currCars[0];

                currCar.GetChangesFromTravel(amountOfKm);

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
