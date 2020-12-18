using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interface;
using WildFarm.Models.FoodConteinr;

namespace WildFarm.Models.Animals.BirdConteiner
{
    public class Owl : Bird
    {

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightAdder => 0.25;

        public override ICollection<Type> PrefferFood => new List<Type>()
        { typeof(Meat) };

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
