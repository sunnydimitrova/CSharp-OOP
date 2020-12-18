using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terorrists = players.Where(x => x.GetType().Name == "Terrorist").ToList();
            var contraTerorists = players.Where(x => x.GetType().Name == "CounterTerrorist").ToList();

            while (terorrists.Any(x => x.IsAlive) && contraTerorists.Any(x => x.IsAlive))
            {
                foreach (var terrorist in terorrists.Where(x => x.IsAlive))
                {
                    foreach (var contra in contraTerorists.Where(x => x.IsAlive))
                    {
                        contra.TakeDamage(terrorist.Gun.Fire());
                    }
                }

                foreach (var contra in contraTerorists.Where(x => x.IsAlive))
                {
                    foreach (var terrorist in terorrists.Where(x => x.IsAlive))
                    {
                        terrorist.TakeDamage(contra.Gun.Fire());                        
                    }
                }
            }
            if (terorrists.Any(x => x.IsAlive))
            {
                return "Terrorist wins!";
            }
            else
            {
                return "Counter Terrorist wins!";
            }
        }
    }
}
