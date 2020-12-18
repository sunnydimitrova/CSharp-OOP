using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var persons = new List<Person>();
                var products = new List<Product>();
                var allPersonAndMoney = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                var allProductsAndCoast = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < allPersonAndMoney.Length; i++)
                {
                    var personAndMoney = allPersonAndMoney[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    var person = personAndMoney[0];
                    var money = decimal.Parse(personAndMoney[1]);
                    Person currentPerson = new Person(person, money);
                    persons.Add(currentPerson);
                }
                for (int i = 0; i < allProductsAndCoast.Length; i++)
                {
                    var productsAndCost = allProductsAndCoast[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    var product = productsAndCost[0];
                    var cost = decimal.Parse(productsAndCost[1]);
                    Product currentProduct = new Product(product, cost);
                    products.Add(currentProduct);
                }
                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    var splitedInput = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                    var personName = splitedInput[0];
                    var productName = splitedInput[1];
                    Person person = persons.FirstOrDefault(p => p.Name == personName);
                    Product product = products.FirstOrDefault(a => a.Name == productName);
                    person.AddToBag(product);
                }

                foreach (var person in persons)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
