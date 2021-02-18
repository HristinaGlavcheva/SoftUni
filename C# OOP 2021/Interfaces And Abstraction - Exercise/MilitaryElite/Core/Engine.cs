using System;
using System.Linq;
using System.Collections.Generic;

using MilitaryElite.Contracts;
using MilitaryElite.Models;
using MilitaryElite.Exceptions;
using MilitaryElite.Core.Contracts;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private ICollection<ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        
        public void Run()
        {
            string[] commandArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string soldierType = commandArgs[0];
            
            while(soldierType != "End")
            {
                ISoldier soldier = null;

                int id = int.Parse(commandArgs[1]);
                string firstName = commandArgs[2];
                string lastName = commandArgs[3];
                decimal.TryParse(commandArgs[4], out decimal salary);

                if(soldierType == "Private")
                {
                    soldier = CreatePrivate(id, firstName, lastName, salary);
                }
                else if(soldierType == "LieutenantGeneral")
                {
                    soldier = CreateGeneral(commandArgs, id, firstName, lastName, salary);
                }
                else if(soldierType == "Engineer")
                {
                    try
                    {
                        IEngineer engineer = CreateEngineer(commandArgs, id, firstName, lastName, salary);

                        soldier = engineer;
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }
                }
                else if(soldierType == "Commando")
                {
                    try
                    {
                        ICommando commando = CreateCommando(commandArgs, id, firstName, lastName, salary);

                        soldier = commando;
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }
                }
                else if(soldierType == "Spy")
                {
                    soldier = CreateSpy(commandArgs, id, firstName, lastName);
                }

                if(soldier != null)
                {
                    this.soldiers.Add(soldier);
                }

                commandArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                soldierType = commandArgs[0];
            }

            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private ISoldier CreateSpy(string[] commandArgs, int id, string firstName, string lastName)
        {
            int codeNumber = int.Parse(commandArgs[4]);
            ISoldier spy = new Spy(id, firstName, lastName, codeNumber);
            return spy;
        }

        private ICommando CreateCommando(string[] commandArgs, int id, string firstName, string lastName, decimal salary)
        {
            string corps = commandArgs[5];
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);

            string[] missionsArgs = commandArgs
                .Skip(6)
                .ToArray();

            for (int i = 0; i < missionsArgs.Length; i += 2)
            {
                string codeName = missionsArgs[i];
                string state = missionsArgs[i + 1];

                try
                {
                    IMission mission = new Mission(codeName, state);
                    commando.AddMission(mission);
                }
                catch (InvalidMissionException ime)
                {
                    continue;
                }
            }

            return commando;
        }

        private IEngineer CreateEngineer(string[] commandArgs, int id, string firstName, string lastName, decimal salary)
        {
            string corps = commandArgs[5];
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            string[] repairsArgs = commandArgs
                .Skip(6)
                .ToArray();

            for (int i = 0; i < repairsArgs.Length; i += 2)
            {
                string repiarPart = repairsArgs[i];
                int repairHours = int.Parse(repairsArgs[i + 1]);
                IRepair repair = new Repair(repiarPart, repairHours);
                engineer.AddRepair(repair);
            }

            return engineer;
        }

        private ISoldier CreatePrivate(int id, string firstName, string lastName, decimal salary)
        {
            return new Private(id, firstName, lastName, salary);
        }

        private ISoldier CreateGeneral(string[] commandArgs, int id, string firstName, string lastName, decimal salary)
        {
            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            foreach (var privateId in commandArgs.Skip(5))
            {
                ISoldier privateToAdd = this.soldiers.FirstOrDefault(s => s.Id == int.Parse(privateId));

                lieutenantGeneral.AddPrivate(privateToAdd);
            }

            return lieutenantGeneral;
        }
    }
}
