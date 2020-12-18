using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private readonly IDictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }
        public IReadOnlyDictionary<string, IRobot> Robots =>
            (IReadOnlyDictionary<string, IRobot>)this.robots;

        public void Manufacture(IRobot robot)
        {
            if (robots.Count >= 10)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            if (robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }
            robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            var currRobot = robots.FirstOrDefault(x => x.Key == robotName);
            currRobot.Value.Owner = ownerName;
            currRobot.Value.IsBought = true;
            robots.Remove(currRobot);
        }
    }
}
