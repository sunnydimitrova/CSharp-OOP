using CounterStrike.Models.Guns;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using CounterStrike.Core.Contracts;
using System;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly GunRepository guns;
        private readonly PlayerRepository players;
        private readonly IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            if (type != "Pistol" && type != "Rifle")
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            if (type == "Pistol")
            {
                guns.Add(new Pistol(name, bulletsCount));
            }
            else
            {
                guns.Add(new Rifle(name, bulletsCount));
            }
            return String.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var gun = guns.FindByName(gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }
            else
            {
                if (type != "Terrorist" && type != "CounterTerrorist")
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
                }
                if (type == "Terrorist")
                {
                    players.Add(new Terrorist(username, health, armor, gun));
                }
                else
                {
                    players.Add(new CounterTerrorist(username, health, armor, gun));
                }
                return String.Format(OutputMessages.SuccessfullyAddedPlayer, username);
            }
            
        }

        public string Report()
        {
            var sb = new StringBuilder();
            var sortedPlayers = this.players.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Username).ToList();
            foreach (var player in sortedPlayers)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            var alivePlayers = this.players.Models.Where(x => x.IsAlive).ToList();
            var result = map.Start(alivePlayers);
            return result;
        }
    }
}
