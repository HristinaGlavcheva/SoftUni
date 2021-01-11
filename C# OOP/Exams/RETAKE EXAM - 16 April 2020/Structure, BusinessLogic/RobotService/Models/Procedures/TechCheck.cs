using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedures
    {
        private const int EnergyDecreasement = 8;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy -= EnergyDecreasement;

            if (!robot.IsChecked)
            {
                robot.IsChecked = true;
            }
        }
    }
}
