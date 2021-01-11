using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Work : Procedures
    {
        private const int EnergyDecreasement = 6;
        private const int HappinessIncreasement = 12;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy -= EnergyDecreasement;
            robot.Happiness += HappinessIncreasement;
        }
    }
}
