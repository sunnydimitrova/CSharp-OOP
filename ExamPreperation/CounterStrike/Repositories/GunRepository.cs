using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly ICollection<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => (IReadOnlyCollection<IGun>)this.models;

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);               
            }
            models.Add(model);
        }

        public IGun FindByName(string name)
        {
            var currGun = this.Models.FirstOrDefault(x => x.Name == name);
            return currGun == null ? null : currGun;
        }

        public bool Remove(IGun model)
        {
            var gunForRemove = this.Models.FirstOrDefault(x => x.Name == model.Name);
            if (gunForRemove == null)
            {
                return false;
            }
            this.models.Remove(gunForRemove);
            return true;

        }
    }
}
