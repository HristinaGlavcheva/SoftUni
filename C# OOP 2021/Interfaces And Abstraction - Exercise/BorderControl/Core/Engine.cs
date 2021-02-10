using BorderControl.Contracts;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl.Core
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        
        private List<IIdentifiable> citizens;
        private List<IIdentifiable> robots;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            
            this.citizens = new List<IIdentifiable>();
            this.robots = new List<IIdentifiable>();
        }

        public void Run()
        {
            ParseInput();

            string fakeIdsEndDigits = this.reader.ReadLine();

            PrintFakeVisitor(fakeIdsEndDigits, this.citizens);
            PrintFakeVisitor(fakeIdsEndDigits, this.robots);
        }

        private void ParseInput()
        {
            string command = this.reader.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (cmdArgs.Length == 3)
                {
                    AddCitizen(cmdArgs);
                }
                else if (cmdArgs.Length == 2)
                {
                    AddRobot(cmdArgs);
                }

                command = this.reader.ReadLine();
            }
        }

        private void PrintFakeVisitor(string fakeIdsEndDigits, List<IIdentifiable> visitors)
        {
            foreach (var visitor in visitors)
            {
                if (visitor.Id.EndsWith(fakeIdsEndDigits))
                {
                    this.writer.WriteLine(visitor.Id);
                }
            }
        }

        private void AddRobot(string[] cmdArgs)
        {
            string model = cmdArgs[0];
            string id = cmdArgs[1];

            IRobot robot = new Robot(model, id);
            this.robots.Add(robot);
        }

        private void AddCitizen(string[] cmdArgs)
        {
            string name = cmdArgs[0];
            int age = int.Parse(cmdArgs[1]);
            string id = cmdArgs[2];

            ICitizen citizen = new Citizen(name, age, id);
            this.citizens.Add(citizen);
        }
    }
}
