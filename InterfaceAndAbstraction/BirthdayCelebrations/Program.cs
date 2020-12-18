using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            var items = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var splitedInput = input.Split();
                var type = splitedInput[0];
                if (type == "Citizen")
                {
                    items.Add(splitedInput[4]);
                }
                else if (type == "Pet")
                {
                    items.Add(splitedInput[2]);
                }
            }
            var year = Console.ReadLine();
            foreach (var item in items)
            {
                if (IsEqualDigits(year, item))
                {                    
                    Console.WriteLine(item);
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
