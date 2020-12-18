using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"A name should not be empty.");
                }
                else
                {
                    this.name = value;
                }                
            }
        }

        public List<Player> Players { get;}

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            if (!Players.Any(p => p.Name == name))
            {
                throw new Exception($"Player {name} is not in {this.Name} team.");
            }
            this.Players.Remove(Players.First(p => p.Name == name));
        }

        public int Rating
        {
            get
            {
                if (this.Players.Count == 0)
                {
                    return 0;
                }
                return (int)Math.Round(this.Players.Sum(p => p.SkillLevel) / this.Players.Count);
            }
        }
    }
}
