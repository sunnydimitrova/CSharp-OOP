using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interface;
using WildFarm.Models.FoodConteiner;
using WildFarm.Models.FoodConteinr;

namespace WildFarm.Models.Animals.MammalConteiner
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightAdder => 0.30;

        public override ICollection<Type> PrefferFood => new List<Type>()
        { typeof(Vegetable), typeof(Meat) };

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
