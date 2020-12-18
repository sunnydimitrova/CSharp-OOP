using System;
using System.Collections.Generic;
using WildFarm.Core;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.MammalConteiner;
using WildFarm.Models.FoodConteiner;
using WildFarm.Models.FoodConteinr;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }      
    }
}
