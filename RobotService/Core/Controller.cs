using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using RobotService.Models.Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotService.Models.Procedure.Contracts;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly Garage garge;
        private readonly List<IProcedure> procedures;

        public Controller()
        {
            this.garge = new Garage();
            this.procedures = new List<IProcedure>();
            this.AddProcedures();
        }
        public string Charge(string robotName, int procedureTime)
        {
            if (!garge.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            var currRobot = garge.Robots.FirstOrDefault(x => x.Key == robotName);
            var robot = currRobot.Value;
            var currProcedure = procedures.FirstOrDefault(x => x.GetType().Name == "Charge");
            currProcedure.DoService(robot, procedureTime);
            return String.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!garge.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            var currRobot = garge.Robots.FirstOrDefault(x => x.Key == robotName);
            var robot = currRobot.Value;
            var currProcedure = procedures.FirstOrDefault(x => x.GetType().Name == "Chip");
            currProcedure.DoService(robot, procedureTime);
            return String.Format(OutputMessages.ChipProcedure, robotName);
            
        }

        public string History(string procedureType)
        {
            IProcedure procedure = null;
            if (procedureType == "Chip")
            {
                procedure = procedures.FirstOrDefault(x => x.GetType().Name == "Chip");
            }
            else if (procedureType == "Charge")
            {
                procedure = procedures.FirstOrDefault(x => x.GetType().Name == "Charge");
            }
            else if (procedureType == "Rest")
            {
                procedure = procedures.FirstOrDefault(x => x.GetType().Name == "Rest");
            }
            else if (procedureType == "Polish")
            {
                procedure = procedures.FirstOrDefault(x => x.GetType().Name == "Polish");
            }
            else if (procedureType == "Work ")
            {
                procedure = procedures.FirstOrDefault(x => x.GetType().Name == "Work");
            }
            else if (procedureType == "TechCheck")
            {
                procedure = procedures.FirstOrDefault(x => x.GetType().Name == "TechCheck");
            }
            return procedure.History();
            
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot currRobot = null;
            if (robotType == "HouseholdRobot")
            {
                currRobot = new HouseholdRobot(name, happiness, energy, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                currRobot = new WalkerRobot(name, happiness, energy, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                currRobot = new PetRobot(name, happiness, energy, procedureTime);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }
            garge.Manufacture(currRobot);
            return String.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!garge.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            var currRobot = garge.Robots.FirstOrDefault(x => x.Key == robotName);
            var robot = currRobot.Value;
            var currProcedure = procedures.FirstOrDefault(x => x.GetType().Name == "Polish");
            currProcedure.DoService(robot, procedureTime);
            return String.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!garge.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            var currRobot = garge.Robots.FirstOrDefault(x => x.Key == robotName);
            var robot = currRobot.Value;
            var currProcedure = procedures.FirstOrDefault(x => x.GetType().Name == "Rest");
            currProcedure.DoService(robot, procedureTime);
            return String.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {          
            var currRobot = garge.Robots.FirstOrDefault(x => x.Key == robotName);
            var robot = currRobot.Value;
            garge.Sell(robotName, ownerName);
            if (robot.IsChipped)
            {
                return String.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return String.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!garge.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            var currRobot = garge.Robots.FirstOrDefault(x => x.Key == robotName);
            var robot = currRobot.Value;
            var currProcedure = procedures.FirstOrDefault(x => x.GetType().Name == "TechCheck");
            currProcedure.DoService(robot, procedureTime);
            return String.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!garge.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            var currRobot = garge.Robots.FirstOrDefault(x => x.Key == robotName);
            var robot = currRobot.Value;
            var currProcedure = procedures.FirstOrDefault(x => x.GetType().Name == "Work");
            currProcedure.DoService(robot, procedureTime);
            return String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        private void AddProcedures()
        {
            procedures.Add(new Charge());
            procedures.Add(new Chip());
            procedures.Add(new Polish());
            procedures.Add(new Rest());
            procedures.Add(new TechCheck());
            procedures.Add(new Work());
        }
    }
}
