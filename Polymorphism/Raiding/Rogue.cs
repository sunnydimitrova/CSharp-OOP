using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
        }

        public override int Power => 80;

        public override string CastAbility(IBaseHero hero)
        {
            return $"{hero.GetType().Name} - {hero.Name} hit for {hero.Power} damage";
        }
    }
}
