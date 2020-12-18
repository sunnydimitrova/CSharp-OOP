using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
       
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (!DoughtData.IsValidFlourType(value))
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.flourType = value; 
            }
        }
        
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set 
            {
                if (!DoughtData.IsValidBakingTechnique(value))
                {
                    throw new Exception("Invalid type of dough.");
                }
               this.bakingTechnique = value; 
            }
        }


        public double Weight
        {
            get { return weight; }
            set 
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                this.weight = value; 
            }
        }

        public double CalucalteCalories()
        {
            return this.Weight * 2 * DoughtData.GetFlourModifire(this.FlourType)
                * DoughtData.GetBakingModifire(this.BakingTechnique);
        }
    }
}
