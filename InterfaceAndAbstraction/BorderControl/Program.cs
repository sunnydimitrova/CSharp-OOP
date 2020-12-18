using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Program
    {
        public static void Main()
        {
            List<IIndividual> items = new List<IIndividual>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var splitedInput = input.Split();
                if (splitedInput.Length == 2)
                {
                    Robot currentRobot = new Robot(splitedInput[0], splitedInput[1]);
                    items.Add(currentRobot);
                }
                else if (splitedInput.Length == 3)
                {
                    Citizen currentCitizen = new Citizen(splitedInput[0], int.Parse(splitedInput[1]), splitedInput[2]);
                    items.Add(currentCitizen);
                }
            }
            var fakeIds = Console.ReadLine();
            foreach (var item in items)
            {
                var itemID = item.ID;
                if (IsEqualDigits(fakeIds, itemID))
                {
                    Console.WriteLine(itemID);
                }
            }
        }

        private static bool IsEqualDigits(string fakeIds, string itemID)
        {
            var sb = new StringBuilder();
            for (int i = itemID.Length - fakeIds.Length; i < itemID.Length; i++)
            {
                sb.Append(itemID[i]);
            }
            if (sb.ToString() != fakeIds)
            {
                return false;
            }
            return true;
        }
    }
}
