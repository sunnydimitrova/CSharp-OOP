using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedure
{
    public class Chip : Procedure
    {
      
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            robot.ProcedureTime -= procedureTime;
            robot.Happiness -= 5;
            if (robot.IsChipped)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }
            robot.IsChipped = true;
            this.Robots.Add(robot);
        }
    }
}
