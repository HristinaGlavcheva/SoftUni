using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedures : IProcedure
    {
        private List<Robot> robots;

        public Procedures()
        {
            this.Robots = new List<Robot>();
        }

        protected List<Robot> Robots { get; set; }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
           if(robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
        }

        public string History()
        {
            //"{procedure type}"
            //" Robot type: {robot type} - {robot name} - Happiness: {happiness} - Energy: {energy}"
            //Note: You should append robot information for each robot in the collection!

            StringBuilder sb = new StringBuilder();

            //TODO:
            sb.AppendLine($"{this.GetType().Name}");

            foreach (var robot in this.Robots)
            {
                sb.AppendLine(robot.ToString());
            }

            throw new NotImplementedException();
        }
    }
}
