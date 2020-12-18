using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IItem
    {
        public Pet(string name, string birhtdate)
        {
            Name = name;
            Birhtdate = birhtdate;
        }

        public string Name { get; private set; }

        public string Birhtdate { get; private set; }
    }
}
