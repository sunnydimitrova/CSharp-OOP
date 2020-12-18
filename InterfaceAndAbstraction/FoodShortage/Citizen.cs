using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.Birthdate = birthDate;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public string ID { get; set; }

        public string Birthdate { get; set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
