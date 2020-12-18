using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interface;
using WildFarm.Models.FoodConteinr;

namespace WildFarm.Models.Animals.MammalConteiner
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightAdder => 0.40;

        public override ICollection<Type> PrefferFood => new List<Type>()
        { typeof(Meat) };

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
