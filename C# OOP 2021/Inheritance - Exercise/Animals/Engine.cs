using Animals.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class Engine
    {
        private readonly IIoEngine ioEngine;
        private readonly List<Animal> animals;

        public Engine(IIoEngine ioEngine)
        {
            this.ioEngine = ioEngine;
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string animalType = ioEngine.ReadLine();

            while (animalType != "Beast!")
            {
                string[] animalInfo = ioEngine.ReadLine()
                .Split()
                .ToArray();

                try
                {
                    Animal animal = CreateAnimal(animalType, animalInfo);

                    this.animals.Add(animal);
                }
                catch (ArgumentException ex)
                {
                    ioEngine.WriteLine(ex.Message);
                }

                PrintOutput(ioEngine);

                animalType = ioEngine.ReadLine();
            }
        }

        private void PrintOutput(IIoEngine reader)
        {
            foreach (Animal animal in animals)
            {
                reader.WriteLine(animal.ToString());
            }
        }

        private static Animal CreateAnimal(string animalType, string[] animalInfo)
        {
            Animal animal;
            string name = animalInfo[0];
            int age = int.Parse(animalInfo[1]);
            string gender = null;

            if (animalInfo.Length >= 3)
            {
                gender = animalInfo[2];
            }

            if (animalType == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (animalType == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (animalType == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else if (animalType == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (animalType == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}
