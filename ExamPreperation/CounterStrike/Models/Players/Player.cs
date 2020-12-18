using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        public Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }

        public string Username 
        {
            get => this.username;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                this.username = value;
            }
        }

        public int Health 
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                this.health = value;
            }
        }

        public int Armor
        {
            get => this.armor;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                this.armor = value;
            }
        }

        public IGun Gun 
        {
            get => this.gun;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }
                this.gun = value;
            }
        }

        public bool IsAlive => this.Health > 0;

        public void TakeDamage(int points)
        {
            var remainingPoints = 0;
            if (this.Armor >= points)
            {
                this.Armor -= points;
            }
            else
            {
                remainingPoints += points - this.Armor;
                if (this.Armor == 0)
                {
                    if (this.Health > remainingPoints)
                    {
                        this.Health -= remainingPoints;
                    }
                    else
                    {
                        this.Health = 0;
                    }
                }
                else
                {
                    this.Armor -= points - remainingPoints;
                    if (this.Health > remainingPoints)
                    {
                        this.Health -= remainingPoints;
                    }
                    else
                    {
                        this.Health = 0;
                    }
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");
            return sb.ToString().TrimEnd();
        }
    }
}
