using PizzaCalories.TopingInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.DoughInfo
{
    public class Toping
    {
        private string topingType;
        private double weight;

        public Toping(string topingType, double weight)
        {
            TopingType = topingType;
            Weight = weight;
        }

        public string TopingType
        {
            get { return topingType; }
            private set
            {
                if (!TopingData.IsValidTypes(value))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                this.topingType = value; 
            }
        }        

        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.TopingType} weight should be in the range [1..50].");
                }
                weight = value; 
            }
        }

        public double CalculateCalories()
        {
            return 2 * this.Weight * TopingData.GetTopingCalories(this.TopingType);
        }
    }
}
