using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
        }

        public override int Power => 100;

        public override string CastAbility(IBaseHero hero)
        {
            return $"{hero.GetType().Name} - {hero.Name} hit for {hero.Power} damage";
        }
    }
}
