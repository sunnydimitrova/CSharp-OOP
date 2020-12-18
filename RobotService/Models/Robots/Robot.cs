using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private int happiness;
        private int energy;
        private string owner;
        private bool isBought;
        private bool isChipped;
        private bool isChecked;

        public Robot(string name, int happiness, int energy, int procedureTime)
        {
            Name = name;
            Happiness = happiness;
            Energy = energy;
            ProcedureTime = procedureTime;
            Owner = "Service";
            IsBought = false;
            IsChipped = false;
            IsChecked = false;
        }

        public string Name { get; set; }

        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }
                this.happiness = value;
            }
        }
        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }
                this.energy = value;
            }
        }
        public int ProcedureTime { get; set; }

        public string Owner 
        { 
            get => this.owner;
            set
            {
                this.owner = value;
            }
        }
        public bool IsBought 
        {
            get => this.isBought;
            set
            {
                this.isBought = value;
            }
        }
           
    public bool IsChipped
        {
            get => this.isChipped;
            set
            {
                this.isChipped = value;
            }
        }
        public bool IsChecked
        {
            get => this.isChecked;
            set
            {
                this.isChecked = value;
            }
        }

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
