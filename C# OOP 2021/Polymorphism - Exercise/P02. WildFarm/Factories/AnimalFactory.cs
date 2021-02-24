using System;

using P02._WildFarm.Common;
using P02._WildFarm.Models.Animals;

namespace P02._WildFarm.Factories
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string[] animalArgs)
        {
            string type = animalArgs[0].ToLower();
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);

            if (type == "cat")
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];
                return new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "tiger")
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];
                return new Tiger(name, weight, livingRegion, breed);
            }
            else if (type == "dog")
            {
                string livingRegion = animalArgs[3];
                return new Dog(name, weight, livingRegion);
            }
            else if (type == "mouse")
            {
                string livingRegion = animalArgs[3];
                return new Mouse(name, weight, livingRegion);
            }
            else if (type == "owl")
            {
                double wingSize = double.Parse(animalArgs[3]);
                return new Owl(name, weight, wingSize);
            }
            else if (type == "hen")
            {
                double wingSize = double.Parse(animalArgs[3]);
                return new Hen(name, weight, wingSize);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidAnymalTypeMessage);
            }
        }
    }
}

