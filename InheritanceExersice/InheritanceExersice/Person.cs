using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceExersice
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public virtual int Age
        {
            get
            {
                return age;
            }
            protected set
            {
                if (value >= 0)
                {
                    age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
