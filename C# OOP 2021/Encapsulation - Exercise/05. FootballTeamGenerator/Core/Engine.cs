using _05._FootballTeamGenerator.Common;
using _05._FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._FootballTeamGenerator.Core
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string[] input = ReadInput();

            string command = input[0];

            ProcessCommands(ref input, ref command);
        }

        private void ProcessCommands(ref string[] input, ref string command)
        {
            while (command != "END")
            {
                try
                {
                    string teamName = input[1];

                    if (command == "Team")
                    {
                        AddTeam(teamName);
                    }
                    else if (command == "Add")
                    {
                        AddPlayerToATeam(input, teamName);
                    }
                    else if (command == "Remove")
                    {
                        RemovePlayerFromTeam(input, teamName);
                    }
                    else if (command == "Rating")
                    {
                        ShowTeamRating(teamName);
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                input = ReadInput();

                command = input[0];
            }
        }

        private void ShowTeamRating(string teamName)
        {
            Team team = ValidateTeamExists(teamName);

            Console.WriteLine(team);
        }

        private Team ValidateTeamExists(string teamName)
        {
            Team team = this.teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MissingTeam, teamName));
            }

            return team;
        }

        private void RemovePlayerFromTeam(string[] input, string teamName)
        {
                string playerName = input[2];

                Team team = ValidateTeamExists(teamName);
                Player player = team.Players.FirstOrDefault(p => p.Name == playerName);

                team.RemovePlayer(playerName);
        }

        private void AddPlayerToATeam(string[] input, string teamName)
        {
                Team team = ValidateTeamExists(teamName);
                Player player = CreatePlayer(input);

                team.AddPlayer(player);
        }

        private static Player CreatePlayer(string[] input)
        {
            string playerName = input[2];
            int endurance = int.Parse(input[3]);
            int sprint = int.Parse(input[4]);
            int dribble = int.Parse(input[5]);
            int passing = int.Parse(input[6]);
            int shooting = int.Parse(input[7]);

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
            Player player = new Player(playerName, stats);
            return player;
        }

        private void AddTeam(string teamName)
        {
            Team team = new Team(teamName);

            if (!this.teams.Any(t => t.Name == team.Name))
            {
                this.teams.Add(team);
            }
        }

        private string[] ReadInput()
        {
            return Console.ReadLine()
                .Split(";", StringSplitOptions.None)
                .ToArray();
        }
    }
}
