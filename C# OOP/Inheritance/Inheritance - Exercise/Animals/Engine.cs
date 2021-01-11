using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Engine
    {
        private readonly List<Animal> animals;  
        
        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string animalType = Console.ReadLine();

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine()
                    .Split(" ");

                Animal animal;

                try
                {
                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);
                    string gender = null;
                    gender = GetGender(animalInfo, gender);

                    animal = null;

                    if (animalType == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (animalType == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (animalType == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (animalType == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (animalType == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                this.animals.Add(animal);

            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private string GetGender(string[] animalInfo, string gender)
        {
            if (animalInfo.Length >= 3)
            {
                gender = animalInfo[2];
            }

            return gender;
        }
    }
}
