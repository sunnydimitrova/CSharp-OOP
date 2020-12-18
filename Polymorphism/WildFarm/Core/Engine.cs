using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Core.Contracts;
using WildFarm.Interface;
using WildFarm.Models.Animals.BirdConteiner;
using WildFarm.Models.Animals.MammalConteiner;
using WildFarm.Models.FoodConteiner;
using WildFarm.Models.FoodConteinr;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private ICollection<IAnimal> animals;
        private ICollection<IFood> foods;
        public Engine()
        {
            this.animals = new List<IAnimal>();
            this.foods = new List<IFood>();
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var animalInput = input.Split();
                var foodInput = Console.ReadLine().Split();

                IAnimal animal = null;
                var animalType = animalInput[0];
                var name = animalInput[1];
                var weight = double.Parse(animalInput[2]);               
                if (animalType == "Owl")
                {
                    var wingSize = double.Parse(animalInput[3]);
                    animal = new Owl(name, weight, wingSize);
                }
                else if (animalType == "Hen")
                {
                    var wingSize = double.Parse(animalInput[3]);
                    animal = new Hen(name, weight, wingSize);
                }
                else
                {
                    var livingRegion = animalInput[3];
                    if (animalType == "Dog")
                    {
                        animal = new Dog(name, weight, livingRegion);
                    }
                    else if (animalType == "Mouse")
                    {
                        animal = new Mouse(name, weight, livingRegion);
                    }
                    else
                    {
                        var breed = animalInput[4];
                        if (animalType == "Cat")
                        {
                            animal = new Cat(name, weight, livingRegion, breed);
                        }
                        else if (animalType == "Tiger")
                        {
                            animal = new Tiger(name, weight, livingRegion, breed);
                        }
                    }
                }

                var foodType = foodInput[0];
                var quantity = int.Parse(foodInput[1]);
                IFood food = null;
                if (foodType == "Vegetable")
                {
                    food = new Vegetable(quantity);
                }
                else if (foodType == "Fruit")
                {
                    food = new Fruit(quantity);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(quantity);
                }
                else
                {
                    food = new Seeds(quantity);
                }
                
                Console.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Eat(food);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                animals.Add(animal);
                
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
