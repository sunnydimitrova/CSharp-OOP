using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIndividual
    {
        private string name;
        private string id;
        private int age;

        public Citizen(string name, int age, string iD)
        {
            this.Name = name;
            this.Age = age;
            this.ID = iD;
        }

        public string Name
        { get => this.name; set => this.name = value; }

        public int Age { get; set; }

        public string ID 
        { get => this.name; set => this.name = value; }
    }
}
