using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            var items = new List<IBuyer>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var current = Console.ReadLine().Split();
                if (current.Length == 4)
                {
                    var citizen = new Citizen(current[0], int.Parse(current[1]), current[2], current[3]);
                    items.Add(citizen);
                }
                else
                {
                    var rebel = new Rebel(current[0], int.Parse(current[1]), current[2]);
                    items.Add(rebel);
                }
            }
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var buyer = items.SingleOrDefault(b => b.Name == input);
                if (buyer != null)
                {
                    buyer.BuyFood();
                }                              
            }
            Console.WriteLine(items.Sum(x => x.Food));
        }
    }
}
