using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interface;

namespace WildFarm
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
