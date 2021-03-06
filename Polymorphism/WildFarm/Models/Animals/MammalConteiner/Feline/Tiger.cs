﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interface;
using WildFarm.Models.FoodConteinr;

namespace WildFarm.Models.Animals.MammalConteiner
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightAdder => 1.00;

        public override ICollection<Type> PrefferFood => new List<Type>()
        { typeof(Meat) };

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
