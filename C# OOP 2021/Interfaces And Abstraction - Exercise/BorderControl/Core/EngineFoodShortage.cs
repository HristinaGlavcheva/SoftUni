using BorderControl.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;

using BorderControl.Models;

namespace BorderControl.Core
{
    public class EngineFoodShortage : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private List<IRebel> rebels;
        private List<ICitizen> citizens;

        public EngineFoodShortage(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

            this.rebels = new List<IRebel>();
            this.citizens = new List<ICitizen>();
        }

        public void Run()
        {
            ParsePeopleInfoInput();
            ParseBuyingFodInput();
            PrintTotalFood();
        }

        private void PrintTotalFood()
        {
            this.writer.WriteLine((this.citizens.Sum(c => c.Food) + this.rebels.Sum(r => r.Food)).ToString());
        }

        private void ParseBuyingFodInput()
        {
            string name = this.reader.ReadLine();

            while (name != "End")
            {
                ICitizen citizen = this.citizens.FirstOrDefault(c => c.Name == name);
                IRebel rebel = this.rebels.FirstOrDefault(r => r.Name == name);

                if (citizen != null)
                {
                    citizen.BuyFood();
                }
                else if (rebel != null)
                {
                    rebel.BuyFood();
                }

                name = this.reader.ReadLine();
            }
        }

        private void ParsePeopleInfoInput()
        {
            int countPeople = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < countPeople; i++)
            {
                string[] personInfo = this.reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (personInfo.Length == 4)
                {
                    AddCitizen(personInfo);
                }
                else if (personInfo.Length == 3)
                {
                    AddRebel(personInfo);
                }
            }
        }

        private void AddRebel(string[] personInfo)
        {
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);
            string group = personInfo[2];

            Rebel rebel = new Rebel(name, age, group);
            this.rebels.Add(rebel);
        }

        private void AddCitizen(string[] personInfo)
        {
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);
            string id = personInfo[2];
            string birthDate = personInfo[3];

            Citizen citizen = new Citizen(name, age, id, birthDate);
            this.citizens.Add(citizen);
        }
    }
}

