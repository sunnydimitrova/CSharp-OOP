using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }

        public virtual int Power { get; protected set; }

        public virtual string CastAbility(IBaseHero hero)
        {
            return $"{hero.GetType().Name} - {hero.Name} healed for {hero.Power}";
        }
    }
}
