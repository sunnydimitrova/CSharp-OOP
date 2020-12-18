using RobotService.Models.Procedure.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedure
{
    public abstract class Procedure : IProcedure
    {

        protected Procedure()
        {
            Robots = new List<IRobot>();
        }

        protected List<IRobot> Robots { get; }
       
        public abstract void DoService(IRobot robot, int procedureTime);

        public string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            foreach (var robot in this.Robots)
            {
                sb.AppendLine($"{robot.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
