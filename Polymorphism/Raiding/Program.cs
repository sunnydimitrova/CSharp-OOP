using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            var heros = new List<BaseHero>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var type = Console.ReadLine();
                if (type == "Druid")
                {
                    BaseHero druid = new Druid(name);
                    heros.Add(druid);
                }
                else if (type == "Paladin")
                {
                    BaseHero paladin = new Paladin(name);
                    heros.Add(paladin);
                }
                else if (type == "Rogue")
                {
                    BaseHero rogue = new Rogue(name);
                    heros.Add(rogue);
                }
                else if (type == "Warrior")
                {
                    BaseHero warrior = new Warrior(name);
                    heros.Add(warrior);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i -= 1;
                }
            }
            foreach (var hero in heros)
            {
                Console.WriteLine(hero.CastAbility(hero));
            }
            var bossPower = int.Parse(Console.ReadLine());
            var demage = heros.Sum(x => x.Power);
            if (demage > bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

       
    }
}
