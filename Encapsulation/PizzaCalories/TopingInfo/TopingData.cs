using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.TopingInfo
{
    public class TopingData
    {
        private static Dictionary<string, double> topingTypes;
        
        private static void Initilize()
        {
            topingTypes = new Dictionary<string, double>();

            topingTypes.Add("meat", 1.2);
            topingTypes.Add("veggies", 0.8);
            topingTypes.Add("cheese", 1.1);
            topingTypes.Add("sauce", 0.9);
        }

        public static bool IsValidTypes(string type)
        {
            if (topingTypes == null)
            {
                Initilize();
            }
            return topingTypes.ContainsKey(type.ToLower());
        }

        public static double GetTopingCalories(string type) => topingTypes[type.ToLower()];
    }
}
