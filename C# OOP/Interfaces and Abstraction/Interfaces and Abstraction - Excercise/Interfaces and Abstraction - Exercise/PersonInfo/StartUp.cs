using PersonInfo.Contracts;
using PersonInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        public static void Main()
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            int numberOfPeople = int.Parse(Console.ReadLine());
            ProcessPersonsInput(citizens, rebels, numberOfPeople);

            string name = Console.ReadLine();

            while (name != "End")
            {
                BuyingFood(citizens, rebels, name);

                name = Console.ReadLine();
            }

            int totalFoodAmount = rebels.Sum(r => r.Food) + citizens.Sum(c => c.Food);
            Console.WriteLine(totalFoodAmount);
        }

        private static void ProcessPersonsInput(List<Citizen> citizens, List<Rebel> rebels, int numberOfPeople)
        {
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = personInfo[0];
                int age = int.Parse(personInfo[1]);

                if (personInfo.Length == 4)
                {
                    CreateCitizen(citizens, personInfo, personName, age);
                }
                else if (personInfo.Length == 3)
                {
                    CreateRebel(rebels, personInfo, personName, age);
                }
            }
        }

        private static void CreateRebel(List<Rebel> rebels, string[] personInfo, string personName, int age)
        {
            string group = personInfo[2];

            Rebel rebel = new Rebel(personName, age, group);
            rebels.Add(rebel);
        }

        private static void CreateCitizen(List<Citizen> citizens, string[] personInfo, string personName, int age)
        {
            string id = personInfo[2];
            string birthDate = personInfo[3];

            Citizen citizen = new Citizen(personName, age, id, birthDate);
            citizens.Add(citizen);
        }

        private static void BuyingFood(List<Citizen> citizens, List<Rebel> rebels, string name)
        {
            if (citizens.Any(c => c.Name == name))
            {
                citizens.First(c => c.Name == name).BuyFood();
            }
            else if (rebels.Any(r => r.Name == name))
            {
                rebels.First(r => r.Name == name).BuyFood();
            }
        }
    }
}
