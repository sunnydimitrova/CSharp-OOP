using PizzaCalories.DoughInfo;
using System;
using System.Linq;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
       {
            try
            {
                var pizzaName = Console.ReadLine().Split();
                var input = Console.ReadLine().Split();

                Dough dought = new Dough(input[1], input[2], double.Parse(input[3]));
                Pizza pizza = new Pizza(pizzaName[1], dought);
                string topingInput;
                while ((topingInput = Console.ReadLine()) != "END")
                {
                    var currentToping = topingInput.Split();
                    Toping toping = new Toping(currentToping[1], double.Parse(currentToping[2]));
                    pizza.AddToping(toping);
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
                       
        }
    }
}
