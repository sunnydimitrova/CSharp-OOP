using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    var splitedInput = input.Split(";", StringSplitOptions.None);
                    var command = splitedInput[0];
                    var currentTeam = splitedInput[1];
                    if (command == "Team")
                    {
                        if (!teams.Any(x => x.Name == currentTeam))
                        {
                            Team team = new Team(currentTeam);
                            teams.Add(team);
                        }
                    }
                    else if (command == "Add")
                    {
                        var playerName = splitedInput[2];
                        Stats playerStat = ReadStats(splitedInput);
                        Player player = new Player(playerName, playerStat);
                        if(!teams.Any(x => x.Name == currentTeam))
                        {
                            throw new Exception($"Team {currentTeam} does not exist.");
                        }
                        Team team = teams.Find(x => x.Name == currentTeam);
                        team.AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        var playerName = splitedInput[2];
                        if (!teams.Any(x => x.Name == currentTeam))
                        {
                            throw new Exception($"Team {currentTeam} does not exist.");
                        }
                        Team team = teams.Find(x => x.Name == currentTeam);
                        team.RemovePlayer(playerName);
                    }
                    else if (command == "Rating")
                    {                        
                        if(!teams.Any(x => x.Name == currentTeam))
                        {
                            throw new Exception($"Team {currentTeam} does not exist.");
                        }
                        Team team = teams.Find(x => x.Name == currentTeam);
                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                
            }
        }

        static Stats ReadStats(string[] input)
        {
            var endurance = int.Parse(input[3]);
            var sprint = int.Parse(input[4]);
            var dribble = int.Parse(input[5]);
            var passing = int.Parse(input[6]);
            var shooting = int.Parse(input[7]);
            return new Stats(endurance, sprint, dribble, passing, shooting);
        }
    }
}
