using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly ICollection<IDriver> models;

        public DriverRepository()
        {
            this.models = new List<IDriver>();
        }
        public void Add(IDriver model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.models.ToList();
        }

        public IDriver GetByName(string name)
        {
            var driver = this.models.FirstOrDefault(x => x.Name == name);
            return driver;
        }

        public bool Remove(IDriver model)
        {
            return this.models.Remove(model);
        }
    }
}
