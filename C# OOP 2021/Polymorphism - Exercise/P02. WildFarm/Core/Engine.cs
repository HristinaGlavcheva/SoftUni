using P02._WildFarm.Factories;
using P02._WildFarm.Models.Animals;
using P02._WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._WildFarm.Core
{
    public class Engine
    {
        private FoodFactory foodFactory;
        private AnimalFactory animalFactory;
        private List<Animal> animals;

        public Engine()
        {
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                try
                {
                    string[] animalArgs = command
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .ToArray();

                    Animal animal = this.animalFactory.CreateAnimal(animalArgs);
                    this.animals.Add(animal);

                    string[] foodArgs = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    Food food = this.foodFactory.CreateFood(foodArgs);
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }

            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal.ProduceSound()); 
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
