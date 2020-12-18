using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get { return endurance; }
            set 
            {
                if (DataValidation.IsValidData(value))
                {
                    throw new Exception(string.Format(DataValidation.PrintStatsMessage(), nameof(this.Endurance)));
                }
                else
                {
                    endurance = value;
                }
                
            }
        }


        public int Sprint
        {
            get { return sprint; }
            set
            {
                if (DataValidation.IsValidData(value))
                {
                    throw new Exception(String.Format(DataValidation.PrintStatsMessage(), nameof(this.Sprint)));
                }
                else
                {
                    sprint = value;
                }               
            }
        }
        public int Dribble
        {
            get { return dribble; }
            set
            {
                if (DataValidation.IsValidData(value))
                {
                    throw new Exception(string.Format(DataValidation.PrintStatsMessage(), nameof(this.Dribble)));
                }
                else
                {
                    dribble = value;
                }
                
            }
        }
        public int Passing
        {
            get { return passing; }
            set
            {
                if (DataValidation.IsValidData(value))
                {
                    throw new Exception(string.Format(DataValidation.PrintStatsMessage(), nameof(this.Passing)));
                }
                else
                {
                    passing = value;
                }
                
            }
        }
        public int Shooting
        {
            get { return shooting; }
            set
            {
                if (DataValidation.IsValidData(value))
                {
                    throw new Exception(string.Format(DataValidation.PrintStatsMessage(), nameof(this.Shooting)));
                }
                else
                {
                   shooting = value;
                }
                 
            }
        }

        public double CalculateStats()
        {
            return (this.Endurance + this.Dribble + this.Passing + this.Sprint + this.Shooting) / 5.0;
        }
    }
}
