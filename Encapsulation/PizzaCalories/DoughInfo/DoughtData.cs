using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class DoughtData
    {
        private static Dictionary<string, double> flourTypes;
        private static Dictionary<string, double> bakingTechnique;

        private static void Initialize()
        {
            flourTypes = new Dictionary<string, double>();
            bakingTechnique = new Dictionary<string, double>();

            flourTypes.Add("white", 1.5);
            flourTypes.Add("wholegrain", 1.0);

            bakingTechnique.Add("crispy", 0.9);
            bakingTechnique.Add("chewy", 1.1);
            bakingTechnique.Add("homemade", 1.0);
        }

        public static bool IsValidFlourType(string type)
        {
            if (flourTypes == null || bakingTechnique == null)
            {
                Initialize();
            }
            return flourTypes.ContainsKey(type.ToLower());
        }

        public static bool IsValidBakingTechnique(string type)
        {
            if (flourTypes == null || bakingTechnique == null)
            {
                Initialize();
            }
            return bakingTechnique.ContainsKey(type.ToLower());
        }

        public static double GetFlourModifire(string type) => flourTypes[type.ToLower()];
        public static double GetBakingModifire(string type) => bakingTechnique[type.ToLower()];
    }
}
