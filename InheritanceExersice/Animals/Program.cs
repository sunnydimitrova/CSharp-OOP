using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                var animal = input;
                var animalInfo = Console.ReadLine().Split();
                var name = animalInfo[0];
                var age = int.Parse(animalInfo[1]);
                var gender = animalInfo[2];
                Console.WriteLine(animal);
                if (animal == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    animals.Add(cat);
                }
                else if (animal == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    animals.Add(dog);
                }
                else if (animal == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    animals.Add(frog);
                }
                else if (animal == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                }
                else if (animal == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
