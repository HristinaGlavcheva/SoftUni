using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

using System;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedures
    {
        private const int HappinessDecreasement = 5;
        
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (robot.IsChipped)
            {
                throw new ArgumentException(ExceptionMessages.AlreadyChipped, robot.Name);
            }

            robot.Happiness -= HappinessDecreasement;
        }
    }
}
