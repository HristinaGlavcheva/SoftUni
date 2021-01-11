using RobotService.Models.Robots.Contracts;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace RobotService.Models.Procedures
{
    public class Charge : Procedures
    {
        private const int HappinessIncreasement = 12;
        private const int EnergyIncreasement = 10;

        public Charge()
        {
            this.Robots = new List<IRobot>();
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness += HappinessIncreasement;
            robot.Energy += EnergyIncreasement;
        }
    }
}
