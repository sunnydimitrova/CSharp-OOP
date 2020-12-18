using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interface;
using WildFarm.Models.FoodConteiner;
using WildFarm.Models.FoodConteinr;

namespace WildFarm.Models.Animals.MammalConteiner
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightAdder => 0.10;

        public override ICollection<Type> PrefferFood => new List<Type>() { typeof(Vegetable), typeof(Fruit) };

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
