using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private int horsePower;
        public SportsCar(string model, int horsePower)
            : base(model, horsePower, 3000, 250, 450)
        {

        }
        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 250 || value > 450)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }
    }
}
