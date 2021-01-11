using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    class Rest : Procedures
    {
        private const int HappinessDereasement = 3;
        private const int EnergyIncreasement = 10;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness -= HappinessDereasement;
            robot.Energy += EnergyIncreasement;
        }
    }
}
