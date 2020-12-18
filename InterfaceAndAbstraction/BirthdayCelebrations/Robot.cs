using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robot : IItem
    {
        public Robot(string name, string iD)
        {
            Name = name;
            ID = iD;
        }

        public string Name { get; private set; }

        public string ID { get; private set; }
    }
}
