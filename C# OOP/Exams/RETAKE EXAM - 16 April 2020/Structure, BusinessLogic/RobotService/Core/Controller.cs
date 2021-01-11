using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly Garage garage;
        private readonly Dictionary<string, IRobot> robots;

        public Controller()
        {
            this.garage = new Garage();
            this.robots = new Dictionary<string, IRobot>();
            
        }

        private void CheckIfRobotExists(string robotName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }

        public string Charge(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);

            Charge(robotName, procedureTime);

            return string.Format(string.Format(OutputMessages.ChargeProcedure, robotName));
        }

        public string Chip(string robotName, int procedureTime)
        {
            //CheckIfRobotExists(robotName);

            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            Chip(robotName, procedureTime);

            return string.Format(string.Format(OutputMessages.ChipProcedure, robotName));
        }

        public string History(string procedureType)
        {
            StringBuilder sb = new StringBuilder();

            //TODO:
            sb.AppendLine($"{this.GetType()}");

            foreach (var robot in this.robots)
            {
                sb.AppendLine(robot.ToString());
            }

            throw new NotImplementedException();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;
            
            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType != "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType != "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            this.garage.Manufacture(robot);

            return string.Format(string.Format(OutputMessages.RobotManufactured, name));
        }

        public string Polish(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);

            Polish(robotName, procedureTime);

            return string.Format(string.Format(OutputMessages.PolishProcedure, robotName));
        }

        public string Rest(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);

            Rest(robotName, procedureTime);

            return string.Format(string.Format(OutputMessages.RestProcedure, robotName));
        }

        public string Sell(string robotName, string ownerName)
        {
            CheckIfRobotExists(robotName);

            IRobot robot = this.robots.First(r => r.Key == robotName).Value;

            Sell(robotName, ownerName);

            string result = "";

            if (robot.IsChipped)
            {
                result = string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                result = string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }

            return result;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);

            TechCheck(robotName, procedureTime);

            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);

            Work(robotName, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }
    }
}
