using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interface;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightAdder { get; }

        public abstract ICollection<Type> PrefferFood { get; }

        public abstract string ProduceSound();
       

        public void Eat(IFood food)
        {
            if (!this.PrefferFood.Contains(food.GetType()))
            {
                throw new Exception($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += this.WeightAdder * food.Quantity;
            this.FoodEaten += food.Quantity;
        }
    }
}
