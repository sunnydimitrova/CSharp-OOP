using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new System.ArgumentException("Invalid input!");
                }
                else
                {
                    name = value;
                }
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Invalid input!");
                }
                else
                {
                    age = value;
                }
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new System.ArgumentException("Invalid input!");
                }
                else
                {
                    gender = value;
                }
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(this.GetType().Name)
                .AppendLine($"{this.name} {this.age} {this.gender}")
                .Append($"{this.ProduceSound()}");

            return builder.ToString();
        }

    }
}
