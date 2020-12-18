using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : IIndividual
    {
        public Robot(string name, string iD)
        {
            Name = name;
            ID = iD;
        }

        public string Name { get; set; }
        public string ID { get; set; }
    }
}
