﻿using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }
        public void Add(ICar model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.models.ToList();
        }
        

        public ICar GetByName(string name)
        {
            var car = this.models.FirstOrDefault(x => x.Model == name);
            return car;
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}
