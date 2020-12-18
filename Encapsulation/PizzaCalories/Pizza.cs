using PizzaCalories.DoughInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Toping> topings;
        public Dough Dought { get; }

        public Pizza(string name, Dough dought)
        {
            this.Name = name;
            this.Dought = dought;
            this.topings = new List<Toping>();
        }

        public string Name
        {
            get { return name; }
           private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value; 
            }
        }

        private int TopingsCount 
            => this.topings.Count;

        public double TotalCalories 
            => this.topings.Sum(x => x.CalculateCalories()) + this.Dought.CalucalteCalories();

       public void AddToping(Toping toping)
        {                        
            if (this.TopingsCount == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            this.topings.Add(toping);
        }
    }
}
