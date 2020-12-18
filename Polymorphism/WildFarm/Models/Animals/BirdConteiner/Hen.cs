using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interface;
using WildFarm.Models.FoodConteiner;
using WildFarm.Models.FoodConteinr;

namespace WildFarm.Models.Animals.BirdConteiner
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightAdder => 0.35;

        public override ICollection<Type> PrefferFood => new List<Type>()
        { typeof(Vegetable), typeof(Fruit), typeof(Seeds), typeof(Meat) };

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
